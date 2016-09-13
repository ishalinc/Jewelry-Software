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
    public class MemoService : IMemoService
    {
        /// <summary>
        /// interface of InvoiceAccess
        /// </summary>
        private IMemoAccess memoAccess;

        /// <summary>
        /// Initializes a new instance of the InvoiceService class
        /// </summary>
        public MemoService()
        {
            this.memoAccess = new MemoAccess();
        }


        /// <summary>
        /// Service method to get  Memo by memo No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        public DataRow GetMemoByInvNo(string memo_no)
        {
            return this.memoAccess.GetMemoByInvNo(memo_no);
        }


        /// <summary>
        /// Service method to search invoice
        /// </summary>

        /// <returns>Data table</returns>
        public DataTable SearchMemo()
        {
            return this.memoAccess.SearchMemo();
        }

       
        /// <summary>
        /// Service method to search invoice
        /// </summary>

        /// <returns>Data table</returns>
        public DataTable GetMemoStatement(string memo_no)
        {
            return this.memoAccess.GetMemoStatement(memo_no);
        }

        public DataTable GetStyleTrackingData(string styles, bool showinvoice, int memoval, string date1, string date2)
        {
            return this.memoAccess.GetStyleTrackingData(styles, showinvoice,memoval,date1,date2);
        }
        
        public DataTable GetStyleTrackingSummaryData(string styles, bool showinvoice, int memoval, string date1, string date2)
        {
            return this.memoAccess.GetStyleTrackingSummaryData(styles, showinvoice, memoval, date1, date2);
        }


        public DataTable GetStatementofMemoData(string memo, bool onlyopenmemo, string date1, string date2, out decimal ccrda, out decimal ccrdb, out decimal ccrdc)
        {
           
            return this.memoAccess.GetStatementofMemoData(memo, onlyopenmemo, date1, date2, out ccrda, out ccrdb, out ccrdc);
        }

        public DataTable ListofItemsMemodOut(string date1, string date2)
        {
            return this.memoAccess.ListofItemsMemodOut(date1, date2);
        }

        public DataTable OpenMemoItems(string bacc1, string bacc2)
        {
            return this.memoAccess.OpenMemoItems(bacc1,bacc2);
        }
    }
}
