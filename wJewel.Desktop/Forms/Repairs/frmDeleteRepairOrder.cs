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
    public partial class frmDeleteRepairOrder : Telerik.WinControls.UI.RadForm
    {

        private ICustomerService customerService;

        private IOrderRepairService orderrepairService;

        private DataRow custRow;

        private DataRow orderRow;

        private DataView dvCustomerSearch;
        public frmDeleteRepairOrder()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string Rep_number = repairordernumber.Text;
            if (Rep_number == string.Empty)
            {
                MessageBox.Show("Enter Valid Invoice Number");
                return;
            }
            else
            {
                orderrepairService = new OrderRepairService();
                DataTable data = orderrepairService.GetAllRepairTableDataForInvoice(Rep_number);
                if (data.Rows.Count > 0)
                {
                    orderrepairService.DeleteRepairOrders(Rep_number);
                    MessageBox.Show("Repair Order Deleted Successfully.");
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid Repair Order Number");
                    return;
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
