// -----------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.BusinessService
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using IshalInc.wJewel.Data.DataAccess;
    using IshalInc.wJewel.Data.DataModel;

    /// <summary>
    /// class to query the DataAccess, implements ICustomerService interface
    /// </summary>
    public class ReceiptService : IReceiptService
    {
        /// <summary>
        /// interface of BankAccAccess
        /// </summary>
        private IReceiptAccess receiptAccess;

        public ReceiptService()
        {
            this.receiptAccess = new ReceiptAccess();
        }


        public DataTable GetReceiptData(string acc, string receipt_no)
        {
            return this.receiptAccess.GetReceiptData(acc, receipt_no);
        }

        public DataTable GetAdjReceivableData(string acc)
        {
            return this.receiptAccess.GetAdjReceivableData(acc);
        }

        public DataTable GetReceiptEditData(string acc, string receipt_no)
        {
            return this.receiptAccess.GetReceiptEditData(acc, receipt_no);
        }

        public bool SaveReceipt(DataTable dtPayment,string acc, string receipt_no, DateTime? pay_date, DateTime? chk_date, string bank, decimal chk_amt, decimal discount,bool showmemo, out string error)
        {
            error = string.Empty;
            return this.receiptAccess.SaveReceipt(dtPayment, acc, receipt_no, pay_date, chk_date, bank, chk_amt, discount, showmemo, out error);
        }

        public bool EditReceipt(DataTable dtPayment, string acc, string receipt_no, DateTime? pay_date, DateTime? chk_date, string bank, decimal chk_amt, decimal discount, out string error)
        {
            error = string.Empty;
            return this.receiptAccess.EditReceipt(dtPayment, acc, receipt_no, pay_date, chk_date, bank, chk_amt, discount,out error);
        }

        public DataTable GetPayItems(string pay_no)
        {
            return this.receiptAccess.GetPayItems(pay_no);

        }

        public DataTable GetPayItemsInvno(string inv_no)
        {
            return this.receiptAccess.GetPayItemsInvNo(inv_no);

        }

        public DataRow GetPayment(string inv_no)
        {
           return this.receiptAccess.GetPayment(inv_no);
        }

        public DataRow GetPayment(string inv_no,string rtv_pay)
        {
            return this.receiptAccess.GetPayment(inv_no, rtv_pay);
        }


        public DataTable GetCreditPayment(string inv_no, string rtv_pay)
        {
            return this.receiptAccess.GetCreditPayment(inv_no, rtv_pay);
        }

        public bool DeleteReceipt(string acc, string receipt_no, decimal paid, string transact, out string error)
        {
            return this.receiptAccess.DeleteReceipt(acc, receipt_no,paid,transact, out error);
        }

        public bool DeleteCredit(string acc, string receipt_no, decimal paid, out string error)
        {
            return this.receiptAccess.DeleteCredit(acc, receipt_no, paid, out error);
        }

        public DataTable GetCreditData(string acc, string receipt_no)
        {
            return this.receiptAccess.GetCreditData(acc, receipt_no);
        }

        public bool SaveCredit(DataTable dtPayment, string acc, string credit_no, DateTime? date, DateTime? ref_date, string note, decimal amt, string cred_code, bool showmemo, out string error)
        {
            error = string.Empty;
            return this.receiptAccess.SaveCredit(dtPayment, acc, credit_no, date, ref_date, note, amt, cred_code, showmemo, out error);
        }

        public DataRow GetCredit(string inv_no)
        {
            return this.receiptAccess.GetCredit(inv_no);
        }

        public DataTable GetCreditDetails(string inv_no)
        {
            return this.receiptAccess.GetCreditDetails(inv_no);
        }

        public DataTable GetCashCreditByCustRef(string acc, string check_no)
        {
            return this.receiptAccess.GetCashCreditByCustRef(acc, check_no);
        }

        public bool SaveAdjRcvable(DataTable dtPayment, string acc, string adj_no, DateTime? entry_date, bool showmemo, out string error)
        {
            error = string.Empty;
            return this.receiptAccess.SaveAdjRcvable(dtPayment, acc, adj_no, entry_date, showmemo, out error);
        }

        public bool EditAdjRcvanble(DataTable dtPayment, string acc, string adj_no, DateTime? entry_date, out string error)
        {
            error = string.Empty;
            return this.receiptAccess.EditAdjRcvanble(dtPayment, acc, adj_no, entry_date, out error);

        }

        public DataTable GetRcvableCreditByTimeFrame(string acc1, string acc2, string datetype, string date1, string date2, string trantype)
        {
            return this.receiptAccess.GetRcvableCreditByTimeFrame(acc1, acc2, datetype, date1, date2, trantype);
        }
    }
            
}
