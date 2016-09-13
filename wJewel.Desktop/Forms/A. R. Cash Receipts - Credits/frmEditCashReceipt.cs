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
    public partial class frmEditCashReceipt : Telerik.WinControls.UI.RadForm
    {
        private IBankAccService bankAccService;
        private ICustomerService customerService;
        private IReceiptService receiptService;
        private bool is_cancelled = true;
        private int rowIndex = -1;
        DataTable dtAddCashReceipt;
        public frmEditCashReceipt()
        {
            InitializeComponent();
            
            bankAccService = new BankAccService();
            receiptService = new ReceiptService();
            customerService = new CustomerService();
            DataTable dtBankAcc = this.bankAccService.GetBankAcc();

            this.ddlBankAcc.DataMember = "code";
            this.ddlBankAcc.ValueMember = "code";
            this.ddlBankAcc.DataSource = dtBankAcc;
            this.ddlBankAcc.AutoCompleteDataSource = dtBankAcc;

            this.txtEntryDate.Value = DateTime.Now;
            this.txtDepositDate.Value = DateTime.Now;

            dtAddCashReceipt = new DataTable();
            dtAddCashReceipt.Columns.Add("REF_TYPE", typeof(string));
            dtAddCashReceipt.Columns.Add("REF_NO", typeof(string));
            dtAddCashReceipt.Columns.Add("REF_DATE", typeof(DateTime));
            dtAddCashReceipt.Columns.Add("ORIGINAL", typeof(decimal));
            dtAddCashReceipt.Columns.Add("BAL_AMOUNT", typeof(decimal));
            dtAddCashReceipt.Columns.Add("APP_AMOUNT", typeof(decimal));
            dtAddCashReceipt.Columns.Add("APPAMT", typeof(decimal));
            dtAddCashReceipt.Columns.Add("APPFLG", typeof(string));

            this.btnSave.ButtonElement.ForeColor = Color.Green;
            this.btnSave.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnClose.ButtonElement.ForeColor = Color.Red;
            this.btnClose.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;


            this.radGridView1.CurrentColumnChanged += new Telerik.WinControls.UI.CurrentColumnChangedEventHandler(radGridView1_CurrentColumnChanged);

            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
            radGridView1.GridBehavior = new AddReceiptGridBehavior();
            InitializaGrid();
        }

        private void radGridView1_CurrentColumnChanged(object sender, Telerik.WinControls.UI.CurrentColumnChangedEventArgs e)
        {


        }

        private void Column_Changed(object sender, DataColumnChangeEventArgs e)
        {
            decimal balamount = 0, app_amount = 0;
            if (!DBNull.Value.Equals(e.Row["BAL_AMOUNT"]))
                balamount = Convert.ToDecimal(e.Row["BAL_AMOUNT"]) ;
            else
                e.Row["BAL_AMOUNT"] = 0;

            if (!DBNull.Value.Equals(e.Row["APP_AMOUNT"]))
                app_amount = Convert.ToDecimal(e.Row["APP_AMOUNT"]);
            else
                e.Row["APP_AMOUNT"] = 0;

            if ((app_amount != 0) && (Math.Abs(app_amount) > Math.Abs(balamount) || Math.Sign(app_amount) != Math.Sign(balamount)))
            {
                Helper.MsgBox(string.Format("Applied Applid Amount, Must be Between 0 and {0}", balamount), RadMessageIcon.Info);
                e.Row["APP_AMOUNT"] = e.Row["APP_AMOUNT", DataRowVersion.Original];
            }
            object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
            object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");

           

            this.txtCredits.Text = string.Format("{0:c}", Convert.ToDecimal(credits) * -1);
            this.txtDebits.Text = string.Format("{0:c}", debits);
            this.txtDifference.Value = Convert.ToDecimal(credits) * -1 - Convert.ToDecimal(debits);

            e.Row.EndEdit();


        }

        private void InitializaGrid()
        {

            dtAddCashReceipt.Rows.Clear();

            if (!string.IsNullOrEmpty(this.txtReceiptNo.Text))
            {


                DataTable dtGetReceiptData = receiptService.GetReceiptEditData(this.txtBillingAcctNo.Text, this.txtReceiptNo.Text);
                dtAddCashReceipt.Merge(dtGetReceiptData);
                foreach (DataRow drRow in dtAddCashReceipt.Rows)
                {
                    drRow["APPAMT"] = drRow["APP_AMOUNT"];
                    drRow.EndEdit();
                }
                dtAddCashReceipt.AcceptChanges();

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
                catch(Exception ex)
                {
                    Helper.MsgBox(ex.Message);
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
                int t_receiptno;
                if (int.TryParse(this.txtReceiptNo.Text, out t_receiptno))
                {
                    Helper.CheckReceiptSequence(t_receiptno);
                }
            }
        }

        private void txtBillingAcctNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBillingAcctNo.Text))
            {
                DataRow billAcctRow = this.customerService.CheckValidBillingAcct(this.txtBillingAcctNo.Text);
                if (billAcctRow == null)
                {
                    this.lblCustomerName.Text = string.Empty;

                    Helper.MsgBox("Invalid Billing Account", Telerik.WinControls.RadMessageIcon.Info);
                    dtAddCashReceipt.Clear();
                 

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
            decimal paidamt = Convert.ToDecimal(this.txtCheckAmount.Value) + Convert.ToDecimal(this.txtDiscountTaken.Value);
            if (rowIndex > 0)
            {
                dtAddCashReceipt.Rows[rowIndex].SetField(3, paidamt);
                dtAddCashReceipt.Rows[rowIndex].SetField(4, paidamt * -1);
               // dtAddCashReceipt.Rows[rowIndex].SetField(5, paidamt * -1);
                radGridView1.CurrentRow = radGridView1.Rows[rowIndex];
            }
        }

        private void txtDiscountTaken_Validated(object sender, EventArgs e)
        {
            decimal paidamt = Convert.ToDecimal(this.txtCheckAmount.Value) + Convert.ToDecimal(this.txtDiscountTaken.Value);
            if (rowIndex > 0)
            {
                dtAddCashReceipt.Rows[rowIndex].SetField(3, paidamt );
                dtAddCashReceipt.Rows[rowIndex].SetField(4, paidamt * -1);
             //   dtAddCashReceipt.Rows[rowIndex].SetField(5, paidamt * -1);
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

            if (string.IsNullOrEmpty(this.ddlBankAcc.Text))
            {
                Helper.MsgBox("Deposit to Cannot be empty", RadMessageIcon.Info);
                this.ddlBankAcc.Focus();
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

            /*
            if (radGridView1.Rows.Count > 0)
            {
                try
                {
                    GridViewRowInfo row = (from p in radGridView1.Rows
                                           where p.Cells[0].Value.ToString() == "PAYMENT" && p.Cells[1].Value.ToString() == this.txtReceiptNo.Text
                                           select p).Single();

                    row.Cells[5].Value = Convert.ToDecimal(row.Cells[5].Value) - (Convert.ToDecimal(credits) + Convert.ToDecimal(debits));
                    row.Cells[5].EndEdit();
                    credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
                    credits = Convert.ToDecimal(credits) * -1;

                }
                catch
                {

                }
            }
            */
           

            string error;
            if (this.receiptService.SaveReceipt(dtAddCashReceipt, this.txtBillingAcctNo.Text, this.txtReceiptNo.Text, this.txtEntryDate.Value, this.txtEntryDate.Value, this.ddlBankAcc.Text, Convert.ToDecimal(this.txtCheckAmount.Value), Convert.ToDecimal(this.txtDiscountTaken.Value), false,out error))
            {
                Helper.AddKeepRec("Edit. Rcpt. " + this.txtReceiptNo.Text);

                DataRow drPayment = this.receiptService.GetPayment(this.txtReceiptNo.Text);

                var list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("rpCustomer", drPayment["acc"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpEntryDate", string.Format("{0:MM/dd/yyyy}", drPayment["date"].ToString())));
                list.Add(new KeyValuePair<string, string>("rpCheckDate", string.Format("{0:MM/dd/yyyy}", drPayment["chk_date"].ToString())));
                list.Add(new KeyValuePair<string, string>("rpDepositedTo", drPayment["bank"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpTransactNo", drPayment["transact"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpRecvNo", drPayment["inv_no"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpCheckNo", drPayment["check_no"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpAmount", string.Format("{0:0.00}", Convert.ToDecimal(drPayment["chk_amt"]))));
                list.Add(new KeyValuePair<string, string>("rpDiscountTaken", string.Format("{0:0.00}", Convert.ToDecimal(drPayment["discount"]))));

                
                frmPrintReceipt objPrintReceipt = new frmPrintReceipt(this.txtReceiptNo.Text, list);
                objPrintReceipt.StartPosition = FormStartPosition.CenterScreen;
               
               

                DialogResult dialogResult = objPrintReceipt.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    objPrintReceipt.Close();
                }

                this.txtReceiptNo.Text = string.Empty;
                this.txtCheckAmount.Value = 0;
                this.txtDiscountTaken.Value = 0;
                this.txtCredits.Value = 0;
                this.txtDebits.Value = 0;
                this.txtDifference.Value = 0;
                this.txtBillingAcctNo.Text = string.Empty;
                this.ddlBankAcc.SelectedIndex = -1;
                this.txtEntryDate.SetToNullValue();
                this.txtDepositDate.SetToNullValue();
                this.txtReceiptNo.Focus();
                dtAddCashReceipt.Clear();

            }
            else
                Helper.MsgBox(string.Format("Unable to Save Receipt - {0}", error), RadMessageIcon.Error);
        }

     
        private void txtReceiptNo_Validated(object sender, EventArgs e)
        {
            
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

        private void txtReceiptNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReceiptNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtReceiptNo.Text))
            {
                DataRow drPayment = this.receiptService.GetPayment(this.txtReceiptNo.Text);
                if (drPayment == null)
                {
                    Helper.MsgBox("Invalid Rcvable No.", RadMessageIcon.Info);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(drPayment["acc"].ToString()))
                    {
                        Helper.MsgBox("Cannot Edit This Rcvable", RadMessageIcon.Info);
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        this.txtBillingAcctNo.Enabled = true;
                        this.txtBillingAcctNo.Text = drPayment["acc"].ToString();
                        this.txtCheckAmount.Value = Convert.ToDecimal(drPayment["chk_amt"].ToString());
                        this.txtDiscountTaken.Value = Convert.ToDecimal(drPayment["discount"].ToString());
                        this.txtCustomerCheckNo.Text = drPayment["check_no"].ToString();
                        this.ddlBankAcc.SelectedValue = drPayment["bank"].ToString();

                        DateTime? entryDate, depositDate;
                        if (!string.IsNullOrEmpty(drPayment["date"].ToString()))
                            entryDate = Convert.ToDateTime(drPayment["date"].ToString());
                        else
                            entryDate = null;

                        if (entryDate == null)
                            this.txtEntryDate.SetToNullValue();
                        else
                            this.txtEntryDate.Value = (DateTime)entryDate;

                        if (!string.IsNullOrEmpty(drPayment["chk_date"].ToString()))
                            depositDate = Convert.ToDateTime(drPayment["chk_date"].ToString());
                        else
                            depositDate = null;

                        if (depositDate == null)
                            this.txtDepositDate.SetToNullValue();
                        else
                            this.txtDepositDate.Value = (DateTime)depositDate;

                        InitializaGrid();
                        object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
                        object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");
                        this.txtCredits.Text = string.Format("{0:c}", Convert.ToDecimal(credits) * -1);
                        this.txtDebits.Text = string.Format("{0:c}", debits);
                        this.txtDifference.Value = Convert.ToDecimal(credits) * -1 - Convert.ToDecimal(debits);
                        this.txtBillingAcctNo.IsReadOnly = true;
                    }
                }
            }
        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }
    }
}
