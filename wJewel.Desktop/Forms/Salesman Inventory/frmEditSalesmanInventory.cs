﻿using System;
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
    public partial class frmEditSalesmanInventory : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;

        private ISalesmenService salesmenService;

        private DataTable dtSlsSamp;

        private string output_type = "Preview";


        private string returnstyle = string.Empty;
        private bool isbar = false;
        private string piece = "Y";
        private bool is_cancelled = true;
        private bool is_deduct = false;
        private int existingQty = 0;
       

        public frmEditSalesmanInventory()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);
           
            this.customerService = new CustomerService();
            this.salesmenService = new SalesmenService();
          
            this.txtEntryDate.Value = DateTime.Now;
            DataTable data = this.customerService.GetSalesmen();
            DataView dvSalesmen1 = new DataView(data);
            this.txtSalesman1.Items.Clear();
            
            this.txtSalesman1.DataSource = dvSalesmen1;
            this.txtSalesman1.DisplayMember = "Code";
            this.txtSalesman1.ValueMember = "Code";
            this.txtSalesman1.SelectedIndex = 0;

            this.txtEntryDate.Value = DateTime.Now;

            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();

            this.btnSave.ButtonElement.ForeColor = Color.Green;
            this.btnSave.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnClose.ButtonElement.ForeColor = Color.Red;
            this.btnClose.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


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

            dtSlsSamp.Columns.Add("OLD_QTY", typeof(decimal));
            dtSlsSamp.Columns["OLD_QTY"].DefaultValue = 0;

            dtSlsSamp.Columns.Add("OLD_WEIGHT", typeof(decimal));
            dtSlsSamp.Columns["OLD_WEIGHT"].DefaultValue = 0.00;

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

            radGridView1.Columns[14].IsVisible = false;
            radGridView1.Columns[15].IsVisible = false;

            radGridView1.EnterKeyMode = RadGridViewEnterKeyMode.EnterMovesToNextCell;
            radGridView1.NewRowEnterKeyMode = RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
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
           
            if (string.IsNullOrEmpty(this.txtSalesman1.SelectedValue.ToString()))
            {
                Helper.MsgBox("Salesman Can not be empty");
                e.Cancel = true;
                return;
            }
            
            if (e.ColumnIndex == 7 && isbar)
            {
                
                if (!string.IsNullOrEmpty(returnstyle))
                {
                    int totalQty = salesmenService.GetSlsAllotedQtyByStyle(returnstyle, this.txtSalesman1.SelectedValue.ToString());
                    if (totalQty > this.radSpinEditor1.Value && !this.chkDuplicate.Checked)
                    {

                        DialogResult dialogResult = RadMessageBox.Show("Do you want to enter duplicate style?", "Add Salesman Inventory", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult != DialogResult.Yes)
                        {

                            e.Row.Cells[7].Value = Convert.ToInt32(e.Row.Cells[7].Value) - 1;
                        }
                        else
                        {
                            e.Cancel = false;

                        }
                    }
                }
                isbar = false;
                returnstyle = string.Empty;
                SendKeys.Send("\t");
            }
            if (e.ColumnIndex == 8 && (isbar || piece == "Y") )
            {

                SendKeys.Send("\t");

            }
            
        }

        private void radGridView1_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && radGridView1.CurrentRow != null)
            {
                e.Row.Cells[0].Value = returnstyle;
                if (e.Value != null)
                {
                    DataRow[] foundStyle = dtSlsSamp.Select("Style = '" + returnstyle + "'");


                    foreach (DataRow dr in foundStyle)
                    {
                        existingQty += Convert.ToInt32(dr["QTY"]);
                        dtSlsSamp.Rows.Remove(dr);

                    }
                    dtSlsSamp.AcceptChanges();

                }
                if (is_deduct)
                    e.Row.Cells[7].Value = isbar ? existingQty - 1 : existingQty;
                else
                    e.Row.Cells[7].Value = isbar ? existingQty + 1 : existingQty;

                existingQty = 0;

            }



        }

        private void radGridView1_CellValidated(object sender, Telerik.WinControls.UI.CellValidatedEventArgs e)
        {
            
           
            if(e.ColumnIndex == 0 && e.Value != null)
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    DataRow styleData = this.salesmenService.GetSalesmanStyleData(this.txtLogNo.Text, returnstyle, Helper.InvStyle(returnstyle), "1000", "", 0, 0);
                    if (styleData != null)
                    {
                        e.Row.Cells[1].Value = Convert.ToDecimal(styleData[0]);
                        e.Row.Cells[2].Value = Convert.ToDecimal(styleData[1]);
                        e.Row.Cells[3].Value = Convert.ToDecimal(styleData[2]);
                        e.Row.Cells[4].Value = Convert.ToDecimal(styleData[3]);
                        e.Row.Cells[5].Value = Convert.ToDecimal(styleData[4]);
                        e.Row.Cells[6].Value = Convert.ToDecimal(styleData[5]);
                    }
                }

            }

            if (e.ColumnIndex == 7)
            {
                if (e.Value != null)
                    e.Row.Cells[5].Value = e.Value;
            }
            if (e.ColumnIndex == 8)
            {
                if (e.Value != null)
                    e.Row.Cells[6].Value = e.Value;
            }

        }

        private void radGridView1_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            if (radGridView1.IsInEditMode == false)
                return;

            string enteredStyle = e.Value == null ? string.Empty : e.Value.ToString();

            var cell = e.Row.Cells[e.ColumnIndex];
           

            if (e.ColumnIndex == 0 && e.Row != null)
            {

                if (enteredStyle != null)
                {
                    returnstyle = "";
                    if (!Helper.CheckStyle(enteredStyle, out returnstyle, out isbar, out piece) || string.IsNullOrEmpty(enteredStyle))
                    {
                        
                        cell.ErrorText = "Invalid Style";
                       
                        e.Cancel = true;
                        
                        Helper.MsgBox("Invalid Style", Telerik.WinControls.RadMessageIcon.Error);
                    }
                    else
                    {
                        

                        cell.ErrorText = string.Empty;
                        
                        e.Cancel = false;
                    }
                }
                else
                {
                    cell.ErrorText = string.Empty;
                    
                    e.Cancel = false;


                }

                
            }

            

            if(e.ColumnIndex == 7)
            {
                if (e.Value != null)
                {
                    
                    if (is_deduct ? Convert.ToInt32(e.Value) > 0 : Convert.ToInt32(e.Value) < 0)
                    {
                        cell.ErrorText = "Invalid Qty";

                        e.Cancel = true;
                        Helper.MsgBox("Invalid Qty", Telerik.WinControls.RadMessageIcon.Error);
                        return;
                    }

                    int totalQty = salesmenService.GetSlsAllotedQtyByStyle(returnstyle, this.txtSalesman1.SelectedValue.ToString());
                    if (totalQty > this.radSpinEditor1.Value && !this.chkDuplicate.Checked)
                    {

                        DialogResult dialogResult = RadMessageBox.Show("Do you want to enter duplicate style?", "Add Salesman Inventory", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult != DialogResult.Yes)
                        {

                            cell.ErrorText = "Duplicate Style";
                           
                            e.Cancel = true;
                            Helper.MsgBox("Duplicate Style", Telerik.WinControls.RadMessageIcon.Error);


                        }
                        else
                        {
                            e.Cancel = false;
                            
                        }
                    }
                }
            }
           
           
        }

        private void radGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSalesman1.SelectedValue.ToString()))
            {
                Helper.MsgBox("Salesman Can not be empty");
                return;
            }
           else
            {
                dtSlsSamp.Columns["line_no"].DefaultValue = this.txtSalesman1.SelectedValue.ToString();
                
                foreach (DataRow dr in dtSlsSamp.Rows)
                {
                    dr["line_no"] = this.txtSalesman1.SelectedValue.ToString();
                    dr["date"] = this.txtEntryDate.Value;
                    dr.EndEdit();
                }
                
            }
            dtSlsSamp.AcceptChanges();
            for (int i = dtSlsSamp.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtSlsSamp.Rows[i];
                if(Convert.ToDecimal(dr["QTY"]) == 0)
                    dr.Delete();
            }

            dtSlsSamp.AcceptChanges();
            string error;
            if (this.salesmenService.SaveInventory(dtSlsSamp, out error))
            {
                if (string.IsNullOrEmpty(error))
                    Helper.AddKeepRec("Edit Salesman Log# " + this.txtLogNo.Text);
            }
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
                    reportParameterCollection[0].Values.Add(string.Format("Items edited to Salesman Line: {0}, Log {1}", this.txtSalesman1.SelectedValue.ToString(), this.txtLogNo.Text));


                    Helper.PrintReport(objReportPrinting, "Salesmen Inventory Report", "IshalInc.wJewel.Desktop.Forms.Reports.rptSalesInventoryReport.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

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
            int qty = Convert.ToInt32(string.IsNullOrEmpty(this.txtTotalQty.Text) ? "0" : this.txtTotalQty.Text);

            if (qty != 0)
            {
                DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to cancel the changes?", "Edit Salesman Log", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.is_cancelled = true;
                    this.Close();
                }
            }
            else
            {
                this.is_cancelled = true;
                this.Close();
            }
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

        private void radGridView1_CurrentColumnChanged(object sender, CurrentColumnChangedEventArgs e)
        {
            if (e.NewColumn.ReadOnly)
            {
                int nextIndex = e.NewColumn.Index + 1;
                if (nextIndex >= this.radGridView1.Columns.Count)
                {
                    nextIndex = 0;
                }

                this.radGridView1.CurrentColumn = this.radGridView1.Columns[nextIndex];
            }
        }

        private void radGridView1_DataError(object sender, GridViewDataErrorEventArgs e)
        {

        }

        private void txtLogNo_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void txtLogNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtLogNo.Text))
            {
                DataTable dtSalesmanLog = this.salesmenService.CheckValidSalesmanLog(this.txtLogNo.Text);
                if (dtSalesmanLog == null)
                {
                    Helper.MsgBox("Invalid Log No.", RadMessageIcon.Info);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    dtSlsSamp.Rows.Clear();
                    this.txtEntryDate.Value = Convert.ToDateTime(dtSalesmanLog.Rows[0]["date"]);
                    this.txtSalesman1.SelectedValue = dtSalesmanLog.Rows[0]["line_no"].ToString();
                    
                    foreach(DataRow drSlsLog in dtSalesmanLog.Rows)
                    {
                        DataRow styleData = this.salesmenService.GetSalesmanStyleData(this.txtLogNo.Text, drSlsLog["style"].ToString(), drSlsLog["style"].ToString(), "1000", "", 0, 0);
                        if (styleData != null)
                        {
                            if (Convert.ToDecimal(drSlsLog["qty"]) < 0)
                                is_deduct = true;
                            else
                                is_deduct = false;

                            DataRow drNewRow = dtSlsSamp.NewRow();
                            drNewRow["style"] = drSlsLog["style"].ToString();
                            drNewRow["stock"] = Convert.ToDecimal(styleData[0]);
                            drNewRow["wt_stock"] = Convert.ToDecimal(styleData[1]);
                            drNewRow["line"] = Convert.ToDecimal(styleData[2]);
                            drNewRow["wt_line"] = Convert.ToDecimal(styleData[3]);
                            drNewRow["log"] = Convert.ToDecimal(styleData[4]);
                            drNewRow["wt_log"] = Convert.ToDecimal(styleData[5]);
                            drNewRow["qty"] = Convert.ToDecimal(drSlsLog["qty"]);
                            drNewRow["weight"] = Convert.ToDecimal(drSlsLog["weight"]);
                            drNewRow["inv_no"] = drSlsLog["inv_no"].ToString();
                            drNewRow["line_no"] = drSlsLog["line_no"].ToString();
                            drNewRow["date"] = this.txtEntryDate.Value;
                            drNewRow["price"] = Convert.ToDecimal(drSlsLog["price"]); 
                            drNewRow["size"] = drSlsLog["size"].ToString(); 
                            drNewRow["old_qty"] = Convert.ToDecimal(drSlsLog["qty"]); 
                            drNewRow["old_weight"] = Convert.ToDecimal(drSlsLog["weight"]);
                            drNewRow.EndEdit();
                            dtSlsSamp.Rows.Add(drNewRow);


                        }
                        dtSlsSamp.AcceptChanges();
                    }
                    InitializaGrid();
                   
                }
            }
        }
    }
}
