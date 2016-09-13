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
    public partial class frmEditRepairInvoice : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;

        private IOrderRepairService orderrepairService;

        private DataRow custRow;

        private DataRow orderRow;

        private DataView dvCustomerSearch;
        public frmEditRepairInvoice()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string inv_no = repairordernumber.Text;
            MessageBox.Show(inv_no);
            orderrepairService = new OrderRepairService();
            string pon = orderrepairService.CheckInvoiceNumberBasedOnInvoiceNumber(inv_no);
          
            if(pon == string.Empty)
            {
                MessageBox.Show("Invalid Invoice Number");
            }
            else
            {
                frmEditRepairOrderInvoiceBasedOnInvoceId objrepairinvoice = new frmEditRepairOrderInvoiceBasedOnInvoceId(inv_no);
                objrepairinvoice.Show();
                this.Dispose();
            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
