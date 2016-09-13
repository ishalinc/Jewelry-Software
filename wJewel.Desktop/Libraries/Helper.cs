using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using IshalInc.wJewel.Data.DataAccess;
using System.ComponentModel;
using Microsoft.Reporting.WinForms;

namespace IshalInc.wJewel.Desktop.Libraries
{

   
    class Helper : ConnectionAccess
    {
    
        public static string LoggedUser = "ADMIN";

        public static int StyleLength = 15;

        
        public static string CompanyName = "DEMO COMPANY";

        public static string CompanyAddr1 = "123 E46th St.";

        public static string CompanyAddr2 = "NEW YORK, NY 10017";

        public static string CompanyTel = "TEL: (212)555-8588, FAX: (212)555-9505";

        public static string homeimg = "D:\\Dotnet\\Jewelry Software\\wJewel.Desktop\\Resources\\";

        public static string connString = ConfigurationManager.ConnectionStrings["JewelConnection"].ToString();

        public enum ShippingType { Forex,UPS,Other };

        
        static BindingList<NumEquator> numericEquator;
        public static void MsgBox(string msgText)
        {
            MessageBox.Show(msgText, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MsgBox(string msgText, RadMessageIcon msgIcon)
        {
           
            RadMessageBox.Show(msgText, Application.ProductName, MessageBoxButtons.OK, msgIcon);
        }

        public static void MsgBox(string msgText,MessageBoxButtons msgbtn, RadMessageIcon msgIcon)
        {

            RadMessageBox.Show(msgText, Application.ProductName, msgbtn, msgIcon);
        }

        public static Icon MakeIcon(Image img, int size, bool keepAspectRatio)
        {

            Bitmap square = new Bitmap(size, size); // create new bitmap

            Graphics g = Graphics.FromImage(square); // allow drawing to it



            int x, y, w, h; // dimensions for new image



            if (!keepAspectRatio || img.Height == img.Width)
            {

                // just fill the square

                x = y = 0; // set x and y to 0

                w = h = size; // set width and height to size

            }
            else
            {

                // work out the aspect ratio

                float r = (float)img.Width / (float)img.Height;



                // set dimensions accordingly to fit inside size^2 square

                if (r > 1)
                { // w is bigger, so divide h by r

                    w = size;

                    h = (int)((float)size / r);

                    x = 0; y = (size - h) / 2; // center the image

                }
                else
                { // h is bigger, so multiply w by r

                    w = (int)((float)size * r);

                    h = size;

                    y = 0; x = (size - w) / 2; // center the image

                }

            }



            // make the image shrink nicely by using HighQualityBicubic mode

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(img, x, y, w, h); // draw image with specified dimensions

            g.Flush(); // make sure all drawing operations complete before we get the icon



            // following line would work directly on any image, but then

            // it wouldn't look as nice.

            return Icon.FromHandle(square.GetHicon());

        }

        public static object ShippingHandling(string czip, string cviaups, string cearly,string cstate, bool resident, decimal total, string viacod, int weight)
        {
            
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "GetShipping";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@CZIP", czip);
                dbCommand.Parameters.AddWithValue("@CVIAUPS", cviaups);
                dbCommand.Parameters.AddWithValue("@CSTATE", cstate);
                dbCommand.Parameters.AddWithValue("@CEARLY", cearly);
                dbCommand.Parameters.AddWithValue("@RES", resident);
                dbCommand.Parameters.AddWithValue("@TOTAL", total);
                dbCommand.Parameters.AddWithValue("@VIACOD", viacod);
                dbCommand.Parameters.AddWithValue("@WEIGHT", weight);

                SqlParameter outShipHandling = new SqlParameter("@RETVAL",SqlDbType.Decimal) ;
                outShipHandling.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outShipHandling);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                return outShipHandling.Value != System.DBNull.Value ? outShipHandling.Value : 0;
            }
        }

        public static DataTable GetEmailSettings()
        {
            DataTable dataTable = new DataTable();
            
            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "select * from email_settings";

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void CheckInvoiceSequence(int invoiceno)
        {
           
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckInvoiceSequence";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@INV_NO", invoiceno);
               
                SqlParameter outInvNo = new SqlParameter("@RETVAL", SqlDbType.Int);
                outInvNo.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outInvNo);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
               

                if ((int)outInvNo.Value > 0)
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = "ALTER SEQUENCE InvoiceSequence RESTART WITH " + Convert.ToString(outInvNo.Value) + ";";
                    dbCommand.ExecuteNonQuery();
                }
                dbCommand.Connection.Close();
            }
        }


        public static string ShipBy(string shipby)
        {
            string shipvia = "None";
            switch (shipby)
            {
                case "G":
                    shipvia = "Ground";
                    break;
                case "O":
                    shipvia = "Ground";
                    break;
                case "B":
                    shipvia = "2 Day";
                    break;
                case "R":
                    shipvia = "Next Day Std";
                    break;
                case "E":
                    shipvia = "Next Day Priority";
                    break;
                case "F":
                    shipvia = "Next Day First";
                    break;
                case "L":
                    shipvia = "Next Day Letter";
                    break;
                case "S":
                    shipvia = "Saturday";
                    break;
                case "M":
                    shipvia = "Mail";
                    break;
                case "D":
                    shipvia = "Delivery";
                    break;
                case "P":
                    shipvia = "Pickup";
                    break;
                case "N":
                    shipvia = "None";
                    break;
                default:
                    shipvia = "None";
                    break;

            }
            return shipvia;
        }
        public static bool UpdateEmailSettings(string email, string pass, int port, string smtpserver, bool usessl)
        {

           

            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "EmailSetting";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@Email", email);
                dbCommand.Parameters.AddWithValue("@Password", pass);
                dbCommand.Parameters.AddWithValue("@Port", port);
                dbCommand.Parameters.AddWithValue("@smtpserver", smtpserver);
                dbCommand.Parameters.AddWithValue("@usessl", usessl);
               


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        public static bool CheckStyle(string style,out string retstyle,out bool isBar,out string piece )
        {
           

            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckStyle";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@style", style);
                SqlParameter outStyleValid = new SqlParameter("@valid", SqlDbType.Int);
                outStyleValid.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outStyleValid);

                SqlParameter outByBar = new SqlParameter("@by_bar", SqlDbType.Int);
                outByBar.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outByBar);

                SqlParameter outPiece = new SqlParameter("@piece", SqlDbType.NVarChar,1);
                outPiece.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outPiece);

                SqlParameter outStyle = new SqlParameter("@returnstyle", SqlDbType.NVarChar,15);
                outStyle.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outStyle);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                retstyle = outStyle.Value.ToString();
                isBar = (int)outByBar.Value == 1;
                piece = outPiece.Value.ToString();
                return (int)outStyleValid.Value == 1 ;
               
               
            }
        }

        public static bool CheckMemo(string memono)
        {
            

            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckMemo";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@memono", memono);
                SqlParameter outMemoValid = new SqlParameter("@valid", SqlDbType.Int);
                outMemoValid.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outMemoValid);

               
                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
               
                return (int)outMemoValid.Value == 1;


            }
        }

        public static string GetImage(string p_style)
        {
            string imagename;
            if (string.IsNullOrEmpty(p_style))
                return string.Empty;
            imagename = p_style.Substring(0, p_style.IndexOf("_") > 0 ? p_style.IndexOf("_") :  p_style.Length);
            imagename = imagename.Substring(0, Math.Min(imagename.Length, StyleLength));
            if (File.Exists(string.Format("{0}{1}{2}", homeimg, imagename, ".jpg")))
                return string.Format("file:\\{0}{1}{2}", homeimg, imagename, ".jpg");
            else
                return string.Empty;


        }

        public static string GetNextReceiptNo()
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;
           
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "Select cast(NEXT VALUE FOR ReceiptSequence as varchar(10)) as receipt_no";
                
                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["receipt_no"].ToString();
            }
        }


        public static string GetNextAdjRcvableNo()
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "Select cast(NEXT VALUE FOR AdjReceivableSequence as varchar(10)) as adj_no";

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["adj_no"].ToString();
            }
        }

        public static string GetNextLogNo()
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "Select cast(NEXT VALUE FOR SISequence as varchar(10)) as inv_no";

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["inv_no"].ToString();
            }
        }


        public static void CheckSISequence(int invoiceno)
        {

            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckSISequence";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@INV_NO", invoiceno);

                SqlParameter outInvNo = new SqlParameter("@RETVAL", SqlDbType.Int);
                outInvNo.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outInvNo);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();


                if ((int)outInvNo.Value > 0)
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = "ALTER SEQUENCE SISequence RESTART WITH " + Convert.ToString(outInvNo.Value) + ";";
                    dbCommand.ExecuteNonQuery();
                }
                dbCommand.Connection.Close();
            }
        }

        public static void CheckReceiptSequence(int invoiceno)
        {
          

            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckReceiptSequence";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@RECEIPT_NO", invoiceno);

                SqlParameter outReceiptNo = new SqlParameter("@RETVAL", SqlDbType.Int);
                outReceiptNo.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outReceiptNo);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();


                if ((int)outReceiptNo.Value > 0)
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = "ALTER SEQUENCE ReceiptSequence RESTART WITH " + Convert.ToString(outReceiptNo.Value) + ";";
                    dbCommand.ExecuteNonQuery();
                }
                dbCommand.Connection.Close();
            }
        }


        public static void CheckAdjReceivableSequence(int adjrcvableno)
        {


            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckAdjReceivableSequence";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@ADJRECVABLE_NO", adjrcvableno);

                SqlParameter outAdjRcvableNo = new SqlParameter("@RETVAL", SqlDbType.Int);
                outAdjRcvableNo.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outAdjRcvableNo);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();


                if ((int)outAdjRcvableNo.Value > 0)
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = "ALTER SEQUENCE AdjReceivableSequence RESTART WITH " + Convert.ToString(outAdjRcvableNo.Value) + ";";
                    dbCommand.ExecuteNonQuery();
                }
                dbCommand.Connection.Close();
            }
        }

        public static void AddShippingType(RadGroupBox grpBox, int itemsPerRow)
        {

            int ctr = 1;
            int rowctr = 1;
            int leftPosition = 1;
            foreach (ShippingType shippingtype in Enum.GetValues(typeof(ShippingType)))
            {
                if (rowctr == itemsPerRow )
                {
                    rowctr++;
                    leftPosition = 1;
                }

                RadioButton rdo = new RadioButton();
                rdo.AutoSize = true;
                
                rdo.Name = "rdo" + shippingtype;
                rdo.Text = shippingtype.ToString();
                
                rdo.Location = new Point(leftPosition, (rowctr * rdo.Size.Height) +2);
                leftPosition = leftPosition + Math.Min(rdo.Size.Width,60) + 5;
                grpBox.Controls.Add(rdo);
              
                ctr++;
            }


        }
        public static string GetNextCreditNo()
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "Select cast(NEXT VALUE FOR CreditSequence as varchar(10)) as credit_no";

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["credit_no"].ToString();
            }
        }

        public static string InvStyle(string p_style)
        {
            if (p_style.IndexOf("_") == 0)
                return p_style;
            else
            {
                p_style = p_style.Substring(0, p_style.IndexOf("_") > 0 ? p_style.IndexOf("_") : p_style.Length);
                p_style = p_style.Substring(0, Math.Min(p_style.Length, StyleLength));
                return p_style;
            }

        }

        public static void CheckCreditSequence(int invoiceno)
        {


            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "CheckCreditSequence";

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@credit_no", invoiceno);

                SqlParameter outReceiptNo = new SqlParameter("@RETVAL", SqlDbType.Int);
                outReceiptNo.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outReceiptNo);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();


                if ((int)outReceiptNo.Value > 0)
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = "ALTER SEQUENCE CreditSequence RESTART WITH " + Convert.ToString(outReceiptNo.Value) + ";";
                    dbCommand.ExecuteNonQuery();
                }
                dbCommand.Connection.Close();
            }
        }

        public static DataTable GetPayItem()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "select * from pay_item where 1=0";

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void SyncStroedProcRemoteDB(string remoteconnstring)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(connString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetLocalSP";
              

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            using (SqlCommand dbCommand = new SqlCommand())
            {
                foreach (DataRow drRow in dataTable.Rows)
                {

                    Application.DoEvents();
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(connString);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = string.Format("SELECT definition FROM sys.sql_modules WHERE object_id = (OBJECT_ID(N'wjewel.dbo.{0}'))", drRow["name"].ToString());


                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    string spScript = (string)dbCommand.ExecuteScalar();
                    dbCommand.Connection.Close();

                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(remoteconnstring);
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = string.Format("DROP PROCEDURE {0}", drRow["name"].ToString());


                    // Open the connection, execute the query and close the connection
                    try
                    {
                        dbCommand.Connection.Open();
                        dbCommand.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                       
                    }
                    try
                    {
                        dbCommand.CommandText = spScript;
                        dbCommand.ExecuteNonQuery();
                        dbCommand.Connection.Close();
                    }
                    catch(Exception ex)
                    {
                        Helper.MsgBox(ex.Message);
                        continue;
                    }



                }
            }
           
        }

        public static bool AddKeepRec(string description)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = string.Format("Insert into keep_rec values(getdate(),Convert(time,getdate()),'{0}',@what)",LoggedUser);
              

                dbCommand.Parameters.AddWithValue("@what", "*" + description + "*");
             
                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }


        public static bool AddError(string errormsg,string errorstack)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(connString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = string.Format("Insert into errors(date,time,who,err_mess,source) values(getdate(),Convert(time,getdate()),'{0}',@errormsg,@errorstack)", LoggedUser);


                dbCommand.Parameters.AddWithValue("@errormsg", errormsg);
                dbCommand.Parameters.AddWithValue("@errorstack", errorstack);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }


        public static void PrintReport(ReportPrinting objRptPrinting,string reporttitle,string reportname, string reportmode, ReportDataSource[] reportDataSourceCollection, ReportParameter[] reportParameterCollection, string email)
        {
            switch (reportmode)
            {
                case "Preview":
                    objRptPrinting.PrintReport(reporttitle, reportname, reportParameterCollection, reportDataSourceCollection, reporttitle);
                    break;
                case "Print":
                    objRptPrinting.PrintReport(reportname, reportParameterCollection, reportDataSourceCollection);
                    break;
                case "Email":
                    objRptPrinting.SendasEmail(reportname, reportParameterCollection, reportDataSourceCollection, email, string.Format("{0}",reporttitle));
                    break;
            }
        }

        public static void PrintReport(ReportPrinting objRptPrinting, string reporttitle, string reportname, string reportmode, ReportDataSource[] reportDataSourceCollection, ReportParameter[] reportParameterCollection,string subReportname,string subReportIdName, string email)
        {
            switch (reportmode)
            {
                case "Preview":
                    objRptPrinting.PrintReport(reporttitle, reportname, reportParameterCollection, reportDataSourceCollection, reporttitle, subReportname, subReportIdName);
                    break;
                case "Print":
                    objRptPrinting.PrintReport(reportname, reportParameterCollection, reportDataSourceCollection, subReportname, subReportIdName);
                    break;
                case "Email":
                    objRptPrinting.SendasEmail(reportname, reportParameterCollection, reportDataSourceCollection, email, reporttitle, subReportname, subReportIdName);
                    break;
            }

            
        }

     
        public static BindingList<NumEquator> NumericEquator()
        {
            numericEquator = new BindingList<NumEquator> { new NumEquator("-","Equal To"),
                                     new NumEquator("<","Less Than"),
                                     new NumEquator(">","Greater Than"),
                                     new NumEquator("<=","Less Than Equal To"),
                                     new NumEquator(">=","Greate Than Equal To")
                                     };
            return numericEquator;


        }

    }

    public class NumEquator
    {
        public string Operator { get; set; }
        public string Desc { get; set; }

        public BindingList<NumEquator> numericEquator { get; set; }

        public NumEquator(string _operator, string _desc)
        {
            numericEquator = new BindingList<NumEquator>();
            Operator = _operator;
            Desc = _desc;
        }

    }
}
