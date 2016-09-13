// -----------------------------------------------------------------------
// <copyright file="CustomerAccess.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using IshalInc.wJewel.Data.DataModel;
    using IshalInc.wJewel.Data.Sql;

    /// <summary>
    /// Data access class for Customer table
    /// </summary>
    public class SalesmenAccess : ConnectionAccess, ISalesmenAccess
    {

      
        public DataTable GetSalesmenCodes()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.sqlGetSalesmenCodes);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        public DataTable GetSalesmenCreditByCreditCode(string salesmen, string fromCustomer, string toCustomer, string fromDate, string toDate)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetCreditByCreditCode";
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@salesmen", salesmen);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc1", fromCustomer);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc2", toCustomer);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", fromDate);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", toDate);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable CheckValidSalesmanLog(string logno)
        {
            DataTable dataTable = new DataTable();
           

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_salesmaninventory.sqlCheckSalesmanLog;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@logno", logno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                return dataTable.Rows.Count > 0 ? dataTable : null;

            }
        }

        public DataRow GetSalesmanStyleData(string invno, string style, string invstyle, string line_no, string size, int qty, decimal weight)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetSalesmanStyleData";
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@invno", invno);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@style", style);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@invstyle", invstyle);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@line_no", line_no);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@size", size);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@qty", qty);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@weight", weight);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public bool SaveInventory(DataTable dtSalesInventory, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "AddSlsInventory";



                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@TBLINVENTORY";
                    parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    parameter.Value = dtSalesInventory;
                    dbCommand.Parameters.Add(parameter);

                  
                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public DataTable GetSalesmanInvetoryReport(string inv_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(script_salesmaninventory.sqlInventoryReport);
                
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        public bool ReturnLog(string logno, string salesmancode,  out string error,out string retlogno)
        {
            try
            {
                error = string.Empty;
                retlogno = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "ReturnSlsLog";

                    // Add the input parameter to the parameter collection
                    dbCommand.Parameters.AddWithValue("@LOGNO", logno);
                    dbCommand.Parameters.AddWithValue("@SALESMANCODE", salesmancode);
                    SqlParameter outLogNo = new SqlParameter("@RETVAL", SqlDbType.NVarChar,10);
                    outLogNo.Direction = ParameterDirection.Output;
                    dbCommand.Parameters.Add(outLogNo);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    retlogno = (string)outLogNo.Value;
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                retlogno = string.Empty;
                return false;
            }
        }
        public bool CancelSalesmanItems(string inv_no, out string error)
        {
            try
            {
                error = string.Empty;

                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "CancelSlsInventory";

                    // Add the input parameter to the parameter collection
                    dbCommand.Parameters.AddWithValue("@pinv_no", inv_no);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool FixSls(string inv_no, out string error)
        {
            try
            {
                error = string.Empty;

                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "Fixsls";

                    // Add the input parameter to the parameter collection
                    dbCommand.Parameters.AddWithValue("@SALESMANCODE", inv_no);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public DataTable GetSalesmanInvByLineAndStyle(string salesmen, string fromStyle, string toStyle, decimal pricecode)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetSalesmanInvByLineAndStyle";
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@salesmen", salesmen);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@style1", fromStyle);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@style2", toStyle);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@pricecode", pricecode);
                


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable StyleTrackingSlsInv(string style)
        {
            DataTable dataTable = new DataTable();
        

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_salesmaninventory.sqlStyleTrackingSlsInv;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@style", style);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                return dataTable.Rows.Count > 0 ? dataTable : null;

              
            }
        }

        public bool CheckSlsInvStyle(string style)
        {
            DataTable dataTable = new DataTable();
            

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_salesmaninventory.sqlCheckSlsInvStyle;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@style", style);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                return dataTable.Rows.Count > 0 ;

            }
        }

        public bool ClearSalesmanLine(string salesmancode, out string error)
        {
            try
            {
                error = string.Empty;

                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "ClearSalesmanLine";

                    // Add the input parameter to the parameter collection
                    dbCommand.Parameters.AddWithValue("@SALESMANCODE", salesmancode);

                    // Open the connection, execute the query and close the connection
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public DataTable SlsHistory(string salesmancode,string style)
        {
            DataTable dataTable = new DataTable();


            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.CommandText = "SlsHistory";

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SALESMANCODE", salesmancode);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@PSTYLE", style);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                return dataTable.Rows.Count > 0 ? dataTable : null;


            }
        }


        public DataTable SummarySlsHistory(string salesmancode)
        {
            DataTable dataTable = new DataTable();


            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.CommandText = "SummaryHistorySlsLine";

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SALESMANCODE", salesmancode);
              

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                return dataTable.Rows.Count > 0 ? dataTable : null;


            }
        }

        public int GetSlsAllotedQtyByStyle(string style,string line_no)
        {
           
            using (SqlCommand sqlCommand = new SqlCommand())
            {

                sqlCommand.Connection = new SqlConnection(this.ConnectionString);
                sqlCommand.Connection.Open();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = script_salesmaninventory.sqlGetSlsQtyByStyle;
                sqlCommand.Parameters.AddWithValue("@line_no", line_no);
                sqlCommand.Parameters.AddWithValue("@STYLE", style);

                object objResult = sqlCommand.ExecuteScalar();
                sqlCommand.Dispose();

                if (sqlCommand.Connection.State == ConnectionState.Open)
                {
                    sqlCommand.Connection.Close();
                }

                return objResult == null ? 0 : Convert.ToInt32(objResult);
               
            }
        }
    }
}
    