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
    public partial class frmSearchCustomer : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        private DataRow custRow;

        private DataView dvCustomerSearch;
        public frmSearchCustomer()
        {
            InitializeComponent();
            this.btnEdit.ButtonElement.ForeColor = Color.Green;
//            this.btnEdit.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
//            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.search, 24, true);
            this.customerService = new CustomerService();
            DataTable data = this.customerService.SearchCustomers();
            dvCustomerSearch = new DataView(data);
            dvCustomerSearch.RowFilter = "1=0";
            this.LoadDataGridView(dvCustomerSearch);
            this.txtAcc.Select();
        }

        // <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
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

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    custRow = this.customerService.GetCustomerById(customerId);
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
            if (custRow != null)
            {
                // show new customer form
                this.Hide();
                int custId = Convert.ToInt16(custRow["Id"]);
                frmNewCustomer objNewCustomer = new frmNewCustomer(custRow["acc"].ToString(), custRow["bill_acc"].ToString(), custRow, custId);
                objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                objNewCustomer.Show();
                this.Dispose();
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

        private void SearchRecords()
        {
            string sFilter = "1=1";

            if (!string.IsNullOrEmpty(this.txtAcc.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "acc", this.txtAcc.Text.Trim());
                dvCustomerSearch.RowFilter = sFilter;
                if (dvCustomerSearch.Count == 1)
                {
                    // show new customer form
                    this.Hide();
                    int custId = Convert.ToInt16(custRow["Id"]);
                    frmNewCustomer objNewCustomer = new frmNewCustomer(custRow["acc"].ToString(), custRow["bill_acc"].ToString(), custRow, custId);
                   
                    objNewCustomer.StartPosition = FormStartPosition.CenterParent;
                  
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
        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchRecords();
        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (custRow != null)
            {
                // show new customer form
                this.Hide();
                int custId = Convert.ToInt16(custRow["Id"]);
                frmNewCustomer objNewCustomer = new frmNewCustomer(custRow["acc"].ToString(), custRow["bill_acc"].ToString(), custRow, custId);
                objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                objNewCustomer.Show();
                this.Dispose();
            }
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAcc_Validated(object sender, EventArgs e)
        {
            SearchRecords();
        }

        private void frmSearchCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
