using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmSearchInvoice : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        /// <summary>
        /// Interface of InvoiceItemSerrvice
        /// </summary>
        /// 
        private IInvoiceService invoiceService;

        private DataRow invoiceRow;

        private DataRow custRow;

        private DataView dvInvoiceSearch;

        private string InvoiceNo;

        private int customerId;

        private string output_type = "Preview";

       
        public frmSearchInvoice()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.search, 24, true);
            this.invoiceService = new InvoiceService();
            this.dateFrom.SetToNullValue();
            this.dateTo.SetToNullValue();

            this.customerService = new CustomerService();
            DataTable data = this.invoiceService.SearchInvoice();
            dvInvoiceSearch = new DataView(data);
            dvInvoiceSearch.RowFilter = "1=0";
            this.txtAmount1.Value = 0;
            this.txtAmount2.Value = 0;
            
            this.LoadDataGridView(dvInvoiceSearch);

            this.btnEdit.ButtonElement.ForeColor = Color.Green;
            this.btnEdit.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

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
            radGridView1.Columns[1].Width = this.txtInvoiceNo.Width;
            radGridView1.Columns[2].Width = this.txtAcc.Width;
            radGridView1.Columns[3].Width = this.txtName.Width;
            radGridView1.Columns[4].Width = this.txtTel.Width;
            radGridView1.Columns[5].Width = this.dateFrom.Width + this.dateTo.Width;
            radGridView1.Columns[6].Width = this.txtAddress.Width;
            radGridView1.Columns[7].Width = this.txtState.Width;
            radGridView1.Columns[8].Width = this.txtZip.Width;
            radGridView1.Columns[9].Width = this.txtAmount1.Width + this.txtAmount2.Width;

            radGridView1.Columns[1].HeaderText = "Invoice #";
            radGridView1.Columns[2].HeaderText = "Acc";
            radGridView1.Columns[3].HeaderText = "Name";
            radGridView1.Columns[4].HeaderText = "Tel.";
            radGridView1.Columns[5].HeaderText = "Invoice Date";
            radGridView1.Columns[5].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
           radGridView1.Columns[6].HeaderText = "Address";
            radGridView1.Columns[7].HeaderText = "State";
            radGridView1.Columns[8].HeaderText = "City";
            radGridView1.Columns[9].HeaderText = "Gr. Total";
            radGridView1.Columns[9].FormatString = "{0:c}";

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
                    this.InvoiceNo = dgv.SelectedRows[0].Cells[1].Value.ToString();
                    this.customerId = int.Parse(customerID);
                    custRow = this.customerService.GetCustomerById(this.customerId);
                    invoiceRow = this.invoiceService.GetInvoiceByInvNo(this.InvoiceNo);
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
            if (invoiceRow == null)
            {
                Helper.MsgBox("Invoice Not Selected!. Please Select Invoice", Telerik.WinControls.RadMessageIcon.Exclamation);
                return;
            }
            // show new customer form
            this.Hide();
           

            frmInvoice objNewCustomer = new frmInvoice(invoiceRow["acc"].ToString(), custRow["bill_acc"].ToString(), invoiceRow,custRow, this.customerId, InvoiceNo, true);
            objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
            objNewCustomer.Show();
            this.Dispose();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtAcc.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.dateFrom.SetToNullValue();
            this.dateTo.SetToNullValue();
            this.txtAddress.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtZip.Text = string.Empty;
            this.txtAmount1.Value = 0;
            this.txtAmount2.Value = 0;

            if (dvInvoiceSearch != null)
                   dvInvoiceSearch.RowFilter = "1=0";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRecords();
        }

        private void SearchRecords()
        {
            string sFilter = "1=1";
            string invoicenoText = this.txtInvoiceNo.Text;
            if (!string.IsNullOrEmpty(invoicenoText))
            {
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "inv_no", invoicenoText);
                dvInvoiceSearch.RowFilter = sFilter;
                if (dvInvoiceSearch.Count == 1)
                {
                   
                    this.Visible = false;
                    this.Hide();
                    frmInvoice objNewCustomer = new frmInvoice(invoiceRow["acc"].ToString(), custRow["bill_acc"].ToString(), invoiceRow, custRow, this.customerId, InvoiceNo, true);
                    objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
                    objNewCustomer.Show();
                    this.Dispose();

                }
                else
                {
                    Helper.MsgBox("Invalid Invoice #.", Telerik.WinControls.RadMessageIcon.Info);
                    //this.txtInvoiceNo.Focus();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txtAcc.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "acc", this.txtAcc.Text);

                if (!string.IsNullOrEmpty(this.txtName.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "name", this.txtName.Text);

                if (!string.IsNullOrEmpty(this.txtTel.Text))
                    sFilter += string.Format(" AND {0} = {1}", "tel", this.txtTel.Text);

                DateTime? fromDate;
                if (!string.IsNullOrEmpty(dateFrom.Text.Trim()))
                    fromDate = Convert.ToDateTime(dateFrom.Text);
                else
                    fromDate = new DateTime(1900, 1, 1);

                DateTime? toDate;
                if (!string.IsNullOrEmpty(dateTo.Text.Trim()))
                    toDate = Convert.ToDateTime(dateTo.Text);
                else
                    toDate = new DateTime(2099, 12, 31); ;



                sFilter += string.Format(" And ({0} >= '{1:MM/dd/yyyy}' ", "date", fromDate);
                sFilter += string.Format(" And {0} <= '{1:MM/dd/yyyy}' )", "date", toDate);

                if (!string.IsNullOrEmpty(this.txtAddress.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "addr1", this.txtAddress.Text);

                if (!string.IsNullOrEmpty(this.txtState.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "state1", this.txtState.Text);

                if (!string.IsNullOrEmpty(this.txtZip.Text))
                    sFilter += string.Format(" AND {0} LIKE '%{1}%'", "zip1", this.txtZip.Text);

                if (Convert.ToDecimal(this.txtAmount2.Value) > 0)
                    sFilter += string.Format(" AND (gr_total >= {0} AND gr_total <= {1})", string.Format("{0:0.00}", Convert.ToDecimal(this.txtAmount1.Value)), string.Format("{0:0.00}", Convert.ToDecimal(this.txtAmount2.Value)));
               
                dvInvoiceSearch.RowFilter = sFilter;
            }
            

           
        }
        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (invoiceRow == null)
            {
                Helper.MsgBox("Invoice Not Selected!. Please Select Invoice", Telerik.WinControls.RadMessageIcon.Exclamation);
                return;
            }
            // show new customer form
            this.Hide();
           

            frmInvoice objNewCustomer = new frmInvoice(invoiceRow["acc"].ToString(), custRow["bill_acc"].ToString(), invoiceRow,custRow, this.customerId, InvoiceNo, true);
            objNewCustomer.StartPosition = FormStartPosition.CenterScreen;
            objNewCustomer.Show();
            this.Dispose();
        }


        private void txtInvoiceNo_Validated(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(this.txtInvoiceNo.Text))
            {
                
                SearchRecords();

            }
        }

        private void txtAmount1_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtAmount1.Value) > 0 && Convert.ToDecimal(this.txtAmount2.Value) == 0)
                this.txtAmount2.Value = this.txtAmount1.Value;
        }

        private void frmSearchInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (this.ActiveControl != null)
                {

                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    e.Handled = true;
                }


            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
