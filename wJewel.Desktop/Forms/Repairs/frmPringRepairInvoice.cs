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
    public partial class frmPringRepairInvoice : Telerik.WinControls.UI.RadForm
    {
        public frmPringRepairInvoice()
        {
            InitializeComponent();
        }
        public frmPringRepairInvoice(string inv_no)
        {
            InitializeComponent();
            radLabel4.Text = inv_no;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string inv_no = radLabel4.Text;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
