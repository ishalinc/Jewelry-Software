using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmEnterRepairORdernumber : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;

        private IOrderRepairService orderrepairService;

        private DataRow custRow;

        private DataRow orderRow;

        private DataView dvCustomerSearch;

        public frmEnterRepairORdernumber()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Enter");
            if(repairordernumber.Text != "")
            {
                this.orderrepairService = new OrderRepairService();
                DataTable data = orderrepairService.GetRepairItems(repairordernumber.Text);
                int ct = 0;
                foreach (DataRow row in data.Rows)
                {
                   ct = ct + 1;
                }
                if(ct >0)
                {
                    
                    frmEditRepairOrder objEditRepairOrder = new frmEditRepairOrder(repairordernumber.Text);
                    objEditRepairOrder.StartPosition = FormStartPosition.CenterScreen;
                    objEditRepairOrder.Show();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid Repair Order Number");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Enter Valid Repair Order Number");
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /*DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the changes?", "Add / Edit Customer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {*/
                this.Close();
            //}
        }
    }
}
