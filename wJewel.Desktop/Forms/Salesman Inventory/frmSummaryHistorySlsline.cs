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
    public partial class frmSummaryHistorySlsline : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;

        private ICustomerService customerService;
        private string output_type = "Preview";
        public frmSummaryHistorySlsline()
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

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSalesman1.Text))
            {
                Helper.MsgBox("Please enter Salesman Code");
                this.txtSalesman1.Focus();
            }
            else
            {
                PrintReport();
            }


        }


        private void PrintReport()
        {
            DataTable dtSlsHistory = this.salesmanService.SummarySlsHistory(this.txtSalesman1.SelectedValue.ToString());
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
                reportParameterCollection[0].Values.Add(string.Format("Summary History of Salesman Inventory. Salesman: {0}", this.txtSalesman1.Text));

                Helper.PrintReport(objReportPrinting, "Summary History of Salesman Inventory", "IshalInc.wJewel.Desktop.Forms.Reports.rptSlsSummaryHistory.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);


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
