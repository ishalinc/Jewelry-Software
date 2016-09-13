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
using Telerik.WinControls;
using System.Threading;
using Microsoft.Reporting.WinForms;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmDeleteCredit : Telerik.WinControls.UI.RadForm
    {
        private IReceiptService receiptService;

       
        private string invno;
      
       
        private List<KeyValuePair<string, string>> repParams;
        public frmDeleteCredit()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            receiptService = new ReceiptService();
            InitializeComponent();
            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        public frmDeleteCredit(string pinvno, List<KeyValuePair<string, string>> list)
        {
           
            this.invno = pinvno;
            this.repParams = list;
            InitializeComponent();
           
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }

        


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCreditNo.Text))
            {
                Helper.MsgBox("Please enter Credit No.", Telerik.WinControls.RadMessageIcon.Info);
                return;
            }
            else
            {
                DataRow drCredit = this.receiptService.GetCredit(this.txtCreditNo.Text);
                if (drCredit == null)
                {
                    Helper.MsgBox("Invalid Credit No.", Telerik.WinControls.RadMessageIcon.Info);
                    return;
                }
                else
                {
                    DataRow drPayment = this.receiptService.GetPayment(this.txtCreditNo.Text, "C");
                    if (drPayment != null && Convert.ToDecimal(drPayment["applied"]) > 0)
                    {

                        Helper.MsgBox("This Credit Has Already Been Applied To Clear Invoices,Credit Can Not Be Deleted", RadMessageIcon.Info);
                        return;
                    }
                    else
                    {

                        DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to delete the credit?", "Delete Credit", MessageBoxButtons.YesNo, Telerik.WinControls.RadMessageIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string error;
                            if (this.receiptService.DeleteCredit(drPayment["acc"].ToString(), this.txtCreditNo.Text, Convert.ToDecimal(drPayment["paid"]), out error))
                            {

                                Helper.AddKeepRec("Del. Credit. " + this.txtCreditNo.Text);
                                this.txtCreditNo.Text = string.Empty;
                                Helper.MsgBox("Credit Deleted successfully", RadMessageIcon.Info);

                                
                            }
                            else
                                Helper.MsgBox(string.Format("Credit Deletion unsuccessful :  {0}", error), RadMessageIcon.Info);
                        }
                    }

                }
            }
        }


        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radRadioButton1_Click(object sender, EventArgs e)
        {

        }

        private void frmDeleteReceipt_Load(object sender, EventArgs e)
        {
            this.txtCreditNo.Select();
        }
    }
}
