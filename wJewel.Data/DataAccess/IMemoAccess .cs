// -----------------------------------------------------------------------
// <copyright file="ICustomerAccess.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.DataAccess
{
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;

    /// <summary>
    /// Interface ICustomerAccess
    /// </summary>
    public interface IMemoAccess
    {

        /// <summary>
        /// Method to get  Memo by memo No
        /// </summary>
        /// <param name="id">Memo No</param>
        /// <returns>Data row</returns>
        DataRow GetMemoByInvNo(string memo_no);


        /// <summary>
        /// Search Memo
        /// </summary>
        /// <returns>true or false</returns>
        DataTable SearchMemo();

        
        DataTable GetMemoStatement(string memono);

        DataTable GetStyleTrackingData(string styles, bool showinvoice, int memoval, string date1, string date2);

        DataTable GetStyleTrackingSummaryData(string styles, bool showinvoice, int memoval, string date1, string date2);

        DataTable GetStatementofMemoData(string memo, bool onlyopenmemo, string date1, string date2, out decimal ccrda, out decimal ccrdb, out decimal ccrdc);

        DataTable ListofItemsMemodOut(string date1, string date2);

        DataTable OpenMemoItems(string bacc1, string bacc2);

    }
}
