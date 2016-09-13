using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading;
using Microsoft.Reporting.WinForms;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmRcblCreditByTimeFrame : Telerik.WinControls.UI.RadForm
    {
        private IReceiptService receiptService;

       
        private string invno;

        private string output_type = "Preview";

        private DataView dvRcvableCreditTimeFrame;

        private List<KeyValuePair<string, string>> repParams;
        public frmRcblCreditByTimeFrame()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            receiptService = new ReceiptService();

          

            InitializeComponent();

            this.dateFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            this.dateTo.Value = this.dateFrom.Value.AddMonths(1).AddDays(-1);

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


            
        }


        private void LoadDataGridView()
        {

            string fromDate;
            if (!string.IsNullOrEmpty(dateFrom.Text.Trim()))
                fromDate = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateFrom.Value));
            else
                fromDate = string.Format("{0:yyyy-MM-dd}", new DateTime(0001, 1, 1));

            string toDate;
            if (!string.IsNullOrEmpty(dateTo.Text.Trim()))
                toDate = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTo.Value));
            else
                toDate = string.Format("{0:yyyy-MM-dd}", new DateTime(9999, 12, 31));

            // Data grid view column setting      
            radGridView1.DataSource = "";



            string trantype = string.Empty;
            if (this.chkReceipts.Checked)
                trantype += "P,";

            if (this.chkCredits.Checked)
                trantype += "C,";

            if (this.chkAdjRcvable.Checked)
                trantype += "F";


            if (chkSummary.Checked)
            {
               
            }
            else
            {
                DataTable data = this.receiptService.GetRcvableCreditByTimeFrame(this.txtAcc1.Text,this.txtAcc2.Text, this.radRadioButton1.IsChecked  ? "E" : "C",fromDate, toDate,trantype);
                /*
                var groupedData = from b in data.AsEnumerable()
                                  where b.Field<string>("rtv_pay").Contains("C")
                                  group b by b.Field<string>("cred_code") into g
                                  select new
                                  {
                                      CreditCode = g.Key,
                                      TotalSum = g.Sum(x => x.Field<decimal>("paid"))
                                  };
                */
                dvRcvableCreditTimeFrame = new DataView(data);
            }

            if (dvRcvableCreditTimeFrame.Count == 0)
            {
                Helper.MsgBox("No Records Found");
                return;
            }

            radGridView1.DataSource = dvRcvableCreditTimeFrame;
           
            radGridView1.Columns[0].Width = 30;
            radGridView1.Columns[1].Width = 30;
            radGridView1.Columns[2].Width = 50;
            radGridView1.Columns[3].Width = 50;
            radGridView1.Columns[4].Width = 100;
            radGridView1.Columns[5].Width = 50;
            radGridView1.Columns[6].Width = 30;
            radGridView1.Columns[7].Width = 50;
            radGridView1.Columns[8].Width = 50;
            radGridView1.Columns[9].Width = 50;
            radGridView1.Columns[10].Width = 30;
            radGridView1.Columns[11].Width = 50;
            radGridView1.Columns[12].Width = 50;
            radGridView1.Columns[13].Width = 0;
            radGridView1.Columns[14].Width = 0;

            radGridView1.Columns[0].HeaderText = "Inv No.";
            radGridView1.Columns[1].HeaderText = "RTV";
            radGridView1.Columns[2].HeaderText = "Date";
            radGridView1.Columns[2].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].HeaderText = "Chk. Date";
            radGridView1.Columns[3].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].HeaderText = "Name";
            radGridView1.Columns[5].HeaderText = "Paid";
            radGridView1.Columns[5].FormatString = "{0:c}";
            radGridView1.Columns[6].HeaderText = "Chk. No.";
            radGridView1.Columns[7].HeaderText = "Applied";
            radGridView1.Columns[7].FormatString = "{0:c}";
            radGridView1.Columns[8].HeaderText = "Balance";
            radGridView1.Columns[8].FormatString = "{0:c}";
            radGridView1.Columns[9].HeaderText = "Bank";
            radGridView1.Columns[10].HeaderText = "Transact";
            radGridView1.Columns[11].HeaderText = "Chk. Amt.";
            radGridView1.Columns[11].FormatString = "{0:c}";
            radGridView1.Columns[12].HeaderText = "Discount";
            radGridView1.Columns[12].FormatString = "{0:c}";
            radGridView1.Columns[13].IsVisible = false;
            radGridView1.Columns[14].IsVisible = false;
            radGridView1.Columns[15].IsVisible = false;
            radGridView1.Columns[16].IsVisible = false;

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            

            if (dvRcvableCreditTimeFrame.Count > 0)
            {



                if (this.radGridView1.SortDescriptors.Count != 0)
                    dvRcvableCreditTimeFrame.Sort = this.radGridView1.SortDescriptors.ToString();

                string custemail = string.Empty;



                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvRcvableCreditTimeFrame;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];

                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpTitle";
                reportParameterCollection[0].Values.Add("");


                Helper.PrintReport(objReportPrinting, "Rcvable/ Credit By Time Frame", "IshalInc.wJewel.Desktop.Forms.Reports.rptRcvableCreditByTimeFrame.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);


            }
            else
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
            }
        }


        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radRadioButton1_Click(object sender, EventArgs e)
        {

        }

        private void frmReprintReceipt_Load(object sender, EventArgs e)
        {
            
        }

        private void chkAllCustomers_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtAcc1.ReadOnly = this.chkAllCustomers.Checked;
            this.txtAcc2.ReadOnly = this.chkAllCustomers.Checked;
            if (this.chkAllCustomers.Checked)
            {
                this.txtAcc1.Text = "0";
                this.txtAcc2.Text = "ZZ";
            }
        }

        private void chkAllDates_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.dateFrom.ReadOnly = this.chkAllDates.Checked;
            this.dateTo.ReadOnly = this.chkAllDates.Checked;
            this.dateTo.ReadOnly = this.chkAllDates.Checked;
            if (this.chkAllDates.Checked)
            {
                this.dateFrom.Value = new DateTime(1900, 1, 1);
                this.dateTo.Value = new DateTime(2099, 12, 31);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void frmRcblCreditByTimeFrame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, 157, 10, 158,23);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            string result = null;
            foreach (Control control in this.radGroupBox1.Controls)
            {
                if (control is RadRadioButton)
                {
                    RadRadioButton radio = control as RadRadioButton;
                    if (radio.IsChecked)
                    {
                        result = radio.Text;
                    }
                }
            }
            bool isvisible = false;
            switch (result)
            {
                case "Preview":
                    this.output_type = result;
                    break;
                case "Print":
                    this.output_type = result;
                    break;
                case "Email":
                    this.output_type = result;
                    break;
                default:
                    break;

            }
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnPrint.Visible = this.radGridView1.RowCount > 0;
        }

        private void chkAllDates_ToggleStateChanged_1(object sender, StateChangedEventArgs args)
        {
            this.dateFrom.Value = new DateTime(1900, 1, 1);
            this.dateTo.Value = new DateTime(9998, 12, 31);
        }

        private void txtAcc1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtAcc2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAcc1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtAcc2.Text))
                this.txtAcc2.Text = this.txtAcc1.Text;

        }
    }
}
