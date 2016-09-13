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
    public partial class frmStatusofMemo : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        /// <summary>
        /// Interface of InvoiceItemSerrvice
        /// </summary>
        /// 
        private IMemoService memoService;

        private DataRow memoRow;

        private DataRow custRow;

        private DataView dvMemoSearch;

        private string MemoNo;

        private string customerAcc;

        private string custName;

        private string output_type = "Preview";
        public frmStatusofMemo()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.memoreport, 24, true);
            this.memoService = new MemoService();
            this.dateFrom.SetToNullValue();
            this.dateTo.SetToNullValue();

            this.customerService = new CustomerService();
            DataTable data = this.memoService.SearchMemo();
            dvMemoSearch = new DataView(data);
            dvMemoSearch.RowFilter = "1=0";
            this.txtAmount1.Value = 0;
            this.txtAmount2.Value = 0;
            this.LoadDataGridView(dvMemoSearch);

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

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
            radGridView1.Columns[1].Width = this.txtMemoNo.Width;
            radGridView1.Columns[2].Width = this.txtAcc.Width;
            radGridView1.Columns[3].Width = this.txtName.Width;
            radGridView1.Columns[4].Width = this.txtTel.Width;
            radGridView1.Columns[5].Width = this.dateFrom.Width + this.dateTo.Width;
            radGridView1.Columns[6].Width = this.txtAddress.Width;
            radGridView1.Columns[7].Width = this.txtState.Width;
            radGridView1.Columns[8].Width = this.txtZip.Width;
            radGridView1.Columns[9].Width = this.txtAmount1.Width + this.txtAmount2.Width;

            radGridView1.Columns[1].HeaderText = "Memo #";
            radGridView1.Columns[2].HeaderText = "Acc";
            radGridView1.Columns[3].HeaderText = "Name";
            radGridView1.Columns[4].HeaderText = "Tel.";
            radGridView1.Columns[5].HeaderText = "Memo Date";
            radGridView1.Columns[5].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[6].HeaderText = "Address";
            radGridView1.Columns[7].HeaderText = "State";
            radGridView1.Columns[8].HeaderText = "City";
            radGridView1.Columns[9].HeaderText = "Gr. Total";
            radGridView1.Columns[9].FormatString = "{0:c}";
            radGridView1.Columns[10].IsVisible = false;
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
                    this.customerAcc = dgv.SelectedRows[0].Cells[2].Value.ToString();
                    this.MemoNo = dgv.SelectedRows[0].Cells[1].Value.ToString();
                    this.custName = dgv.SelectedRows[0].Cells[3].Value.ToString();
                    memoRow = this.memoService.GetMemoByInvNo(this.MemoNo);

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
            PrintReport();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtMemoNo.Text = string.Empty;
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

            if (dvMemoSearch != null)
                dvMemoSearch.RowFilter = "1=0";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchRecords();
        }


        private void SearchRecords()
        {
            string sFilter = "1=1";

            if (!string.IsNullOrEmpty(this.txtMemoNo.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "memo_no", this.txtMemoNo.Text);
                dvMemoSearch.RowFilter = sFilter;
                if (dvMemoSearch.Count == 1)
                {
                    //DO Nothing
                }
                else
                {
                    Helper.MsgBox("Invalid Memo #.", Telerik.WinControls.RadMessageIcon.Info);
                    this.txtMemoNo.Focus();
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
                    fromDate = Convert.ToDateTime(dateFrom.Value);
                else
                    fromDate = new DateTime(1900, 1, 1);

                DateTime? toDate;
                if (!string.IsNullOrEmpty(dateTo.Text.Trim()))
                    toDate = Convert.ToDateTime(dateTo.Value);
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

                dvMemoSearch.RowFilter = sFilter;
                if (dvMemoSearch.Count == 0)
                    Helper.MsgBox("No Records Found", Telerik.WinControls.RadMessageIcon.Info);
            }



        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (memoRow == null)
            {
                Helper.MsgBox("Memo Not Selected!. Please Select Memo", Telerik.WinControls.RadMessageIcon.Exclamation);
                return;
            }
            else
            {
                PrintReport();
            }


        }



        private void txtInvoiceNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMemoNo.Text))
            {
                SearchRecords();
                if (dvMemoSearch.Count == 0)
                    Helper.MsgBox("Invalid Memo#", Telerik.WinControls.RadMessageIcon.Info);
                else
                    PrintReport();

            }

            
        }

        private void txtAcc_Validated(object sender, EventArgs e)
        {

        }

        private void frmReprintInvoice_KeyDown(object sender, KeyEventArgs e)
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

        private void txtAmount1_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtAmount1.Value) > 0 && Convert.ToDecimal(this.txtAmount2.Value) == 0)
                this.txtAmount2.Value = this.txtAmount1.Value;
        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            string result = null;
            foreach (Control control in this.radGroupBox1.Controls)
            {
                if (control is RadRadioButton)
                {
                    RadRadioButton radio = control as RadRadioButton;
                    if (radio.IsChecked)
                    {
                        result = radio.Text;
                    }
                }
            }
            bool isvisible = false;
            switch (result)
            {
                case "Preview":
                    this.output_type = result;
                    break;
                case "Print":
                    this.output_type = result;
                    break;
                case "Email":
                    this.output_type = result;
                    break;
                default:
                    break;

            }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {

            PrintReport();


        }

        private void PrintReport()
        {
            if (memoRow == null)
            {
                Helper.MsgBox("Memo Not Selected!. Please Select Memo", Telerik.WinControls.RadMessageIcon.Exclamation);
                return;
            }
            DataTable dtMemoStatement = this.memoService.GetMemoStatement(this.MemoNo);
            if (dtMemoStatement == null)
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                return;
            }
            if (dtMemoStatement.Rows.Count > 0)
            {
                string title = string.Format("Memo No. : {0} PO#: {1} Cust.: {2}", memoRow["memo_no"].ToString(), memoRow["pon"].ToString(), this.custName);
                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dtMemoStatement;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];

                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpTitle";
                reportParameterCollection[0].Values.Add(title);

                Helper.PrintReport(objReportPrinting, "Status of Memo", "IshalInc.wJewel.Desktop.Forms.Reports.rptMemoStatus.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, string.Empty);
                
            }
            else
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
            }

        }

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnPrint.Visible = this.radGridView1.RowCount > 0;
        }
    }
}
