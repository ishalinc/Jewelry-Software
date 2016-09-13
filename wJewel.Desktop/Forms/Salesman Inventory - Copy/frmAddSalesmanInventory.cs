using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using IshalInc.wJewel.Data.BusinessService;
using System.Windows.Forms;
using Telerik.WinControls;
using IshalInc.wJewel.Desktop.Libraries;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmAddSalesmanInventory : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;

        private ISalesmenService salesmenService;

        private DataTable dtSlsSamp;

        private string output_type = "Preview";


        private string returnstyle = string.Empty;
        private bool isbar = false;
        private string piece = "Y";
        private bool is_cancelled = true;
        public frmAddSalesmanInventory()
        {
            InitializeComponent();
        }

        public frmAddSalesmanInventory(string logno)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);
           
            this.customerService = new CustomerService();
            this.salesmenService = new SalesmenService();
            this.txtLogNo.Text = logno;
            this.txtEntryDate.Value = DateTime.Now;
            DataTable data = this.customerService.GetSalesmen();
            DataView dvSalesmen1 = new DataView(data);
            this.txtSalesman1.Items.Clear();
            
            this.txtSalesman1.DataSource = dvSalesmen1;
            this.txtSalesman1.DisplayMember = "Code";
            this.txtSalesman1.ValueMember = "Code";
            this.txtSalesman1.SelectedIndex = 1;


            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
            //radGridView1.GridBehavior = new AddReceiptGridBehavior();

            dtSlsSamp = new DataTable();
            dtSlsSamp.Columns.Add("STYLE", typeof(string));

            dtSlsSamp.Columns.Add("STOCK", typeof(decimal));
            dtSlsSamp.Columns["STOCK"].DefaultValue = 0;

            dtSlsSamp.Columns.Add("WT_STOCK", typeof(decimal));
            dtSlsSamp.Columns["WT_STOCK"].DefaultValue = 0.00;


            dtSlsSamp.Columns.Add("LINE", typeof(decimal));
            dtSlsSamp.Columns["LINE"].DefaultValue = 0;

            dtSlsSamp.Columns.Add("WT_LINE", typeof(decimal));
            dtSlsSamp.Columns["WT_LINE"].DefaultValue = 0.00;
            

            dtSlsSamp.Columns.Add("LOG", typeof(decimal));
            dtSlsSamp.Columns["LOG"].DefaultValue = 0;

            dtSlsSamp.Columns.Add("WT_LOG", typeof(decimal));
            dtSlsSamp.Columns["WT_LOG"].DefaultValue = 0.00;



            dtSlsSamp.Columns.Add("QTY", typeof(decimal));
            dtSlsSamp.Columns["QTY"].DefaultValue = 0;

            dtSlsSamp.Columns.Add("WEIGHT", typeof(decimal));
            dtSlsSamp.Columns["WEIGHT"].DefaultValue = 0.00;

            dtSlsSamp.Columns.Add("INV_NO", typeof(string));
            dtSlsSamp.Columns["INV_NO"].DefaultValue = this.txtLogNo.Text;

            dtSlsSamp.Columns.Add("LINE_NO", typeof(string));
            dtSlsSamp.Columns["LINE_NO"].DefaultValue = this.txtSalesman1.SelectedValue;

            dtSlsSamp.Columns.Add("DATE", typeof(DateTime));
            dtSlsSamp.Columns["DATE"].DefaultValue = this.txtEntryDate.Value; ;

            dtSlsSamp.Columns.Add("PRICE", typeof(decimal));
            dtSlsSamp.Columns["PRICE"].DefaultValue = 0.00;
            
            dtSlsSamp.Columns.Add("SIZE", typeof(string));
            dtSlsSamp.Columns["SIZE"].DefaultValue = "";

            InitializaGrid();
        }

        
        private void InitializaGrid()
        {
            dtSlsSamp.RowChanged -= new DataRowChangeEventHandler(Row_Changed);
            dtSlsSamp.RowChanged += new DataRowChangeEventHandler(Row_Changed);

            radGridView1.DataSource = dtSlsSamp;

            radGridView1.Columns[0].HeaderText = "Style No.";

            radGridView1.Columns[1].HeaderText = "Pcs.";
            radGridView1.Columns[1].ReadOnly = true;
            
            radGridView1.Columns[2].FormatString = "{0:0}";
            radGridView1.Columns[2].HeaderText = "Weight";
            radGridView1.Columns[2].ReadOnly = true;
            radGridView1.Columns[2].FormatString = "{0:0.00}";

            radGridView1.Columns[3].HeaderText = "Pcs.";
            radGridView1.Columns[3].ReadOnly = true;
            radGridView1.Columns[3].FormatString = "{0:0}";
            radGridView1.Columns[4].HeaderText = "Weight";
            radGridView1.Columns[4].ReadOnly = true;
            radGridView1.Columns[4].FormatString = "{0:0.00}";

            radGridView1.Columns[5].HeaderText = "Pcs.";
            radGridView1.Columns[5].FormatString = "{0:0}";
            radGridView1.Columns[5].ReadOnly = true;
            radGridView1.Columns[6].HeaderText = "Weight";
            radGridView1.Columns[6].FormatString = "{0:0.00}";
            radGridView1.Columns[6].ReadOnly = true;

            radGridView1.Columns[7].HeaderText = "Pcs.";
            radGridView1.Columns[7].ReadOnly = false;
            radGridView1.Columns[7].FormatString = "{0:0}";
            radGridView1.Columns[8].HeaderText = "Weight";
            radGridView1.Columns[8].ReadOnly = false;
            radGridView1.Columns[8].FormatString = "{0:0.00}";

            radGridView1.Columns[9].IsVisible = false;
            radGridView1.Columns[10].IsVisible = false;
            radGridView1.Columns[11].IsVisible = false;
            radGridView1.Columns[12].IsVisible = false;
            radGridView1.Columns[13].IsVisible = false;


        }

        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            
            object total_qty = dtSlsSamp.Compute("SUM(QTY)", "1=1");
            object total_wt = dtSlsSamp.Compute("SUM(WEIGHT)", "1=1");
            if (total_qty != DBNull.Value)
              this.txtTotalQty.Text = string.Format("{0:0}", Convert.ToDecimal(total_qty));
           
            if (total_wt != DBNull.Value)
                this.txtTotalWeight.Text = string.Format("{0:0.00}", Convert.ToDecimal(total_wt));
           


        }
        private void radGridView1_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 7 && isbar)
            {
                SendKeys.SendWait("{TAB}");
            }
            if (e.ColumnIndex == 8 && (isbar || piece == "Y") )
            {
                SendKeys.SendWait("{TAB}");

            }
        }

        private void radGridView1_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    DataRow styleData = this.salesmenService.GetSalesmanStyleData(this.txtLogNo.Text, e.Value.ToString(), Helper.InvStyle(e.Value.ToString()), "1000", "", 0, 0);
                    e.Row.Cells[1].Value = Convert.ToDecimal(styleData[0]);
                    e.Row.Cells[2].Value = Convert.ToDecimal(styleData[1]);
                    e.Row.Cells[3].Value = Convert.ToDecimal(styleData[2]);
                    e.Row.Cells[4].Value = Convert.ToDecimal(styleData[3]);
                    e.Row.Cells[5].Value = Convert.ToDecimal(styleData[4]);
                    e.Row.Cells[6].Value = Convert.ToDecimal(styleData[5]);
                }

            }

            if (e.ColumnIndex == 7)
                e.Row.Cells[5].Value = e.Value;
            if (e.ColumnIndex == 8)
                e.Row.Cells[6].Value = e.Value;

            radGridView1.EndEdit();

        }

        private void radGridView1_CellValidated(object sender, Telerik.WinControls.UI.CellValidatedEventArgs e)
        {
            if (e.ColumnIndex == 0 && radGridView1.CurrentRow != null)
            {
                radGridView1.CurrentCell.Value = returnstyle;

                returnstyle = string.Empty;

              
            }
        }

        private void radGridView1_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            var cell = e.Row.Cells[e.ColumnIndex];
            var currentRow = radGridView1.CurrentRow;
            
            if (!chkDuplicate.Checked)
            {
                DataRow[] foundStyle = dtSlsSamp.Select("Style = '" + e.Value + "'");
                if (foundStyle.Length != 0)
                {
                    DialogResult dialogResult = RadMessageBox.Show("Do you want to enter duplicate style?", "Add Salesman Inventory", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (dialogResult != DialogResult.Yes)
                    {

                        cell.ErrorText = "Duplicate Style";
                        currentRow.ErrorText = "Duplicate Style";
                        e.Cancel = true;
                        Helper.MsgBox("Duplicate Style", Telerik.WinControls.RadMessageIcon.Error);
                        return;

                    }
                }
            }
            if (e.ColumnIndex == 0 && radGridView1.CurrentRow != null)
            {

                if (e.Value != null)
                {
                    returnstyle = "";
                    if (!Helper.CheckStyle(e.Value.ToString(), out returnstyle, out isbar, out piece) || string.IsNullOrEmpty(e.Value.ToString()))
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

        private void radGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (radGridView1.CurrentCell.ColumnIndex == 0)
            {
                if (e.KeyChar == (char)13)
                {
                    this.radGridView1.GridNavigator.SelectNextRow(1);
                    this.radGridView1.GridNavigator.SelectFirstColumn();
                }
            }
            */
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSalesman1.SelectedValue.ToString()))
            {
                Helper.MsgBox("Salesman Can not be empty");
                return;
            }
            string error;
            this.salesmenService.SaveInventory(dtSlsSamp, out error);
            if (string.IsNullOrEmpty(error))
            {
                is_cancelled = false;
                DataTable dtSalesmanInventoryReport = this.salesmenService.GetSalesmanInvetoryReport(this.txtLogNo.Text);
                if (dtSalesmanInventoryReport == null)
                    return;

                if (dtSalesmanInventoryReport.Rows.Count > 0)
                {

                    string custemail = string.Empty;



                    ReportPrinting objReportPrinting = new ReportPrinting();
                    Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                    Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                    reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSourceCollection[0].Name = "DataSet1";
                    reportDataSourceCollection[0].Value = dtSalesmanInventoryReport;

                    reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];

                   
                    reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                    reportParameterCollection[0].Name = "rpTitle";
                    reportParameterCollection[0].Values.Add(string.Format("Items added to Salesman Line: {0}, Log {1}", this.txtSalesman1.SelectedValue.ToString(), this.txtLogNo.Text));




                    switch (this.output_type)
                    {
                        case "Preview":
                            objReportPrinting.PrintReport("Salesmen Inventory Report", "IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", reportParameterCollection, reportDataSourceCollection, "Salesmen Inventory Report");
                            break;
                        case "Print":
                            objReportPrinting.PrintReport("IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", reportParameterCollection, reportDataSourceCollection);
                            break;
                        case "Email":
                            objReportPrinting.SendasEmail("IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", reportParameterCollection, reportDataSourceCollection, "", string.Format("Salesmen Inventory Report"));
                            break;
                    }
                }
                else
                {
                    Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
                }

            }
            else
            {
                is_cancelled = true;
                Helper.MsgBox(error);
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            is_cancelled = true;
            this.Close();
        }

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
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

        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.is_cancelled)
            {
                int t_logno;
                if (int.TryParse(this.txtLogNo.Text, out t_logno))
                {
                    Helper.CheckSISequence(t_logno);
                }
            }
        }

        private void frmAddSalesmanInventory_Load(object sender, EventArgs e)
        {

        }
    }
}
