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
    public partial class frmBillingAccountNumber : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        ///Billing Account Code
        /// </summary>
        private string acccode;

        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        public frmBillingAccountNumber()
        {
            InitializeComponent();
        }

        public frmBillingAccountNumber(string acccode)
        {
            this.acccode = acccode;
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.customerService = new CustomerService();
            InitializeComponent();
            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.radTextBox1.Text = acccode;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.acccode == this.radTextBox1.Text)
            {

                // hide main form
                this.Hide();
                // show new customer form
                frmNewCustomer objNewCustomer = new frmNewCustomer(this.acccode, this.radTextBox1.Text, null);
                objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                objNewCustomer.MdiParent = this.MdiParent;
                objNewCustomer.Show();
                // close application
                this.Close();



            }
            else
            {
                DataRow drCust = this.customerService.CheckValidCustomerCode(this.radTextBox1.Text);
                if (drCust == null)
                {
                    Helper.MsgBox("Invalid Billing Account no.", RadMessageIcon.Info);
                    this.radTextBox1.Text = string.Empty;
                }
                else
                {

                    // hide main form
                    this.Hide();
                    // show new customer form
                    frmNewCustomer objNewCustomer = new frmNewCustomer(this.acccode, this.radTextBox1.Text, drCust);
                    objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                    objNewCustomer.MdiParent = this.MdiParent;
                    objNewCustomer.Show();
                    // close application
                    this.Close();

                }
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBillingAccountNumber_Load(object sender, EventArgs e)
        {

        }
    }
}
