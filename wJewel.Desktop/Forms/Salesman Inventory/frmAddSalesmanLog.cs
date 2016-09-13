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
    public partial class frmAddSalesmanLog : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;
        private bool is_cancelled = true;
        private string logno;
        public frmAddSalesmanLog()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
            this.logno = Helper.GetNextLogNo();
            this.radTextBox1.Text = this.logno;
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataTable dtCust = this.salesmanService.CheckValidSalesmanLog(this.radTextBox1.Text);

            DataRow drCust = null;
            if (dtCust != null)
            {
                drCust = dtCust.Rows[0];
            }
            if (drCust != null)
            {
                Helper.MsgBox("Log# Already Exists.", RadMessageIcon.Info);
                this.radTextBox1.Text = this.logno;
            }
            else
            {
                // hide main form
                this.Hide();

                // show billingaccount form
                frmAddSalesmanInventory objAddSalesmanInventory = new frmAddSalesmanInventory(this.radTextBox1.Text);
                objAddSalesmanInventory.StartPosition = FormStartPosition.CenterScreen;
                objAddSalesmanInventory.MdiParent = this.MdiParent;
                objAddSalesmanInventory.Show();
                
                // close application
                this.Close();
            }
        }

        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.is_cancelled)
            {
                int t_logno;
                if (int.TryParse(this.radTextBox1.Text, out t_logno))
                {
                    Helper.CheckSISequence(t_logno);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.is_cancelled = true;
            this.Close();
        }

        private void radTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(this.radTextBox1.Text) > Convert.ToInt32(this.logno))
            {
                Helper.MsgBox("Can not Skip Log #");
                this.radTextBox1.Text = this.logno;
                e.Cancel = true;
            }
        }

        private void radTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
