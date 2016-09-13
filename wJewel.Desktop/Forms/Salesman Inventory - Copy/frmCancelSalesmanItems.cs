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
    public partial class frmCancelSalesmanItems : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;
      

        public frmCancelSalesmanItems()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow drCust = this.salesmanService.CheckValidSalesmanLog(this.radTextBox1.Text);
            if (drCust == null)
            {
                Helper.MsgBox("Log# Doesn't Exist.", RadMessageIcon.Info);
                this.radTextBox1.Text = string.Empty;
                return;
            }
            else
            {
               if (Convert.ToDecimal(string.IsNullOrEmpty(drCust["apmno"].ToString()) ? "0" : drCust["apmno"]) > 0)
                {
                    Helper.MsgBox("Can Not Cancel, This Log# Generated From Apmemo.", RadMessageIcon.Info);
                    this.radTextBox1.Text = string.Empty;
                    return;
                }
                 if (DateTime.Now.Date != Convert.ToDateTime(drCust["date"]).Date)
                {
                    frmMasterPassword objMasterPwd = new frmMasterPassword();
                    objMasterPwd.StartPosition = FormStartPosition.CenterScreen;
                    objMasterPwd.ShowDialog();
                    if (!objMasterPwd.authorized)
                        return;
                }
                DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to delete the log?", "Delete Salesman Log- Cancel Items", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string error = DeleteLog();
                    if (string.IsNullOrEmpty(error))
                        Helper.MsgBox("Items Cancelled Successfully");
                    else
                        Helper.MsgBox(error);


                }
            }
        }


        private string DeleteLog()
        {
            string error = string.Empty;
            this.salesmanService.CancelSalesmanItems(this.radTextBox1.Text, out error);
            return error;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCancelSalesmanItems_Load(object sender, EventArgs e)
        {

        }
    }
}
