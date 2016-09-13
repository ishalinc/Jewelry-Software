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
    public partial class frmRepairOrderInvoice : Telerik.WinControls.UI.RadForm
    {
        private IOrderRepairService orderrepairService;
        public frmRepairOrderInvoice()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.customernew, 24, true);

        }

        private void repairordernumber_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            orderrepairService = new OrderRepairService();
            DataTable data = orderrepairService.GetRepairItems(repairordernumber.Text);
            int ct = 0; 
            foreach (DataRow row in data.Rows)
            {
                ct = ct + 1;
            }
            if (ct > 0)
            {
                frmCreateRepairOrderInvoice objEditRepairOrderInvoice = new frmCreateRepairOrderInvoice(repairordernumber.Text);
                objEditRepairOrderInvoice.Show();
                this.Dispose();
            }
            else
            {
                Helper.MsgBox("Invalid Repair Number no.", RadMessageIcon.Info);
                this.repairordernumber.Text = string.Empty;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
