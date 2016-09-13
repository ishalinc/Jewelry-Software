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
    public partial class frmSalesmanLog : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;
        private bool is_cancelled = true;

        public frmSalesmanLog()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
            this.radTextBox1.Text = Helper.GetNextLogNo();
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow drCust = this.salesmanService.CheckValidSalesmanLog(this.radTextBox1.Text);
            if (drCust != null)
            {
                Helper.MsgBox("Log# Already Exists.", RadMessageIcon.Info);
                this.radTextBox1.Text = string.Empty;
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
    }
}
