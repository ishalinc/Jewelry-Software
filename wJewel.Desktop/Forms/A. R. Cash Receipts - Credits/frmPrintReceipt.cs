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
using Telerik.WinControls.UI;
using System.Threading;
using Microsoft.Reporting.WinForms;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmPrintReceipt : Telerik.WinControls.UI.RadForm
    {
        private IReceiptService receiptService;

       
        private string invno;
      
        private string output_type = "Preview";
        private DataTable dtSubReport = null;
        private List<KeyValuePair<string, string>> repParams;
        public frmPrintReceipt()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            InitializeComponent();
            this.btnPrint.ButtonElement.ForeColor = Color.Green;
 //           this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
 //           this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }

        public frmPrintReceipt(string pinvno, List<KeyValuePair<string, string>> list)
        {
           
            this.invno = pinvno;
            this.repParams = list;
            InitializeComponent();
            this.btnPrint.ButtonElement.ForeColor = Color.Green;
   //         this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
   //         this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
           
        }

        

        private void PrintReport()
        {
            
            this.receiptService = new ReceiptService();
            DataTable data = this.receiptService.GetPayItems(this.invno);
            if (data.Rows.Count == 0) ;
             data.Rows.Add();

            DataView dvPayItems = new DataView(data);
            dvPayItems.Sort = "RTV_PAY";

            if (dvPayItems.Count > 0)
            {

                string custemail = string.Empty;

                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvPayItems;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[this.repParams.Count];
                int ctr = 0;
                foreach (KeyValuePair<string, string> kvp in this.repParams)
                {
                    reportParameterCollection[ctr] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[ctr].Name = kvp.Key;
                    reportParameterCollection[ctr].Values.Add(kvp.Value);
                    ctr++;

                }


                Helper.PrintReport(objReportPrinting, "Receipt Print", "IshalInc.wJewel.Desktop.Forms.Reports.rptReceipt.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);
                
                
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

        private void frmPrintReceipt_Load(object sender, EventArgs e)
        {

        }
    }
}
