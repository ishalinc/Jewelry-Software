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
    public partial class frmDeletePotentialCustomer : Telerik.WinControls.UI.RadForm
    {

        private IPotentialCustomerService potcustomerService;


        public frmDeletePotentialCustomer()
        {
            InitializeComponent();
            potcustomerService = new PotentialCustomerService();
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(deletpotentialcustomer.Text != "")
            {
                this.SearchRecords();
            }
            else
                MessageBox.Show("ACC Number Required");
        }

        private void SearchRecords()
        {
           

            if (!string.IsNullOrEmpty(this.deletpotentialcustomer.Text))
            {

                // MessageBox.Show(custACC);
                // bool status = this.potentialcustomerService.GetPotentialCustomerByAcc(custACC);
                PotentialcustomerModel PotentialcustomerModel = new PotentialcustomerModel()
                {
                    ACC = this.deletpotentialcustomer.Text.Trim()
                };
                bool success = potcustomerService.GetPotentialCustomerByAcc(PotentialcustomerModel);
                if (success)
                 {
                    Helper.MsgBox("Potential Customer Deleted.", Telerik.WinControls.RadMessageIcon.Info);
                    this.deletpotentialcustomer.Focus();
                }
                 else
                 {
                    Helper.MsgBox("Invalid Customer Code.", Telerik.WinControls.RadMessageIcon.Info);
                    this.deletpotentialcustomer.Focus();
                }
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}
