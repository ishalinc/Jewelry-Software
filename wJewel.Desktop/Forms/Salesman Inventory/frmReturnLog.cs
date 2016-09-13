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
    public partial class frmReturnLog : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;

        private ICustomerService customerService;

        private string output_type = "Preview";

        string retstyle, piece;
        bool isbar;

        public frmReturnLog()
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

            this.txtLog.Focus();
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow drIncSls = null;
            DataTable dtIncSls = null;
            if (string.IsNullOrEmpty(this.txtLog.Text))
            {
                Helper.MsgBox("Please enter Log.");
                this.txtLog.Focus();
                return;
            }
            else
            {
                dtIncSls = this.salesmanService.CheckValidSalesmanLog(this.txtLog.Text);

                
                if (dtIncSls != null)
                {
                    drIncSls = dtIncSls.Rows[0];
                }
                if (dtIncSls == null)
                {
                    Helper.MsgBox("Log# doesn't Exists.", RadMessageIcon.Info);
                    this.txtLog.Text = string.Empty;
                    return;
                }
            }
            
            if (string.IsNullOrEmpty(this.txtSalesman1.Text))
            {
                Helper.MsgBox("Please enter Salesman Code");
                this.txtSalesman1.Focus();
                return;
            }
            string retlogno;
            if (Convert.ToInt32(drIncSls["qty"]) > 0)
            {
                DialogResult dialogResult = RadMessageBox.Show("This Log Was Not Returned From A Salesman, Proceed?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    string error = ReturnSlsLog(out retlogno);
                    if (string.IsNullOrEmpty(error))
                    {
                        Helper.AddKeepRec("RETURN SALESMAN LOG# " + this.txtLog.Text + " to Salesman " +  this.txtSalesman1.SelectedValue.ToString() );
                        Helper.MsgBox("Return processed Successfully");
                        this.txtLog.Text = string.Empty;
                        this.txtSalesman1.SelectedIndex = 0;
                    }
                    else
                        Helper.MsgBox(error);
                }
                
            }
            else
            {
               
                string error = ReturnSlsLog(out retlogno);
                if (string.IsNullOrEmpty(error) && !string.IsNullOrEmpty(retlogno))
                {
                    Helper.AddKeepRec("RETURN SALESMAN LOG# " + this.txtLog.Text + " to Salesman " + this.txtSalesman1.SelectedValue.ToString());
                    Helper.MsgBox("Return processed Successfully");

                    if (string.IsNullOrEmpty(error))
                    {
                       
                        DataTable dtSalesmanInventoryReport = this.salesmanService.GetSalesmanInvetoryReport(retlogno);
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
                            reportParameterCollection[0].Values.Add(string.Format("Items added to Salesman Line: {0}, Log {1}", this.txtSalesman1.SelectedValue.ToString(), retlogno));


                            Helper.PrintReport(objReportPrinting, "Salesmen Inventory Report", "IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

                        }
                        else
                        {
                            Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                        }
                    }
                        this.txtLog.Text = string.Empty;
                    this.txtSalesman1.SelectedIndex = 0;

                }
                else
                    Helper.MsgBox(error);
            }
           
        }

        private string ReturnSlsLog(out string retlog)
        {
            string error = string.Empty;
            this.salesmanService.ReturnLog(this.txtLog.Text,this.txtSalesman1.SelectedValue.ToString(), out error, out retlog);
            return error;
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
