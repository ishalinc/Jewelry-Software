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
    public interface IInvoiceItemsAccess
    {
        /// <summary>
        /// Method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        DataTable GetInvoiceItemsByInvNo(string invno);

        /// <summary>
        /// Method to create new invoice item
        /// </summary>
        /// <param name="customer"> invoiceitem model</param>
        /// <returns>true or false</returns>
        bool AddInvoiceItem(InvoiceItemsModel invoice);


        bool DeleteInvoiceItems(string inv_no);
    }
}
