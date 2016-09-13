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
    public partial class frmSearchPotentialCustomer : Telerik.WinControls.UI.RadForm
    {

        //private ICustomerService customerService;
        private IPotentialCustomerService potentialcustomerService;

        private DataRow custRow;

        private DataView dvCustomerSearch;
        public frmSearchPotentialCustomer()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.search, 24, true);
            this.potentialcustomerService = new PotentialCustomerService();
            DataTable data = this.potentialcustomerService.SearchPotentialCustomers();
            dvCustomerSearch = new DataView(data);
            dvCustomerSearch.RowFilter = "1=0";
            this.LoadDataGridView(dvCustomerSearch);
        }
        private void LoadDataGridView(DataView data)
        {
            // Data grid view column setting      

            radGridView1.DataSource = data;
            //radGridView1.DataMember = data.TableName;
            radGridView1.Columns[0].IsVisible = false;
            radGridView1.Columns[1].Width = this.txtAcc.Width;
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
        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtAcc.Text);
            this.SearchRecords();
        }
        private void SearchRecords()
        {
            string sFilter = "1=1";

            if (!string.IsNullOrEmpty(this.txtAcc.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "acc", "1234");
                dvCustomerSearch.RowFilter = sFilter;
                if (dvCustomerSearch.Count == 1)
                {
                    // show new customer form
                    this.Hide();
                    // int custId = Convert.ToInt16(custRow["Id"]);
                    string custACC = Convert.ToString(custRow["ACC"]);
                    //int custId = 0;
                    frmAddpotenialCustomer objNewCustomer = new frmAddpotenialCustomer(custRow["acc"].ToString(), custRow, custACC);
                    objNewCustomer.StartPosition = FormStartPosition.CenterScreen;

                    objNewCustomer.Show();
                    this.Dispose();
                }
                else
                {
                    Helper.MsgBox("Invalid Customer Code.", Telerik.WinControls.RadMessageIcon.Info);
                    this.txtAcc.Focus();
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

        private void radGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            RadGridView dgv = (RadGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    string customerID = dgv.SelectedRows[0].Cells[1].Value.ToString();
                   
                    custRow = this.potentialcustomerService.GetPotentialCustomerById(customerID);
                }

            }
            catch (Exception ex)
            {
                //this.ShowErrorMessage(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the changes?", "Add / Edit Customer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtAcc.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtZip.Text = string.Empty;

            dvCustomerSearch.RowFilter = "1=0";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (custRow != null)
            {
                // show new customer form
                this.Hide();
                string custACC = Convert.ToString(custRow["ACC"]);
                frmAddpotenialCustomer objNewCustomer = new frmAddpotenialCustomer(custRow["acc"].ToString(), custRow, custACC);
                objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                objNewCustomer.Show();
                this.Dispose();
            }
        }

        private void frmSearchPotentialCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
