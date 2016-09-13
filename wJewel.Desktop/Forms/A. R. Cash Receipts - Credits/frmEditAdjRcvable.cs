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
    public partial class frmEditAdjRcvable : Telerik.WinControls.UI.RadForm
    {
       
        private ICustomerService customerService;
        private IReceiptService receiptService;
        private bool is_cancelled = true;
        private int rowIndex = -1;
        DataTable dtAddCashReceipt;
        public frmEditAdjRcvable()
        {
            InitializeComponent();
            
           
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
            decimal balamount, app_amount;
            balamount = Convert.ToDecimal(e.Row["BAL_AMOUNT"]);
            app_amount = Convert.ToDecimal(e.Row["APP_AMOUNT"]);
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

        }

        private void InitializaGrid()
        {

            dtAddCashReceipt.Rows.Clear();

            if (!string.IsNullOrEmpty(this.txtReceiptNo.Text))
            {


                DataTable dtGetReceiptData = receiptService.GetReceiptEditData(this.txtBillingAcctNo.Text, this.txtReceiptNo.Text);
                dtAddCashReceipt.Merge(dtGetReceiptData);

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
            radGridView1.Columns[3].FormatString = "{0:c}";
            radGridView1.Columns[4].HeaderText = "Balance";
            radGridView1.Columns[4].FormatString = "{0:c}";
            radGridView1.Columns[5].HeaderText = "Applied";
            radGridView1.Columns[5].FormatString = "{0:c}";
            radGridView1.Columns[6].IsVisible = false;
            radGridView1.Columns[7].IsVisible = false;
            
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
            object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
            credits = Convert.ToDecimal(credits) * -1;
            object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");

           
            if (Convert.ToDecimal(credits) != Convert.ToDecimal(debits))
            {
                Helper.MsgBox("Credits Must match Debits", RadMessageIcon.Info);
                return;
            }

            string error;
            if (this.receiptService.EditAdjRcvanble(dtAddCashReceipt, this.txtBillingAcctNo.Text, this.txtReceiptNo.Text, this.txtEntryDate.Value, out error))
            {
                Helper.AddKeepRec("Edit Adj. Rcvable" + this.txtReceiptNo.Text);
                DataRow drPayment = this.receiptService.GetPayment(this.txtReceiptNo.Text,"F");

                var list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("rpCustomer", drPayment["acc"].ToString()));
                list.Add(new KeyValuePair<string, string>("rpEntryDate", string.Format("{0:MM/dd/yyyy}", drPayment["date"].ToString())));
                list.Add(new KeyValuePair<string, string>("rpRecvNo", drPayment["inv_no"].ToString()));
               
                
                frmPrintAdjRcvable objAdjRcvable = new frmPrintAdjRcvable(this.txtReceiptNo.Text, list);
                objAdjRcvable.StartPosition = FormStartPosition.CenterScreen;
               
               

                DialogResult dialogResult = objAdjRcvable.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    objAdjRcvable.Close();
                }

                this.txtReceiptNo.Text = string.Empty;
               
                this.txtCredits.Value = 0;
                this.txtDebits.Value = 0;
                this.txtDifference.Value = 0;
                this.txtBillingAcctNo.Text = string.Empty;
               
                this.txtEntryDate.SetToNullValue();
               
                this.txtReceiptNo.Focus();
                dtAddCashReceipt.Clear();

            }
            else
                Helper.MsgBox(string.Format("Unable to Save Receipt - {0}", error), RadMessageIcon.Error);
        }

     
        private void txtReceiptNo_Validated(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtReceiptNo.Text))
            {
                DataRow drPayment = this.receiptService.GetPayment(this.txtReceiptNo.Text,"F");
                if (drPayment == null)
                {
                    Helper.MsgBox("Invalid Rcvable No.", RadMessageIcon.Info);
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(drPayment["acc"].ToString()))
                    {
                        Helper.MsgBox("Cannot Edit This Rcvable", RadMessageIcon.Info);
                        return;
                    }
                    else
                    {
                        this.txtBillingAcctNo.Enabled = true;
                        this.txtBillingAcctNo.Text = drPayment["acc"].ToString();
                     

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

                   

                        InitializaGrid();
                        object credits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Payment' OR ref_type='Credit' OR ref_type='RTV'");
                        object debits = dtAddCashReceipt.Compute("SUM(app_amount)", "ref_type='Invoice' OR ref_type='Memo'");
                        this.txtCredits.Text = string.Format("{0:c}", Convert.ToDecimal(credits) * -1);
                        this.txtDebits.Text = string.Format("{0:c}", debits);
                        this.txtDifference.Value = Convert.ToDecimal(credits) * -1 - Convert.ToDecimal(debits);
                        this.txtBillingAcctNo.Enabled = false;
                    }
                }
            }
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

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
