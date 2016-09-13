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
    public partial class frmAddEditCredit : Telerik.WinControls.UI.RadForm
    {
        
        private ICustomerService customerService;
        private IReceiptService receiptService;
        private bool is_cancelled = true;
        private int rowIndex = -1;
        DataTable dtAddCashReceipt;
        private string credit_no;
        private bool is_edit = false;
        public frmAddEditCredit()
        {
            InitializeComponent();
            this.credit_no = Helper.GetNextCreditNo();
            this.txtCreditNo.Text = credit_no;
            receiptService = new ReceiptService();
            customerService = new CustomerService();
          

            this.txtDate.Value = DateTime.Now;
            this.txtRefDate.Value = DateTime.Now;

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
            if ((app_amount != 0) && (Math.Abs(app_amount) > Math.Abs(balamount) || Math.Sign(app_amount) != Math.Sign(balamount)))
            {
                Helper.MsgBox(string.Format("Applied Applid Amount, Must be Between 0 and {0}", balamount), RadMessageIcon.Info);
                e.Row["APP_AMOUNT"] = e.Row["APP_AMOUNT", DataRowVersion.Original];
            }
            object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV' OR ref_type='FAKE'");
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

                
                DataTable dtGetReceiptData = receiptService.GetCreditData(this.txtBillingAcctNo.Text, this.txtCreditNo.Text);
                dtAddCashReceipt.Merge(dtGetReceiptData);
                foreach (DataRow drRow in dtAddCashReceipt.Rows)
                {
                    drRow["APPAMT"] = drRow["APP_AMOUNT"];
                    drRow.EndEdit();
                }
                if (!chkShowMemo.Checked)
                {
                    dtAddCashReceipt = dtGetReceiptData.Select("REF_TYPE <> 'MEMO'", "ref_date asc, IREFNO asc").CopyToDataTable();
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
            DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to cancel the changes?", "Add Customer Credit", MessageBoxButtons.YesNo, RadMessageIcon.Question);
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
                int t_receiptno;
                if (int.TryParse(this.txtCreditNo.Text, out t_receiptno))
                {
                    Helper.CheckCreditSequence(t_receiptno);
                }
            }
        }

        private void txtBillingAcctNo_Validated(object sender, EventArgs e)
        {
            

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

        private void txtCheckAmount_Click(object sender, EventArgs e)
        {

        }

        private void txtCheckAmount_Validated(object sender, EventArgs e)
        {
            decimal paidamt = Convert.ToDecimal(this.txtAmount.Value) ;
            if (rowIndex > 0)
            {
                dtAddCashReceipt.Rows[rowIndex].SetField(3, paidamt );
                dtAddCashReceipt.Rows[rowIndex].SetField(4, paidamt * -1);
                dtAddCashReceipt.Rows[rowIndex].SetField(5, paidamt * -1);
                radGridView1.CurrentRow = radGridView1.Rows[rowIndex];
            }
        }

        private void txtDiscountTaken_Validated(object sender, EventArgs e)
        {
            decimal paidamt = Convert.ToDecimal(this.txtAmount.Value);
            if (rowIndex > 0)
            {
                dtAddCashReceipt.Rows[rowIndex].SetField(4, paidamt * -1);
                dtAddCashReceipt.Rows[rowIndex].SetField(5, paidamt * -1);
                radGridView1.CurrentRow = radGridView1.Rows[rowIndex];
            }
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {

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
            if (string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {
                Helper.MsgBox("Billing Account no. cannot be empty", RadMessageIcon.Info);
                this.txtBillingAcctNo.Focus();
                return;
            }

          
            dtAddCashReceipt.ColumnChanged -= new DataColumnChangeEventHandler(Column_Changed);

            object ctotal = dtAddCashReceipt.Compute("SUM(app_amount)", "1=1");
            object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
            object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");
            object capplied = dtAddCashReceipt.Compute("SUM(app_amount)", "appflg='C'");

            if (Convert.ToDecimal(capplied) == Convert.ToDecimal(credits) && Convert.ToDecimal(debits) == 0)
            {
                dtAddCashReceipt.Rows[rowIndex].SetField(5, 0);
                ctotal = dtAddCashReceipt.Compute("SUM(app_amount)", "1=1");

            }

            if (Convert.ToDecimal(ctotal) != 0)
            {
                Helper.MsgBox("Credits Must match Debits", RadMessageIcon.Info);
                return;
            }



            string error = string.Empty;
            DataTable dtCredit = dtAddCashReceipt.Copy();
            dtCredit.Columns.Remove("RSORT");
            dtCredit.Columns.Remove("IREFNO");
            dtCredit.AcceptChanges();

            if (this.receiptService.SaveCredit(dtCredit, this.txtBillingAcctNo.Text, this.txtCreditNo.Text, this.txtDate.Value, this.txtRefDate.Value, this.txtNote.Text, Convert.ToDecimal(this.txtAmount.Value), "A", this.chkShowMemo.Checked, out error))
            {
                Helper.AddKeepRec(string.Format("{0} Credit {1}", is_edit ? "Edit" : "Add", this.txtCreditNo.Text));
                this.is_cancelled = false;
                this.is_edit = false;
                DataRow drCredit = this.receiptService.GetCredit(this.txtCreditNo.Text);

                var list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("rpTest", "Test Param"));
               
                
                frmPrintCredit objPrintReceipt = new frmPrintCredit(this.txtCreditNo.Text,list);
                objPrintReceipt.StartPosition = FormStartPosition.CenterScreen;

                DialogResult dialogResult = objPrintReceipt.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    objPrintReceipt.Close();
                }

                this.txtCreditNo.Text = Helper.GetNextCreditNo();
                this.credit_no = this.txtCreditNo.Text;
                this.is_cancelled = true;
                this.txtAmount.Value = 0;
             
                this.txtCredits.Value = 0;
                this.txtDebits.Value = 0;
                this.txtDifference.Value = 0;
                this.txtBillingAcctNo.Text = string.Empty;
                this.txtCreditNo.Focus();
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
            if (Convert.ToDecimal(this.txtAmount.Value) <= 0)
            {
                Helper.MsgBox("Please enter amount.", RadMessageIcon.Info);
                this.txtAmount.Focus();
                return;
            }
            DataView dvPayble = new DataView(dtAddCashReceipt);
            dvPayble.RowFilter = "(ref_type = 'RTV' OR ref_type = 'CREDIT' OR ref_type = 'PAYMENT' OR ref_type='FAKE') AND app_amount <> 0";
            dvPayble.Sort = "ref_date  ASC";

            DataView dvRecble = new DataView(dtAddCashReceipt);
            dvRecble.RowFilter = "(ref_type='INVOICE' OR ref_type='MEMO' )";
            dvRecble.Sort = "ref_date  ASC";
            int rcvble_ctr = 0;
            bool exit = false;

            foreach (DataRowView rowRecble in dvRecble)
            {
                rowRecble["app_amount"] = 0;
            }

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
           

        }

        private void txtEntryDate_Validated(object sender, EventArgs e)
        {

            if (dtAddCashReceipt != null)
            { 
                if (rowIndex > 0 && dtAddCashReceipt.Rows.Count > 0)
                {
                    dtAddCashReceipt.Rows[rowIndex].SetField(2, this.txtDate.Value);

                    radGridView1.CurrentRow = radGridView1.Rows[rowIndex];
                }
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
                        this.lblCustomerName.Text = objSearchForm.ReturnValue["name"].ToString();
                        InitializaGrid();
                    }

                }
                else
                {
                    this.lblCustomerName.Text = string.Empty;
                }
            }
        }

        private void radLabel8_Click(object sender, EventArgs e)
        {

        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtCreditNo_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(this.txtCreditNo.Text) > Convert.ToInt32(this.credit_no))
            {
                Helper.MsgBox("Can not Skip Credit#");
                this.txtCreditNo.Text = this.credit_no;
                e.Cancel = true;
            }

            DataRow drPayment = this.receiptService.GetPayment(this.txtCreditNo.Text, "C");
            if (drPayment != null)
            {
                if (Convert.ToDecimal(drPayment["applied"]) != 0)
                {
                    Helper.MsgBox("Applied Credit May Not Be Edited", RadMessageIcon.Info);
                    this.txtCreditNo.Text = this.credit_no;
                    e.Cancel = true;
                    int t_receiptno;
                    if (int.TryParse(this.txtCreditNo.Text, out t_receiptno))
                    {
                        Helper.CheckCreditSequence(t_receiptno);
                       
                    }
                    this.txtCreditNo.Text = Helper.GetNextCreditNo();
                    return;
                }

            }
            DataRow drCredit = this.receiptService.GetCredit(this.txtCreditNo.Text);
            if (drCredit != null)
            {
                DialogResult dialogResult = RadMessageBox.Show("This Credit Exists Already, Would You Like To Edit It?", "Add Customer Credit", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    is_edit = true;
                    this.txtRefDate.Value = Convert.ToDateTime(drCredit["ref_date"]);
                    this.txtBillingAcctNo.Text = drCredit["acc"].ToString();
                    this.txtBillingAcctNo.IsReadOnly = true;
                    string cred_code = drCredit["cred_code"].ToString().ToUpper().Trim();
                    if (cred_code == "A")
                        this.radCreditCodeA.IsChecked = true;
                    else if (cred_code == "B")
                        this.radCreditCodeB.IsChecked = true;
                    else if (cred_code == "C")
                        this.radCreditCodeC.IsChecked = true;
                    else
                        this.radCreditCodeA.IsChecked = true;

                    this.txtAmount.Value = Convert.ToDecimal(drCredit["amount"]);
                    this.txtDate.Value = Convert.ToDateTime(drCredit["date"]);
                    this.txtNote.Text = drCredit["note"].ToString();
                    this.chkShowMemo.Checked = drCredit["showmemo"] != DBNull.Value ? true : Convert.ToBoolean(drCredit["showmemo"]);
                }
                else
                    is_edit = false;
            }
           
        }

        private void txtBillingAcctNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {
                DataRow billAcctRow = this.customerService.CheckValidBillingAcct(this.txtBillingAcctNo.Text);
                if (billAcctRow == null)
                {
                    this.lblCustomerName.Text = string.Empty;

                    Helper.MsgBox("Invalid Billing Account", Telerik.WinControls.RadMessageIcon.Info);

                    dtAddCashReceipt.Clear();
                    e.Cancel = true;
                }
                else
                {
                    this.lblCustomerName.Text = billAcctRow["name"].ToString();
                    InitializaGrid();

                }
            }
            else
            {
                this.lblCustomerName.Text = string.Empty;
            }
        }
    }
}
