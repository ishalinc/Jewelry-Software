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
    public partial class frmMasterPassword : Telerik.WinControls.UI.RadForm
    {
       
        public bool authorized = false;
        public frmMasterPassword()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
          
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.radTextBox1.Text))
            {
                Helper.MsgBox("Please entre password");
                return;
            }
            this.authorized = (this.radTextBox1.Text == "SECRET");
            if (!this.authorized)
                Helper.MsgBox("Invalid Password");
            else
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.authorized = false;
            this.Close();
        }
    }
}
