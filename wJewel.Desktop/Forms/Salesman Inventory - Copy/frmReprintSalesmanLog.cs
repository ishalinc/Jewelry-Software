using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmReprintSalesmanLog : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;
        private string output_type = "Preview";
        public frmReprintSalesmanLog()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
           
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow drCust = this.salesmanService.CheckValidSalesmanLog(this.radTextBox1.Text);
            if (drCust == null)
            {
                Helper.MsgBox("Log# doesn't Exists.", RadMessageIcon.Info);
                this.radTextBox1.Text = string.Empty;
            }
            else
            {
                DataTable dtSalesmanInventoryReport = this.salesmanService.GetSalesmanInvetoryReport(this.radTextBox1.Text);
                if (dtSalesmanInventoryReport == null)
                    return;

                if (dtSalesmanInventoryReport.Rows.Count > 0)
                {

                    string custemail = string.Empty;



                    ReportPrinting objReportPrinting = new ReportPrinting();
                    Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                    Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                    reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSourceCollection[0].Name = "DataSet1";
                    reportDataSourceCollection[0].Value = dtSalesmanInventoryReport;

                    reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];


                    reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[0].Name = "rpTitle";
                    reportParameterCollection[0].Values.Add(string.Format("Items added to Salesman Line: {0}, Log {1}", dtSalesmanInventoryReport.Rows[0]["line_no"].ToString(), this.radTextBox1.Text));




                    switch (this.output_type)
                    {
                        case "Preview":
                            objReportPrinting.PrintReport("Salesmen Inventory Report", "IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", reportParameterCollection, reportDataSourceCollection, "Salesmen Inventory Report");
                            break;
                        case "Print":
                            objReportPrinting.PrintReport("IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", reportParameterCollection, reportDataSourceCollection);
                            break;
                        case "Email":
                            objReportPrinting.SendasEmail("IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", reportParameterCollection, reportDataSourceCollection, "", string.Format("Salesmen Inventory Report"));
                            break;
                    }
                }
                else
                {
                    Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                }
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
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
    }
}
