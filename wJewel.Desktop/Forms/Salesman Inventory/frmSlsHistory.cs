using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmSlsHistory : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;

        private ICustomerService customerService;

        private string output_type = "Preview";

        string retstyle, piece;
        bool isbar;

        public frmSlsHistory()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
            this.customerService = new CustomerService();
            DataTable data = this.customerService.GetSalesmen();
            DataView dvSalesmen1 = new DataView(data);
            this.txtSalesman1.Items.Clear();
            dvSalesmen1.RowFilter = "Code <> ''";
            this.txtSalesman1.DataSource = dvSalesmen1;
            this.txtSalesman1.DisplayMember = "Code";
            this.txtSalesman1.ValueMember = "Code";
            this.txtSalesman1.SelectedIndex = -1;

            this.txtStyle.Focus();
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStyle.Text))
            {
                Helper.MsgBox("Please enter style.");
                this.txtStyle.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtSalesman1.Text))
            {
                Helper.MsgBox("Please enter Salesman Code");
                this.txtSalesman1.Focus();
                return;
            }
           
            if (!Helper.CheckStyle(this.txtStyle.Text,out retstyle,out isbar,out piece))
            {
                Helper.MsgBox("Invalid Style.", RadMessageIcon.Info);
                this.txtStyle.Text = string.Empty;
                this.txtStyle.Focus();
            }
            else
            {
                PrintReport();
            }
        }

        private void PrintReport()
        {
            DataTable dtSlsHistory = this.salesmanService.SlsHistory(this.txtSalesman1.SelectedValue.ToString(), retstyle);
            if (dtSlsHistory == null)
            {
                Helper.MsgBox("No Records Found");
                return;
            }

            if (dtSlsHistory.Rows.Count > 0)
            {

                string custemail = string.Empty;



                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dtSlsHistory;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];


                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpTitle";
                reportParameterCollection[0].Values.Add(string.Format("History of Salesman Inventory. Style: {0}, Salesman: {1}", retstyle, this.txtSalesman1.Text));



                Helper.PrintReport(objReportPrinting, "History of Salesman Inventory", "IshalInc.wJewel.Desktop.Forms.Reports.rptSlsHistory.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

            }
            else
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
            }
        }


        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}
