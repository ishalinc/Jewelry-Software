using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmInvoiceStatus : Telerik.WinControls.UI.RadForm
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

        private string customerAcc;

        private string output_type = "Preview";
        public frmInvoiceStatus()
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
                    this.customerAcc = dgv.SelectedRows[0].Cells[2].Value.ToString();
                    this.InvoiceNo = dgv.SelectedRows[0].Cells[1].Value.ToString();
                   
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

            this.invoiceService = new InvoiceService();
            DataTable data = this.invoiceService.GetRTVRcvables(this.InvoiceNo);

            DataView dvRTVRcvables = new DataView(data);

            if (dvRTVRcvables.Count > 0)
            {

                string custemail = this.customerService.GetEmail(this.customerAcc);

                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvRTVRcvables;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[6];
                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpInvoiceNo";
                reportParameterCollection[0].Values.Add(dvRTVRcvables[0]["inv_no"].ToString());


                reportParameterCollection[1] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[1].Name = "rpBacc";
                reportParameterCollection[1].Values.Add(dvRTVRcvables[0]["bacc"].ToString());



                reportParameterCollection[2] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[2].Name = "rpBName";
                reportParameterCollection[2].Values.Add(dvRTVRcvables[0]["bname"].ToString());

                reportParameterCollection[3] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[3].Name = "rpAmount";
                reportParameterCollection[3].Values.Add(string.Format("{0:c}", dvRTVRcvables[0]["invoice_amt"].ToString()));

                reportParameterCollection[4] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[4].Name = "rpOpenAmount";
                reportParameterCollection[4].Values.Add(string.Format("{0:c}",dvRTVRcvables[0]["open_amt"].ToString()));


                reportParameterCollection[5] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[5].Name = "rpDate";
                reportParameterCollection[5].Values.Add(dvRTVRcvables[0]["inv_date"].ToString());

                Helper.PrintReport(objReportPrinting, "Invoice Status", "IshalInc.wJewel.Desktop.Forms.Reports.rptInvoiceStatus.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

               
            }
            else
            {
                Helper.MsgBox("No records found", Telerik.WinControls.RadMessageIcon.Info);
            }
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

            if (!string.IsNullOrEmpty(this.txtInvoiceNo.Text))
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "inv_no", this.txtInvoiceNo.Text);

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
        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (invoiceRow == null)
            {
                Helper.MsgBox("Invoice Not Selected!. Please Select Invoice", Telerik.WinControls.RadMessageIcon.Exclamation);
                return;
            }

           
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
           
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

        private void txtInvoiceNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtInvoiceNo.Text))
            {
                SearchRecords();
                if (dvInvoiceSearch.Count == 0)
                    Helper.MsgBox("Invalid Invoice #.", Telerik.WinControls.RadMessageIcon.Info);
                else
                    this.btnPrint.Focus();
            }
        }

        private void txtAmount1_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtAmount1.Value) > 0 && Convert.ToDecimal(this.txtAmount2.Value) == 0)
                this.txtAmount2.Value = this.txtAmount1.Value;
        }

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnPrint.Visible = this.radGridView1.RowCount > 0;
        }
    }
}
