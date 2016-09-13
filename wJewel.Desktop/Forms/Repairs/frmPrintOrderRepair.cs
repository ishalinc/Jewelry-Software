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
    public partial class frmPrintOrderRepair : Telerik.WinControls.UI.RadForm
    {
        private IOrderRepairService orderrepairService;
        public frmPrintOrderRepair()
        {
            InitializeComponent();
            
        }
        public frmPrintOrderRepair(string REPAIR_NO)
        {
            InitializeComponent();
            repairordernumber.Text = REPAIR_NO;

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            int printenv = 0;
            //if (printenvelope.Checked)
                //printenv = 1;
            string repnumber = repairordernumber.Text;

            frmPrintOptions printoptions = new frmPrintOptions(repnumber);
            printoptions.StartPosition = FormStartPosition.CenterScreen;

            printoptions.Show();
            this.Dispose();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
           // resetorderrepairsequent();
            this.Dispose();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you sure you want to Close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    //resetorderrepairsequent();
                    break;
            }
        }
        private void ResetOrderRepairSequence()
        {
            this.orderrepairService = new OrderRepairService();
            RepairorderModel RepairorderModel = new RepairorderModel();
            int currentrepno = Convert.ToInt32(repairordernumber.Text);
            RepairorderModel repairorderModel = new RepairorderModel()
            {
                REPAIR_NO = Convert.ToString(currentrepno)
            };
            this.orderrepairService.ResetSequence(repairorderModel);

        }
    }
}
