// -----------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.BusinessService
{
    using System;
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;

    /// <summary>
    /// Interface IBankAccService
    /// </summary>
    public interface IReceiptService
    {


        DataTable GetReceiptData(string acc,string receipt_no);

        DataTable GetAdjReceivableData(string acc);

        DataTable GetReceiptEditData(string acc, string receipt_no);
        bool SaveReceipt(DataTable dtPayment, string acc, string receipt_no, DateTime? pay_date, DateTime? chk_date, string bank, decimal chk_amt, decimal discount,bool showmemo, out string error);

        bool EditReceipt(DataTable dtPayment, string acc, string receipt_no, DateTime? pay_date, DateTime? chk_date, string bank, decimal chk_amt, decimal discount, out string error);
        DataTable GetPayItems(string pay_no);

        DataTable GetPayItemsInvno(string inv_no);

        DataRow GetPayment(string inv_no);

        DataRow GetPayment(string inv_no, string rtv_pay);

        DataTable GetCreditPayment(string inv_no, string rtv_pay);

        bool DeleteReceipt(string acc, string receipt_no, decimal paid, string transact, out string error);

        bool DeleteCredit(string acc, string receipt_no, decimal paid, out string error);

        DataTable GetCreditData(string acc, string receipt_no);

        bool SaveCredit(DataTable dtPayment, string acc, string credit_no, DateTime? date, DateTime? ref_date, string note, decimal amt, string cred_code, bool showmemo, out string error);

        DataRow GetCredit(string inv_no);

        DataTable GetCreditDetails(string inv_no);

        DataTable GetCashCreditByCustRef(string acc, string check_no);

        bool SaveAdjRcvable(DataTable dtPayment, string acc, string adj_no, DateTime? entry_date, bool showmemo, out string error);

        bool EditAdjRcvanble(DataTable dtPayment, string acc, string adj_no, DateTime? entry_date, out string error);

        DataTable GetRcvableCreditByTimeFrame(string acc1, string acc2, string datetype, string date1, string date2, string trantype);
    }
}