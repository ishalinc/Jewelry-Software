// -----------------------------------------------------------------------
// <copyright file="IBankAcc.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.DataAccess
{
    using System;
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;

    /// <summary>
    /// Interface ISalesmen
    /// </summary>
    public interface ISalesmenAccess
    {
        
        DataTable GetSalesmenCodes();

        DataTable GetSalesmenCreditByCreditCode(string salesmen,string fromCustomer,string toCustomer,string fromDate, string toDate);

        DataTable CheckValidSalesmanLog(string logno);

        DataRow GetSalesmanStyleData(string invno, string style, string invstyle, string line_no, string size, int qty, decimal weight);

        bool SaveInventory(DataTable dtSalesInventory, out string error);
        DataTable GetSalesmanInvetoryReport(string inv_no);

        bool CancelSalesmanItems(string inv_no, out string error);

        DataTable GetSalesmanInvByLineAndStyle(string salesmen, string fromStyle, string toStyle, decimal pricecode);

        DataTable StyleTrackingSlsInv(string style);

        bool CheckSlsInvStyle(string style);

        bool ClearSalesmanLine(string salesmancode, out string error);

        DataTable SlsHistory(string salesmancode, string style);

        int GetSlsAllotedQtyByStyle(string style, string line_no);

        bool ReturnLog(string logno,string salesmancode, out string error,out string retlogno);

        bool FixSls(string salesmancode, out string error);

        DataTable SummarySlsHistory(string salesmancode);
    }
}
