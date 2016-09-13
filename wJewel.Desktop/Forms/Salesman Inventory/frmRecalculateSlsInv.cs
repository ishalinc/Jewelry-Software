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
    public partial class frmRecalculateSlsInv : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;

        private ICustomerService customerService;
        private string output_type = "Preview";
        public frmRecalculateSlsInv()
        {

            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
            this.customerService = new CustomerService();
            DataTable data = this.customerService.GetSalesmen();
            DataView dvSalesmen1 = new DataView(data);
            this.txtSalesman1.Items.Clear();
            dvSalesmen1.RowFilter = "Code <> ''";
            this.txtSalesman1.DataSource = dvSalesmen1;
            this.txtSalesman1.DisplayMember = "Code";
            this.txtSalesman1.ValueMember = "Code";
            this.txtSalesman1.SelectedIndex = -1;

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSalesman1.Text))
            {
                Helper.MsgBox("Please enter Salesman Code");
                this.txtSalesman1.Focus();
            }
            else
            {
                DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to Recaculate this Salesman Line?", "Clear Salesman Line", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string error = string.Empty;
                    if (this.salesmanService.FixSls(this.txtSalesman1.SelectedValue.ToString(), out error))
                    {
                        if (string.IsNullOrEmpty(error))
                            Helper.MsgBox("Salesman Line Fixed Successfully");
                        else
                            Helper.MsgBox(error);
                    }

                }
            }


        }




        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
