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
    public class InvoiceItemsService : IInvoiceItemsService
    {
        /// <summary>
        /// interface of InvoiceAccess
        /// </summary>
        private IInvoiceItemsAccess invoiceItemsAccess;

        /// <summary>
        /// Initializes a new instance of the InvoiceService class
        /// </summary>
        public InvoiceItemsService()
        {
            this.invoiceItemsAccess = new InvoiceItemsAccess();
        }

        /// <summary>
        /// Service method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        public DataTable GetInvoiceItemsByInvNo(string invno)
        {
            return this.invoiceItemsAccess.GetInvoiceItemsByInvNo(invno);
        }

        /// <summary>
        /// Service method to create new invoice Item
        /// </summary>
        /// <param name="customer"> InvoiceItems Model</param>
        /// <returns>true or false</returns>
        public bool InsertInvoiceItem(InvoiceItemsModel invoiceitem)
        {
            return this.invoiceItemsAccess.AddInvoiceItem(invoiceitem);
        }

        /// <summary>
        /// Service method to delete invoice items
        /// </summary>
        /// <param name="invoice"> invoice model</param>
        /// <returns>true or false</returns>
        public bool DeleteInvoiceItems(string inv_no)
        {
            return this.invoiceItemsAccess.DeleteInvoiceItems(inv_no);
        }
    }
}
