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
    public partial class frmNewOrderRepair : Telerik.WinControls.UI.RadForm
    {

        private ICustomerService customerService;

        private IOrderRepairService orderrepairService;

        private DataRow custRow;

        private DataRow orderRow;

        private DataView dvCustomerSearch;
        public frmNewOrderRepair()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.search, 24, true);
            this.customerService = new CustomerService();
            this.orderrepairService = new OrderRepairService();
            DataTable data = this.customerService.SearchCustomers();
            dvCustomerSearch = new DataView(data);
            dvCustomerSearch.RowFilter = "1=0";
            this.LoadDataGridView(dvCustomerSearch);

            this.txtRepairNo.Text = this.orderrepairService.GetNextRepairOrder();
        }

        private void LoadDataGridView(DataView data)
        {
            // Data grid view column setting      

            radGridView1.DataSource = data;
            //radGridView1.DataMember = data.TableName;
            radGridView1.Columns[0].IsVisible = false;
            radGridView1.Columns[1].Width = this.txtCustomerCode.Width;
            radGridView1.Columns[2].Width = this.txtName.Width;
            radGridView1.Columns[3].Width = this.txtTel.Width;
            radGridView1.Columns[4].Width = this.txtEmail.Width;
            radGridView1.Columns[5].Width = this.txtAddress.Width;
            radGridView1.Columns[6].Width = this.txtState.Width;
            radGridView1.Columns[7].Width = this.txtZip.Width;

            radGridView1.Columns[1].HeaderText = "Acc";
            radGridView1.Columns[2].HeaderText = "Name";
            radGridView1.Columns[3].HeaderText = "Tel.";
            radGridView1.Columns[4].HeaderText = "Email";
            radGridView1.Columns[5].HeaderText = "Address";
            radGridView1.Columns[6].HeaderText = "State";
            radGridView1.Columns[7].HeaderText = "City";

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtCustomerCode.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtZip.Text = string.Empty;

            dvCustomerSearch.RowFilter = "1=0";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchRecords();
        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (custRow != null)
            {
                // show new customer form
                this.txtSelectedCustomerCode.Text = Convert.ToString(custRow["acc"]);
               
               
            }
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RadGridView dgv = (RadGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    string customerID = dgv.SelectedRows[0].Cells[0].Value.ToString();
                    int customerId = int.Parse(customerID);
                    this.txtSelectedCustomerCode.Text  = dgv.SelectedRows[0].Cells[1].Value.ToString();
                    custRow = this.customerService.GetCustomerById(customerId);
                }

            }
            catch (Exception ex)
            {
                //this.ShowErrorMessage(ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(this.txtSelectedCustomerCode.Text))
            {
                this.SearchRecords1();
            }
            else
            {
                Helper.MsgBox("Enter Customer Code.", Telerik.WinControls.RadMessageIcon.Info);
                this.txtSelectedCustomerCode.Focus();
            }
        }

        private void SearchRecords()
        {
            string sFilter = "1=1";

            if (!string.IsNullOrEmpty(this.txtCustomerCode.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "acc", this.txtCustomerCode.Text.Trim());
                dvCustomerSearch.RowFilter = sFilter;
                if (dvCustomerSearch.Count == 1)
                {
                    // show new customer form
                    this.Hide();
                    int custId = Convert.ToInt16(custRow["Id"]);
                    string customercode = this.txtSelectedCustomerCode.Text.Trim();
                    string ordernumber = this.txtRepairNo.Text.Trim();
                  
                    frmAddrepairorder objNewCustomer = new frmAddrepairorder(customercode, custRow, ordernumber);
                    objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                    objNewCustomer.Show();
                    this.Dispose();
                }
                else
                {
                    Helper.MsgBox("Invalid Customer Code.", Telerik.WinControls.RadMessageIcon.Info);
                    this.txtSelectedCustomerCode.Focus();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txtName.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "name", this.txtName.Text);

                if (!string.IsNullOrEmpty(this.txtTel.Text))
                    sFilter += string.Format(" AND {0} = {1}", "tel", this.txtTel.Text);

                if (!string.IsNullOrEmpty(this.txtEmail.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "email", this.txtEmail.Text);

                if (!string.IsNullOrEmpty(this.txtAddress.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "addr1", this.txtAddress.Text);

                if (!string.IsNullOrEmpty(this.txtState.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "state1", this.txtState.Text);

                if (!string.IsNullOrEmpty(this.txtZip.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "zip1", this.txtZip.Text);
                dvCustomerSearch.RowFilter = sFilter;
            }

        }

        private void SearchRecords1()
        {
            string sFilter = "1=1";

            if (!string.IsNullOrEmpty(this.txtSelectedCustomerCode.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "acc", this.txtSelectedCustomerCode.Text.Trim());
                dvCustomerSearch.RowFilter = sFilter;
                if (dvCustomerSearch.Count == 1)
                {
                    // show new customer form
                    this.Hide();
                    int custId = Convert.ToInt16(custRow["Id"]);
                    string customercode = this.txtSelectedCustomerCode.Text.Trim();
                    string ordernumber = this.txtRepairNo.Text.Trim();

                    frmAddrepairorder objNewCustomer = new frmAddrepairorder(customercode, custRow, ordernumber);
                    objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                    objNewCustomer.Show();
                    this.Dispose();
                }
                else
                {
                    Helper.MsgBox("Invalid Customer Code.", Telerik.WinControls.RadMessageIcon.Info);
                    this.txtSelectedCustomerCode.Focus();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txtName.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "name", this.txtName.Text);

                if (!string.IsNullOrEmpty(this.txtTel.Text))
                    sFilter += string.Format(" AND {0} = {1}", "tel", this.txtTel.Text);

                if (!string.IsNullOrEmpty(this.txtEmail.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "email", this.txtEmail.Text);

                if (!string.IsNullOrEmpty(this.txtAddress.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "addr1", this.txtAddress.Text);

                if (!string.IsNullOrEmpty(this.txtState.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "state1", this.txtState.Text);

                if (!string.IsNullOrEmpty(this.txtZip.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "zip1", this.txtZip.Text);
                dvCustomerSearch.RowFilter = sFilter;
            }

        }

        private void ResetRepairOrderSequence()
        {
            RepairorderModel RepairorderModel = new RepairorderModel();
            int currentrepno = Convert.ToInt32(txtRepairNo.Text) ;
            RepairorderModel repairorderModel = new RepairorderModel()
            {
                REPAIR_NO = Convert.ToString(currentrepno)
            };
            this.orderrepairService.ResetSequence(repairorderModel);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetRepairOrderSequence();
            this.Dispose();
           /* this.txtCustomerCode.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtZip.Text = string.Empty;

            dvCustomerSearch.RowFilter = "1=0";*/
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    ResetRepairOrderSequence();
                    break;
            }
        }

        private void txtCustomerCode_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCustomerCode.Text))
            {
                SearchRecords();
                if (dvCustomerSearch.Count == 0)
                    Helper.MsgBox("Invalid Customer Code.", Telerik.WinControls.RadMessageIcon.Info);
                else
                    this.btnOK.Focus();
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            this.txtCustomerCode.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtZip.Text = string.Empty;

            dvCustomerSearch.RowFilter = "1=0";
        }
    }
}
