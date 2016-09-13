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
    public partial class frmReprintReceipt : Telerik.WinControls.UI.RadForm
    {
        private IReceiptService receiptService;

       
        private string invno;
      
       
        private List<KeyValuePair<string, string>> repParams;
        public frmReprintReceipt()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            receiptService = new ReceiptService();
            InitializeComponent();
            this.btnPrint.ButtonElement.ForeColor = Color.Green;
//            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
//            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.txtReceiptNo.Select();
        }

        public frmReprintReceipt(string pinvno, List<KeyValuePair<string, string>> list)
        {
           
            this.invno = pinvno;
            this.repParams = list;
            InitializeComponent();

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            this.txtReceiptNo.Select();
           
        }

        


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtReceiptNo.Text))
            {
                Helper.MsgBox("Please enter Receivable No.", Telerik.WinControls.RadMessageIcon.Info);
                return;
            }
            else
            {
                DataRow drPayment = this.receiptService.GetPayment(this.txtReceiptNo.Text);
                if (drPayment == null)
                {
                    Helper.MsgBox("Invalid Rcvable No.", Telerik.WinControls.RadMessageIcon.Info);
                    return;
                }
                else
                {
                    var list = new List<KeyValuePair<string, string>>();
                    list.Add(new KeyValuePair<string, string>("rpCustomer", drPayment["acc"].ToString()));
                    list.Add(new KeyValuePair<string, string>("rpEntryDate", string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(drPayment["date"].ToString()))));
                    list.Add(new KeyValuePair<string, string>("rpCheckDate", string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(drPayment["chk_date"].ToString()))));
                    list.Add(new KeyValuePair<string, string>("rpDepositedTo", drPayment["bank"].ToString()));
                    list.Add(new KeyValuePair<string, string>("rpTransactNo", drPayment["transact"].ToString()));
                    list.Add(new KeyValuePair<string, string>("rpRecvNo", drPayment["inv_no"].ToString()));
                    list.Add(new KeyValuePair<string, string>("rpCheckNo", drPayment["check_no"].ToString()));
                    list.Add(new KeyValuePair<string, string>("rpAmount", string.Format("{0:0.00}", Convert.ToDecimal(drPayment["chk_amt"]))));
                    list.Add(new KeyValuePair<string, string>("rpDiscountTaken", string.Format("{0:0.00}", Convert.ToDecimal(drPayment["discount"]))));

                    frmPrintReceipt objPrintReceipt = new frmPrintReceipt(this.txtReceiptNo.Text, list);
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

        private void frmReprintReceipt_Load(object sender, EventArgs e)
        {
            this.txtReceiptNo.Select();
        }
    }
}
