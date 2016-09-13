// -----------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.BusinessService
{
    using System.Data;
    using IshalInc.wJewel.Data.DataAccess;
    using IshalInc.wJewel.Data.DataModel;

    /// <summary>
    /// class to query the DataAccess, implements ICustomerService interface
    /// </summary>
    public class SalesmenService : ISalesmenService
    {
        /// <summary>
        /// interface of BankAccAccess
        /// </summary>
        private ISalesmenAccess salesmenAccess;

        public SalesmenService()
        {
            this.salesmenAccess = new SalesmenAccess();
        }


        public DataTable GetSalesmenCodes()
        {
            return this.salesmenAccess.GetSalesmenCodes();
        }

        public DataTable GetSalesmenCreditByCreditCode(string salesmen, string fromCustomer, string toCustomer, string fromDate, string toDate)
        {
            return this.salesmenAccess.GetSalesmenCreditByCreditCode(salesmen, fromCustomer, toCustomer, fromDate, toDate);
        }

        public DataTable CheckValidSalesmanLog(string logno)
        {
            return this.salesmenAccess.CheckValidSalesmanLog(logno);
        }

        public DataRow GetSalesmanStyleData(string invno, string style, string invstyle, string line_no, string size, int qty, decimal weight)
        {
           return this.salesmenAccess.GetSalesmanStyleData(invno, style, invstyle, line_no, size, qty, weight);
        }

        public bool SaveInventory(DataTable dtSalesInventory, out string error)
        {
            return this.salesmenAccess.SaveInventory(dtSalesInventory, out error);
        }

        public DataTable GetSalesmanInvetoryReport(string inv_no)
        {
            return this.salesmenAccess.GetSalesmanInvetoryReport(inv_no);
        }

        public bool CancelSalesmanItems(string inv_no, out string error)
        {
            return this.salesmenAccess.CancelSalesmanItems(inv_no, out error);
        }

        public DataTable GetSalesmanInvByLineAndStyle(string salesmen, string fromStyle, string toStyle, decimal pricecode)
        {
            return this.salesmenAccess.GetSalesmanInvByLineAndStyle(salesmen, fromStyle, toStyle, pricecode);
        }

        public DataTable StyleTrackingSlsInv(string style)
        {
            return this.salesmenAccess.StyleTrackingSlsInv(style);
        }

        public bool CheckSlsInvStyle(string style)
        {
            return this.salesmenAccess.CheckSlsInvStyle(style);
        }

        public bool ClearSalesmanLine(string salesmancode, out string error)
        {
            return this.salesmenAccess.ClearSalesmanLine(salesmancode, out error);
        }

        public DataTable SlsHistory(string salesmancode, string style)
        {
            return this.salesmenAccess.SlsHistory(salesmancode, style);
        }

        public int GetSlsAllotedQtyByStyle(string style, string line_no)
        {
            return this.salesmenAccess.GetSlsAllotedQtyByStyle(style, line_no);
        }

        public bool ReturnLog(string logno, string salesmancode, out string error, out string retlogno)
        {
            return this.salesmenAccess.ReturnLog(logno,salesmancode, out error, out retlogno);
        }

        public bool FixSls(string salesmancode, out string error)
        {
            return this.salesmenAccess.FixSls(salesmancode, out error);
        }

        public DataTable SummarySlsHistory(string salesmancode)
        {
            return this.salesmenAccess.SummarySlsHistory(salesmancode);
        }

    }
}
