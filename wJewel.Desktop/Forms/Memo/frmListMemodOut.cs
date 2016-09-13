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
    public partial class frmListMemodOut : Telerik.WinControls.UI.RadForm
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

        private DataView dvListItemsmMemodOut;

        private string InvoiceNo;

        private string customerAcc;

        private string output_type = "Preview";

        private string returnstyle = string.Empty;
        private bool isbar= false;

        public frmListMemodOut()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.styletracking, 24, true);
            this.memoService = new MemoService();
            //            this.dateFrom.SetToNullValue();
            //            this.dateTo.SetToNullValue();
            this.dateTo.Value = DateTime.Now;           
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
                fromDate = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateFrom.Text));
            else
                fromDate = string.Format("{0:yyyy-MM-dd}", new DateTime(1900, 1, 1));

            string toDate;
            if (!string.IsNullOrEmpty(dateTo.Text.Trim()))
                toDate = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dateTo.Text));
            else
                toDate = string.Format("{0:yyyy-MM-dd}", new DateTime(2099, 12, 31));

            // Data grid view column setting      
            radGridView1.DataSource = "";
         
            DataTable data = this.memoService.ListofItemsMemodOut(fromDate, toDate);
            dvListItemsmMemodOut = new DataView(data);

            //dvStyleTracking.RowFilter = "1=0";
            radGridView1.DataSource = dvListItemsmMemodOut;
            //radGridView1.DataMember = data.TableName;
            radGridView1.Columns[0].Width = 50;
            radGridView1.Columns[1].Width = 50;
            radGridView1.Columns[2].Width = 50;
            radGridView1.Columns[3].Width = 50;
            radGridView1.Columns[4].Width = 50;
            radGridView1.Columns[5].Width = 50;
            radGridView1.Columns[6].Width = 50;
            radGridView1.Columns[7].Width = 50;
            
           

            radGridView1.Columns[0].HeaderText = "Memo #";
            radGridView1.Columns[1].HeaderText = "Date";
            radGridView1.Columns[1].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].HeaderText = "Billing Acc.";
            radGridView1.Columns[3].HeaderText = "Style #";
            radGridView1.Columns[4].HeaderText = "Qty";
            radGridView1.Columns[4].FormatString = "{0:N}";
            radGridView1.Columns[5].HeaderText = "Weight";
            radGridView1.Columns[5].FormatString = "{0:N}";
            radGridView1.Columns[6].HeaderText = "Price";
            radGridView1.Columns[6].FormatString = "{0:c}";
            radGridView1.Columns[7].HeaderText = "By Wt.";
            
           
            

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
            if (dvListItemsmMemodOut == null)
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                return;
            }
            
            if (dvListItemsmMemodOut.Count > 0)
            {

                

                if (this.radGridView1.SortDescriptors.Count != 0)
                    dvListItemsmMemodOut.Sort = this.radGridView1.SortDescriptors.ToString();

                string custemail = string.Empty;
                
             

                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvListItemsmMemodOut;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];

                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpTitle";
                reportParameterCollection[0].Values.Add("");


                Helper.PrintReport(objReportPrinting, "List of Items Memod Out", "IshalInc.wJewel.Desktop.Forms.Reports.rptListofItemsMemodOut.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

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

            if (dvListItemsmMemodOut != null)
            dvListItemsmMemodOut.RowFilter = "1=0";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchRecords();
            
        }



        private void SearchRecords()
        {
            LoadDataGridView();
            if (dvListItemsmMemodOut == null)
                return;
            string sFilter = "1=1";
            string acc1 = !string.IsNullOrEmpty(this.txtAcc1.Text)?  this.txtAcc1.Text :"0";
            string acc2 = !string.IsNullOrEmpty(this.txtAcc1.Text) ? this.txtAcc2.Text : "ZZ";

            sFilter += string.Format(" AND (BACC >= '{0}' AND BACC <= '{1}')", acc1,acc2);

            dvListItemsmMemodOut.RowFilter = sFilter;
            if (dvListItemsmMemodOut.Count == 0)
            {
                Helper.MsgBox("No Records Found", Telerik.WinControls.RadMessageIcon.Info);
                this.btnPrint.Enabled = false;
                return;
            }
            this.btnPrint.Enabled = true;
            
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

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnPrint.Visible = this.radGridView1.RowCount > 0;
        }

        private void radLabel6_Click(object sender, EventArgs e)
        {

        }

        private void frmListMemodOut_Load(object sender, EventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtAcc1.Text = "0";
            this.txtAcc2.Text = "ZZ";
        }
    }

}
