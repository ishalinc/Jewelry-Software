using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;
using Telerik.WinControls.UI.Localization;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmStatementofMemo : Telerik.WinControls.UI.RadForm
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

        private DataView dvStatementofMemo;

        private string InvoiceNo;

        private string customerAcc;

        private string output_type = "Preview";

        private decimal ccrda, ccrdb, ccrdc;

        public frmStatementofMemo()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.statementofmemo, 24, true);
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

          
            DataTable data = this.memoService.GetStatementofMemoData(styles, false, fromDate, toDate,out ccrda, out ccrdb, out ccrdc);
            dvStatementofMemo = new DataView(data);

            //dvStyleTracking.RowFilter = "1=0";
            radGridView1.DataSource = dvStatementofMemo;
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
            radGridView1.Columns[9].Width = 50;


            radGridView1.Columns[0].HeaderText = "Memo #";
            radGridView1.Columns[1].HeaderText = "Acc";
            radGridView1.Columns[2].HeaderText = "Name";
            radGridView1.Columns[3].HeaderText = "Date";
            radGridView1.Columns[3].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].HeaderText = "Charge";
            radGridView1.Columns[4].FormatString = "{0:C}";
            radGridView1.Columns[5].HeaderText = "SFM";
            radGridView1.Columns[5].FormatString = "{0:c}";
            radGridView1.Columns[6].HeaderText = "Credit";
            radGridView1.Columns[6].FormatString = "{0:c}";
            radGridView1.Columns[7].HeaderText = "Balance";
            radGridView1.Columns[7].FormatString = "{0:c}";

            radGridView1.Columns[8].IsVisible = false;
            radGridView1.Columns[9].IsVisible = false;
            radGridView1.Columns[10].IsVisible = false;
            radGridView1.Columns[11].IsVisible = false;
            radGridView1.Columns[12].IsVisible = false;
            








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
            if (this.radGridView1.RowCount == 0)
            SearchRecords();

            if (dvStatementofMemo != null)
            {
                if (dvStatementofMemo.Count > 0)
                {



                    if (this.radGridView1.SortDescriptors.Count != 0)
                        dvStatementofMemo.Sort = this.radGridView1.SortDescriptors.ToString();

                    string custemail = string.Empty;



                    ReportPrinting objReportPrinting = new ReportPrinting();
                    Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                    Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                    reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSourceCollection[0].Name = "DataSet1";
                    reportDataSourceCollection[0].Value = dvStatementofMemo;

                    reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[4];

                    reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[0].Name = "rpTitle";
                    reportParameterCollection[0].Values.Add("");

                    reportParameterCollection[1] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[1].Name = "rpccrda";
                    reportParameterCollection[1].Values.Add(ccrda.ToString());

                    reportParameterCollection[2] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[2].Name = "rpccrdb";
                    reportParameterCollection[2].Values.Add(ccrdb.ToString());

                    reportParameterCollection[3] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[3].Name = "rpccrdc";
                    reportParameterCollection[3].Values.Add(ccrdc.ToString());


                    Helper.PrintReport(objReportPrinting, "Statement of Memo", "IshalInc.wJewel.Desktop.Forms.Reports.rptStatementofMemo.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

                }
                else
                {
                    Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                }
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
            this.txtCountry.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtSalesman.Text = string.Empty;
            this.dateFrom.SetToNullValue();
            this.dateTo.SetToNullValue();

            if (dvStatementofMemo != null)
                dvStatementofMemo.RowFilter = "1=0";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchRecords();
            
        }



        private void SearchRecords()
        {
            LoadDataGridView();
            if (dvStatementofMemo == null)
                return;
            string sFilter = "1=1";
            string acc1 = !string.IsNullOrEmpty(this.txtAcc1.Text)?  this.txtAcc1.Text :"0";
            string acc2 = !string.IsNullOrEmpty(this.txtAcc1.Text) ? this.txtAcc2.Text : "ZZ";

            sFilter += string.Format(" AND (ACC >= '{0}' AND ACC <= '{1}')", acc1,acc2);

            if (!string.IsNullOrEmpty(this.txtState.Text))
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "state", this.txtState.Text);

            if (!string.IsNullOrEmpty(this.txtCountry.Text))
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "country", this.txtCountry.Text);

            if (!string.IsNullOrEmpty(this.txtSalesman.Text))
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "salesman", this.txtSalesman.Text);

            if (chkOpenMemoOnly.Checked)
                sFilter += string.Format(" AND Balance > 0 ");

            dvStatementofMemo.RowFilter = sFilter;
            if (dvStatementofMemo.Count == 0)
            {
                Helper.MsgBox("No Records Found", Telerik.WinControls.RadMessageIcon.Info);
                this.btnPrint.Enabled = false;
                return;
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
                   
                    if (!Helper.CheckMemo(e.Value.ToString()))
                    {
                        cell.ErrorText = "Invalid Memo";
                        currentRow.ErrorText = "Invalid Memo";
                        e.Cancel = true;
                        Helper.MsgBox("Invalid Memo", Telerik.WinControls.RadMessageIcon.Error);
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
               
            }
        }

        private void frmStatementofMemo_Load(object sender, EventArgs e)
        {

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
                this.dateFrom.Value = new DateTime(1900,1,1);
                this.dateTo.Value = new DateTime(2099, 12, 31);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnPrint.Visible = this.radGridView1.RowCount > 0;
        }

        private void radGridView2_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            
        }

        private void radGridView2_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            
        }

      
    }

}
