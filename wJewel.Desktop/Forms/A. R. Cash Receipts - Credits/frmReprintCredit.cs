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
    public partial class frmReprintCredit : Telerik.WinControls.UI.RadForm
    {
        private IReceiptService receiptService;

       
        private string invno;
      
       
        private List<KeyValuePair<string, string>> repParams;
        public frmReprintCredit()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            receiptService = new ReceiptService();
            InitializeComponent();
            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.txtCreditNo.Select();
        }

        public frmReprintCredit(string pinvno, List<KeyValuePair<string, string>> list)
        {
           
            this.invno = pinvno;
            this.repParams = list;
            InitializeComponent();

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            this.txtCreditNo.Select();

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
                DataRow drPayment = this.receiptService.GetCredit(this.txtCreditNo.Text);
                if (drPayment == null)
                {
                    Helper.MsgBox("Invalid Credit No.", Telerik.WinControls.RadMessageIcon.Info);
                    return;
                }
                else
                {
                    var list = new List<KeyValuePair<string, string>>();
                    list.Add(new KeyValuePair<string, string>("rpTest", "Test"));
                    

                    frmPrintCredit objPrintReceipt = new frmPrintCredit(this.txtCreditNo.Text, list);
                    objPrintReceipt.StartPosition = FormStartPosition.CenterScreen;

                    
                    DialogResult dialogResult = objPrintReceipt.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {

                        objPrintReceipt.Close();
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

        private void frmReprintCredit_Load(object sender, EventArgs e)
        {
            this.txtCreditNo.Select();
        }
    }
}
