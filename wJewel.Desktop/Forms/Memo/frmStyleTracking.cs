using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using Telerik.WinControls;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;
using Telerik.WinControls.UI.Localization;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmStyleTracking : Telerik.WinControls.UI.RadForm
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

        private DataRow invoiceRow;

        private DataRow custRow;

        private DataView dvStyleTracking;

        private string InvoiceNo;

        private string customerAcc;

        private string output_type = "Preview";

        private string returnstyle = string.Empty;
        private bool isbar= false;
        private string piece = "Y";

        public frmStyleTracking()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.styletracking, 24, true);
            this.memoService = new MemoService();
            this.dateFrom.SetToNullValue();
            this.dateTo.SetToNullValue();
            radGridView2.ColumnCount = 1;
            this.customerService = new CustomerService();

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }

        // <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView()
        {

            string fromDate;
            if (!string.IsNullOrEmpty(dateFrom.Text.Trim()))
                fromDate = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateFrom.Value));
            else
                fromDate = string.Format("{0:yyyy-MM-dd}", new DateTime(1900, 1, 1));

            string toDate;
            if (!string.IsNullOrEmpty(dateTo.Text.Trim()))
                toDate = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTo.Value));
            else
                toDate = string.Format("{0:yyyy-MM-dd}", new DateTime(2099, 12, 31));

            // Data grid view column setting      
            radGridView1.DataSource = "";
            string styles = string.Empty;
            if (radGridView2.Rows.Count > 0)
            {
                foreach (GridViewDataRowInfo row in radGridView2.Rows)
                {
                    styles += !string.IsNullOrEmpty(row.Cells[0].Value.ToString()) ? string.Format("{0},", row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "") : "";
                }
                styles = styles.Trim(',');
                
            }
            else
            {
                if (this.IsLoaded)
                {
                    Helper.MsgBox("Please Enter Styles.", Telerik.WinControls.RadMessageIcon.Info);
                    return;
                }
            }


            int memoValue = radOpenMemo.IsChecked ? 0 : radAllMemo.IsChecked ? 1 : 2;
            if (chkSummary.Checked)
            {
                DataTable data = this.memoService.GetStyleTrackingSummaryData(styles,this.chkInvoices.Checked, memoValue, fromDate,toDate);
                dvStyleTracking = new DataView(data);
            }   
            else
            {
                DataTable data = this.memoService.GetStyleTrackingData(styles, this.chkInvoices.Checked, memoValue, fromDate, toDate);
                dvStyleTracking = new DataView(data);
            }
            //dvStyleTracking.RowFilter = "1=0";
            radGridView1.DataSource = dvStyleTracking;
            //radGridView1.DataMember = data.TableName;
            radGridView1.Columns[0].Width = 50;
            radGridView1.Columns[1].Width = 50;
            radGridView1.Columns[2].Width = 50;
            radGridView1.Columns[3].Width = 50;
            radGridView1.Columns[4].Width = 50;
            radGridView1.Columns[5].Width = 50;
            radGridView1.Columns[6].Width = 50;
            radGridView1.Columns[7].Width = 50;
            radGridView1.Columns[8].Width = 50;
           

            radGridView1.Columns[0].HeaderText = "Cust. Code #";
            radGridView1.Columns[1].HeaderText = "Name";
        
            radGridView1.Columns[2].HeaderText = "Invoice #";
            radGridView1.Columns[3].HeaderText = "Style #";
            radGridView1.Columns[4].HeaderText = "Qty";
            radGridView1.Columns[4].FormatString = "{0:N}";
            radGridView1.Columns[5].HeaderText = "Open";
            radGridView1.Columns[5].FormatString = "{0:N}";
            radGridView1.Columns[6].HeaderText = "Date";
            radGridView1.Columns[6].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
           

            radGridView1.Columns[7].HeaderText = "Price";
            radGridView1.Columns[7].FormatString = "{0:c}";

            radGridView1.Columns[8].HeaderText = "Deduction";
            radGridView1.Columns[8].FormatString = "{0:c}";
            radGridView1.Columns[5].IsVisible = false;



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
            if (dvStyleTracking == null)
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                return;
            }
            if (dvStyleTracking.Count > 0)
            {
                
                if (this.radGridView1.SortDescriptors.Count != 0)
                dvStyleTracking.Sort = this.radGridView1.SortDescriptors.ToString();

                string custemail = string.Empty;
                
             

                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvStyleTracking;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[2];

                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpTitle";
                reportParameterCollection[0].Values.Add("");

                reportParameterCollection[1] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[1].Name = "rpSummary";
                reportParameterCollection[1].Values.Add(this.chkSummary.Checked ? "1" : "0");

                Helper.PrintReport(objReportPrinting, "Style Tracking", "IshalInc.wJewel.Desktop.Forms.Reports.rptStyleTracking.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

             
            }
            else
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtAcc1.Text = string.Empty;
            this.txtAcc2.Text = string.Empty;

            this.dateFrom.SetToNullValue();
            this.dateTo.SetToNullValue();

            if (dvStyleTracking != null)
            dvStyleTracking.RowFilter = "1=0";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchRecords();
            
        }



        private void SearchRecords()
        {
            LoadDataGridView();
            if (dvStyleTracking == null)
                return;
            string sFilter = "1=1";
            string acc1 = !string.IsNullOrEmpty(this.txtAcc1.Text)?  this.txtAcc1.Text :"0";
            string acc2 = !string.IsNullOrEmpty(this.txtAcc1.Text) ? this.txtAcc2.Text : "ZZ";

            sFilter += string.Format(" AND (ACC >= '{0}' AND ACC <= '{1}')", acc1,acc2);

            dvStyleTracking.RowFilter = sFilter;
            if (dvStyleTracking.Count == 0)
            {
                Helper.MsgBox("No Records Found", Telerik.WinControls.RadMessageIcon.Info);
            }
            this.btnPrint.Enabled = true;
            
        }
        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
           

           
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

      
        private void txtAcc1_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtAcc1.Text) && string.IsNullOrEmpty(this.txtAcc2.Text))
            {
                this.txtAcc2.Text = this.txtAcc1.Text;
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtAcc1.Text = "0";
            this.txtAcc2.Text = "ZZ";
        }

        private void radGridView2_CellValidating(object sender, CellValidatingEventArgs e)
        {
           
            if (e.ColumnIndex == 0 && radGridView2.CurrentRow != null)
            {
                var cell = e.Row.Cells[e.ColumnIndex];
                var currentRow = radGridView2.CurrentRow;
                if (e.Value != null)
                {
                    returnstyle = "";
                    if (!Helper.CheckStyle(e.Value.ToString(),out returnstyle,out isbar,out piece))
                    {
                        cell.ErrorText = "Invalid Style";
                        currentRow.ErrorText = "Invalid Style";
                        e.Cancel = true;
                        Helper.MsgBox("Invalid Style", Telerik.WinControls.RadMessageIcon.Error);
                    }
                    else
                    {
                      
                      
                        cell.ErrorText = string.Empty;
                        currentRow.ErrorText = string.Empty;
                        e.Cancel = false;
                    }
                }
                else
                {
                    cell.ErrorText = string.Empty;
                    currentRow.ErrorText = string.Empty;
                    e.Cancel = false;
                }
            }
        }

        private void radGridView2_CellValidated(object sender, CellValidatedEventArgs e)
        {
            if (e.ColumnIndex == 0 && radGridView2.CurrentRow != null)
            {
                radGridView2.CurrentCell.Value = returnstyle;
                returnstyle = string.Empty;
            }
        }

        private void radGridView2_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            
        }

        private void radGridView2_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            
        }

        private void chkSummary_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            /*
            if ((sender as RadCheckBox).Checked)
            {
                foreach (RadCheckBox c in radGroupBox2.Controls.OfType<RadCheckBox>())
                {
                    if (c != (sender as RadCheckBox))
                    {
                        c.Checked = false;
                        this.btnPrint.Enabled = false;
                    }
                }
            }*/
        }

        private void chkAllCustomers_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtAcc1.ReadOnly = this.chkAllCustomers.Checked;
            this.txtAcc2.ReadOnly = this.chkAllCustomers.Checked;
            if (this.chkAllCustomers.Checked)
            {
                this.txtAcc1.Text = "0";
                this.txtAcc2.Text = "ZZ";
            }
        }

        private void chkAllDates_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.dateFrom.ReadOnly = this.chkAllDates.Checked;
            this.dateTo.ReadOnly = this.chkAllDates.Checked;
            this.dateTo.ReadOnly = this.chkAllDates.Checked;
            if (this.chkAllDates.Checked)
            {
                this.dateFrom.Value = new DateTime(1900, 1, 1);
                this.dateTo.Value = new DateTime(2099, 12, 31);
            }
        }

        private void frmStyleTracking_Load(object sender, EventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnPrint.Visible = this.radGridView1.RowCount > 0;
        }
    }

}
