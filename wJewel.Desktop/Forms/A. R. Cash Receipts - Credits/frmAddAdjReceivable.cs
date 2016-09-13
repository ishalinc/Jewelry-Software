using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI.Localization;



namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmAddAdjReceivable : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;
        private IReceiptService receiptService;
        private bool is_cancelled = true;
        private int rowIndex = -1;
        DataTable dtAddCashReceipt;
        public frmAddAdjReceivable()
        {
            InitializeComponent();
            this.txtAdjRcvableNo.Text = Helper.GetNextAdjRcvableNo();
         
            receiptService = new ReceiptService();
            customerService = new CustomerService();
           
            dtAddCashReceipt = new DataTable();
            dtAddCashReceipt.Columns.Add("REF_TYPE", typeof(string));
            dtAddCashReceipt.Columns.Add("REF_NO", typeof(string));
            dtAddCashReceipt.Columns.Add("REF_DATE", typeof(DateTime));
            dtAddCashReceipt.Columns.Add("ORIGINAL", typeof(decimal));
            dtAddCashReceipt.Columns.Add("BAL_AMOUNT", typeof(decimal));
            dtAddCashReceipt.Columns.Add("APP_AMOUNT", typeof(decimal));
            dtAddCashReceipt.Columns.Add("APPAMT", typeof(decimal));
            dtAddCashReceipt.Columns.Add("APPFLG", typeof(string));
            dtAddCashReceipt.Columns.Add("RSORT", typeof(string));
            dtAddCashReceipt.Columns.Add("IREFNO", typeof(decimal));


            this.btnSave.ButtonElement.ForeColor = Color.Green;
            this.btnSave.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnClose.ButtonElement.ForeColor = Color.Red;
            this.btnClose.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


            this.radGridView1.CurrentColumnChanged += new Telerik.WinControls.UI.CurrentColumnChangedEventHandler(radGridView1_CurrentColumnChanged);

            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
            radGridView1.GridBehavior = new AddReceiptGridBehavior();

            this.FormClosing += new FormClosingEventHandler(frmAddCashReceipt_FormClosing);

            InitializaGrid();
        }

       
        private void radGridView1_CurrentColumnChanged(object sender, Telerik.WinControls.UI.CurrentColumnChangedEventArgs e)
        {


        }

        private void Column_Changed(object sender, DataColumnChangeEventArgs e)
        {
            decimal balamount, app_amount;
            balamount = Convert.ToDecimal(e.Row["BAL_AMOUNT"]);
            app_amount = Convert.ToDecimal(e.Row["APP_AMOUNT"]);

            if ((app_amount != 0) && (Math.Abs(app_amount) > Math.Abs(balamount) || Math.Sign(app_amount) != Math.Sign(balamount))) { 
                 Helper.MsgBox(string.Format("Applied Applid Amount, Must be Between 0 and {0}", balamount), RadMessageIcon.Info);
                 e.Row["APP_AMOUNT"] = e.Row["APP_AMOUNT", DataRowVersion.Original];
            }
            object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
            object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");
            this.txtCredits.Text = string.Format("{0:c}", Convert.ToDecimal(credits) * -1);
            this.txtDebits.Text = string.Format("{0:c}", debits);
            this.txtDifference.Value = Convert.ToDecimal(credits) * -1 - Convert.ToDecimal(debits);

        }

        private void InitializaGrid()
        {

            dtAddCashReceipt.Rows.Clear();

            if (!string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {

                
                DataTable dtGetReceiptData = receiptService.GetAdjReceivableData(this.txtBillingAcctNo.Text);
                dtAddCashReceipt.Merge(dtGetReceiptData);
                if (!chkShowMemo.Checked)
                {
                    dtAddCashReceipt = dtGetReceiptData.Select("REF_TYPE <> 'MEMO'", "rsort asc,ref_date asc, IREFNO asc").CopyToDataTable();
                }

            }
            else
            {
                dtAddCashReceipt.Rows.Clear();
            }

          

            dtAddCashReceipt.ColumnChanged -= new DataColumnChangeEventHandler(Column_Changed);
            dtAddCashReceipt.ColumnChanged += new DataColumnChangeEventHandler(Column_Changed);
            radGridView1.DataSource = dtAddCashReceipt;

            radGridView1.Columns[0].HeaderText = "Ref. Type";
            radGridView1.Columns[1].HeaderText = "Ref. No.";
            radGridView1.Columns[2].HeaderText = "Ref. Date";
            radGridView1.Columns[2].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[3].HeaderText = "Orig. Amt.";
            radGridView1.Columns[3].FormatString = "{0:$#,##0.00}";
            radGridView1.Columns[4].HeaderText = "Balance";
            radGridView1.Columns[4].FormatString = "{0:$#,##0.00}";
            radGridView1.Columns[5].HeaderText = "Applied";
            radGridView1.Columns[5].FormatString = "{0:$#,##0.00}";
            radGridView1.Columns[6].IsVisible = false;
            radGridView1.Columns[7].IsVisible = false;
            radGridView1.Columns[8].IsVisible = false;
            radGridView1.Columns[9].IsVisible = false;

            if (radGridView1.Rows.Count > 0)
            {
                try
                {
                    GridViewRowInfo row = (from p in radGridView1.Rows
                                           where p.Cells[7].Value.ToString() == "C"
                                           select p).Single();
                    rowIndex = row.Index;
                    if (row != null)
                        radGridView1.CurrentRow = row;

                }
                catch
                {

                }
            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to cancel the changes?", "Add Cash Receipt", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.is_cancelled = true;
                this.Close();
            }
        }

        private void frmAddCashReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this.is_cancelled)
            {
                int t_adbrcvableno;
                if (int.TryParse(this.txtAdjRcvableNo.Text, out t_adbrcvableno))
                {
                    Helper.CheckAdjReceivableSequence(t_adbrcvableno);
                }
            }
        }

        private void txtBillingAcctNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBillingAcctNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {
                DataRow billAcctRow = this.customerService.CheckValidBillingAcct(this.txtBillingAcctNo.Text);
                if (billAcctRow == null)
                {
                    Helper.MsgBox("Invalid Billing Account", Telerik.WinControls.RadMessageIcon.Info);
                    dtAddCashReceipt.Clear();
                }
                else
                    InitializaGrid();
            }

        }

        private void radGridView1_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {

        }

        private void radGridView1_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {

            if ((e.ColumnIndex < 3) || (e.Row.Cells[7].Value.ToString() != "C" && e.ColumnIndex != 5))
            {
                radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                e.Cancel = true;
            }
        }


        private void radGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.radGridView1.GridNavigator.SelectNextRow(1);
                this.radGridView1.GridNavigator.SelectLastColumn();
            }
            else if (e.KeyChar.ToString().ToUpper() == "F")
            {
                dtAddCashReceipt.Rows[radGridView1.CurrentRow.Index].SetField(5, dtAddCashReceipt.Rows[radGridView1.CurrentRow.Index][4]);
                //int nextRowIndex = radGridView1.CurrentRow.Index == radGridView1.Rows.Count - 1 ? 0 : radGridView1.CurrentRow.Index + 1;
                //radGridView1.CurrentRow = radGridView1.Rows[nextRowIndex];
                this.radGridView1.GridNavigator.SelectNextRow(1);
                this.radGridView1.GridNavigator.SelectFirstColumn();
            }
            else
            {

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
            object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");
          
            if (string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {
                Helper.MsgBox("Billing Account no. cannot be empty", RadMessageIcon.Info);
                this.txtBillingAcctNo.Focus();
                return;
            }

          

            if (Convert.ToDecimal(credits) * -1 != Convert.ToDecimal(debits))
            {
                Helper.MsgBox("Credits Must match Debits", RadMessageIcon.Info);
                return;
            }

            //if (Convert.ToDecimal(this.txtDebits.Value) > Convert.ToDecimal(this.txtCredits.Value))
            //{
            //    Helper.MsgBox("Too much invoices are being cleared, will not process the rcvable", RadMessageIcon.Info);
            //    return;
            //}


            DataView dvPayble = new DataView(dtAddCashReceipt);
            dvPayble.RowFilter = "(ref_type = 'RTV' OR ref_type = 'CREDIT' OR ref_type = 'PAYMENT') AND app_amount <> 0";
            dvPayble.Sort = "ref_date  ASC";

            DataView dvRecble = new DataView(dtAddCashReceipt);
            dvRecble.RowFilter = "(ref_type='INVOICE' OR ref_type='MEMO') AND app_amount <> 0";
            dvRecble.Sort = "ref_date  ASC";

           

            DataView dvPayItem = Helper.GetPayItem().DefaultView;
            var rowQuery = "";
            DataRowView rowView;
            IEnumerable<DataRowView> query;

            int payctr = 0;
            foreach (DataRowView rowRecble in dvRecble)
            {
                rowRecble["appamt"] = Convert.ToDecimal(rowRecble["app_amount"]);
                rowRecble.EndEdit();
            }
            foreach (DataRowView rowPayble in dvPayble)
            {
                rowPayble["appamt"] = Convert.ToDecimal(rowPayble["app_amount"]) * -1;
                rowPayble.EndEdit();
            }

           
            string error;

            DataTable dtPayble = dtAddCashReceipt.Copy();
            dtPayble.Columns.Remove("RSORT");
            dtPayble.Columns.Remove("IREFNO");

         
            if (this.receiptService.SaveAdjRcvable(dtPayble,  this.txtBillingAcctNo.Text, this.txtAdjRcvableNo.Text, this.txtEntryDate.Value, this.chkShowMemo.Checked, out error))
            {
                Helper.AddKeepRec("Add Adj. Receivable" + this.txtAdjRcvableNo.Text);
                this.is_cancelled = false;
                DataRow drPayment = this.receiptService.GetPayment(this.txtAdjRcvableNo.Text,"F");

                var list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("rpCustomer", drPayment["acc"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpEntryDate", string.Format("{0:MM/dd/yyyy}", drPayment["date"].ToString())));
                list.Add(new KeyValuePair<string, string>("rpRecvNo", drPayment["inv_no"].ToString()));
               
                
                frmPrintAdjRcvable objPrintReceipt = new frmPrintAdjRcvable(this.txtAdjRcvableNo.Text, list);
                objPrintReceipt.StartPosition = FormStartPosition.CenterScreen;

                DialogResult dialogResult = objPrintReceipt.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    objPrintReceipt.Close();
                }

                this.txtAdjRcvableNo.Text = Helper.GetNextAdjRcvableNo();
              
                this.txtCredits.Value = 0;
                this.txtDebits.Value = 0;
                this.txtDifference.Value = 0;
                this.txtBillingAcctNo.Text = string.Empty;
                this.txtAdjRcvableNo.Focus();
                dtAddCashReceipt.Clear();
               

            }
            else
            {
                this.is_cancelled = true;
                Helper.MsgBox(string.Format("Unable to Save Receipt - {0}", error), RadMessageIcon.Error);
            }
        }

        private void btnAutoApply_Click(object sender, EventArgs e)
        {
          
            DataView dvPayble = new DataView(dtAddCashReceipt);
            dvPayble.RowFilter = "(ref_type = 'RTV' OR ref_type = 'CREDIT' OR ref_type = 'PAYMENT') AND app_amount <> 0";
            dvPayble.Sort = "ref_date  ASC";

            DataView dvRecble = new DataView(dtAddCashReceipt);
            dvRecble.RowFilter = "(ref_type='INVOICE' OR ref_type='MEMO')";
            dvRecble.Sort = "ref_date  ASC";
            int rcvble_ctr = 0;
            bool exit = false;
            foreach (DataRowView rowPayble in dvPayble)
            {
                decimal balamt = Convert.ToDecimal(rowPayble["app_amount"]) * -1;
                while (balamt > 0)
                {
                    if (Convert.ToDecimal(dvRecble[rcvble_ctr]["bal_amount"].ToString()) > 0)
                    {
                        if (Convert.ToDecimal(dvRecble[rcvble_ctr]["bal_amount"]) - Convert.ToDecimal(dvRecble[rcvble_ctr]["app_amount"]) > balamt)
                        {
                            dvRecble[rcvble_ctr]["app_amount"] = Convert.ToDecimal(dvRecble[rcvble_ctr]["app_amount"]) + balamt;
                            balamt = 0;
                            dvRecble[rcvble_ctr].EndEdit();
                        }
                        else
                        {
                            decimal balamt1;
                            balamt1 = Convert.ToDecimal(dvRecble[rcvble_ctr]["bal_amount"]) - Convert.ToDecimal(dvRecble[rcvble_ctr]["app_amount"]);
                            dvRecble[rcvble_ctr]["app_amount"] = Convert.ToDecimal(dvRecble[rcvble_ctr]["bal_amount"]);
                            balamt = balamt - balamt1;
                            if (dvRecble.Count > rcvble_ctr + 1)
                                rcvble_ctr++;
                            else
                            {
                                break;
                                exit = true;
                            }

                        }
                    }
                    else
                    {
                        if (dvRecble.Count > rcvble_ctr + 1)
                            rcvble_ctr++;
                        else
                        {
                            break;
                            exit = true;
                        }
                    }
                }
                if (exit)
                    break;
            }

            foreach (DataRowView rowRecble in dvRecble)
            {
                DataRow rowView =   dtAddCashReceipt.AsEnumerable()
                                     .Where(p => p.Field<string>("ref_type") == rowRecble["ref_type"].ToString() &&
                                     p.Field<string>("ref_no") == rowRecble["ref_no"].ToString())
                                     .FirstOrDefault();
                if (rowView != null)
                {
                    rowView["app_amount"] = Convert.ToDecimal(rowRecble["app_amount"]);
                    rowView.EndEdit();
                }

            }
        }
        private void txtReceiptNo_Validated(object sender, EventArgs e)
        {
            this.txtAdjRcvableNo.IsReadOnly = true;
        }

        private void txtEntryDate_Validated(object sender, EventArgs e)
        {


            if (rowIndex > 0)
            {
                dtAddCashReceipt.Rows[rowIndex].SetField(2, this.txtEntryDate.Value);

                radGridView1.CurrentRow = radGridView1.Rows[rowIndex];
            }
        }

        private DataRowView GetFilteredRow(DataView dvFilter, string reftype, string payno, string invno)
        {
            dvFilter.RowFilter = string.Format("rtv_pay='{0}' and pay_no = '{1}' and inv_no = '{2}'", reftype, payno, invno);
            if (dvFilter.Count > 0)
            {
                return dvFilter[0];
            }
            return null;
        }

        private void frmAddCashReceipt_Load(object sender, EventArgs e)
        {

        }

        private void chkShowMemo_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            InitializaGrid();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            using (frmSelectCustomer objSearchForm = new frmSelectCustomer())
            {
                objSearchForm.StartPosition = FormStartPosition.CenterParent;
                
                objSearchForm.ShowDialog(this);
                
                if (objSearchForm.DialogResult == DialogResult.OK)
                {
                    if (objSearchForm.ReturnValue != null)
                    {
                        this.txtBillingAcctNo.Text = objSearchForm.ReturnValue["acc"].ToString();
                        InitializaGrid();
                    }

                }
            }
        }

        private void txtReceiptNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
