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
    public partial class frmAccountCode : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;
      

        public frmAccountCode()
        {
          
            InitializeComponent();
            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.customerService = new CustomerService();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(radTextBox1.Text)) {
                Helper.MsgBox("Missing Customer Code.", RadMessageIcon.Info);
                return;
            }
            DataRow drCust = this.customerService.CheckValidCustomerCode(this.radTextBox1.Text);
            if (drCust != null)
            {
                Helper.MsgBox("Customer Code Already Exists.", RadMessageIcon.Info);
                this.radTextBox1.Text = string.Empty;
            }
            else
            {
                // hide main form
                this.Hide();

                // show billingaccount form
                frmBillingAccountNumber objBillingAccount = new frmBillingAccountNumber(this.radTextBox1.Text);
                objBillingAccount.StartPosition = FormStartPosition.CenterScreen;
                objBillingAccount.MdiParent = this.MdiParent;
                objBillingAccount.Show();

                // close application
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAccountCode_Load(object sender, EventArgs e)
        {

        }
    }
}
