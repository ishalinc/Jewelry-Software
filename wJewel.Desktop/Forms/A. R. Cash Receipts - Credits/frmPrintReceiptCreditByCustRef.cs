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
    public partial class frmPrintReceiptCreditByCustRef : Telerik.WinControls.UI.RadForm
    {
        private IReceiptService receiptService;

       
        private ICustomerService customerService;
        private string output_type = "Preview";
        private DataTable dtSubReport = null;
     
        public frmPrintReceiptCreditByCustRef()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            InitializeComponent();
            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            customerService = new CustomerService();
        }

             

        private void PrintReport()
        {

            this.receiptService = new ReceiptService();
            DataTable data = this.receiptService.GetCashCreditByCustRef(this.txtBillingAcctNo.Text, this.txtCustRef.Text);

            DataView dvPayItems = new DataView(data);

            if (dvPayItems.Count > 0)
            {

                string custemail = string.Empty;

                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvPayItems;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "Test";
                reportParameterCollection[0].Values.Add("");

                Helper.PrintReport(objReportPrinting, "Receipt By Credit Ref.", "IshalInc.wJewel.Desktop.Forms.Reports.rptPrintReceiptCreditByCustRef.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

               
            }
            else
            {
                Helper.MsgBox("No records found", Telerik.WinControls.RadMessageIcon.Info);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
            this.DialogResult = DialogResult.OK;
        }


        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void radRadioButton1_Click(object sender, EventArgs e)
        {

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
                    isvisible = false;
                    this.output_type = result;
                    break;
                case "Print":
                    isvisible = true;
                    this.output_type = result;
                    break;
                case "Email":
                    isvisible = false;
                    this.output_type = result;
                    break;
                default:
                    break;

            }
           
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            using (frmSelectCustomer objSearchForm = new frmSelectCustomer())
            {
                objSearchForm.StartPosition = FormStartPosition.CenterParent;

                objSearchForm.ShowDialog(this);

                if (objSearchForm.DialogResult == DialogResult.OK)
                {
                    if (objSearchForm.ReturnValue != null)
                    {
                        this.txtBillingAcctNo.Text = objSearchForm.ReturnValue["acc"].ToString();
                       
                    }

                }
            }
        }

        private void txtBillingAcctNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {
                DataRow billAcctRow = this.customerService.CheckValidBillingAcct(this.txtBillingAcctNo.Text);
                if (billAcctRow == null)
                {
                    Helper.MsgBox("Invalid Billing Account", Telerik.WinControls.RadMessageIcon.Info);
                    return;
                }
             
            }
        }
    }
}
