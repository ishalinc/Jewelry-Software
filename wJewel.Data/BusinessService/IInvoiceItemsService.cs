// -----------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.BusinessService
{
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;

    /// <summary>
    /// Interface ICustomerService
    /// </summary>
    public interface IInvoiceItemsService
    {
        /// <summary>
        /// Method to Invoice By Invoice No
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetInvoiceItemsByInvNo(string invno);

        /// <summary>
        /// Service method to create new invoice item
        /// </summary>
        /// <param name="customer">invoiceitem model</param>
        /// <returns>true or false</returns>
        bool InsertInvoiceItem(InvoiceItemsModel invoiceitem);

        /// <summary>
        /// Method to delete a  invoice items
        /// </summary>
        /// <param name="inv_no">invoice no</param>
        /// <returns>true / false</returns>
        bool DeleteInvoiceItems(string inv_no);

    }
}