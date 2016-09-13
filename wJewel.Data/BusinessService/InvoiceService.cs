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
    public class InvoiceService : IInvoiceService
    {
        /// <summary>
        /// interface of InvoiceAccess
        /// </summary>
        private IInvoiceAccess invoiceAccess;

        /// <summary>
        /// Initializes a new instance of the InvoiceService class
        /// </summary>
        public InvoiceService()
        {
            this.invoiceAccess = new InvoiceAccess();
        }

        /// <summary>
        /// Service method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        public DataRow GetInvoiceByInvNo(string invno)
        {
            return this.invoiceAccess.GetInvoiceByInvNo(invno);
        }


        /// <summary>
        /// Service method to search invoice
        /// </summary>

        /// <returns>Data table</returns>
        public DataTable SearchInvoice()
        {
            return this.invoiceAccess.SearchInvoice();
        }

        /// <summary>
        /// Service method to create new invoice
        /// </summary>
        /// <param name="invoice"> invoice model</param>
        /// <returns>true or false</returns>
        public bool InsertInvoice(InvoiceModel invoice)
        {
            return this.invoiceAccess.AddInvoice(invoice);
        }


        /// <summary>
        /// Service method to update invoice
        /// </summary>
        /// <param name="invoice"> invoice model</param>
        /// <returns>true or false</returns>
        public bool UpdateInvoice(InvoiceModel invoice)
        {
            return this.invoiceAccess.UpdateInvoice(invoice);
        }


        /// <summary>
        /// Service method to update invoice
        /// </summary>
        /// <param name="invoice"> invoice model</param>
        /// <returns>true or false</returns>
        public bool DeleteInvoice(string inv_no)
        {
            return this.invoiceAccess.DeleteInvoice(inv_no);
        }

        public string GetNextInvoiceNo()
        {
            return this.invoiceAccess.GetNextInvoiceNo();
        }

        public DataTable GetInvoiceMasterDetail(string invno)
        {
            return this.invoiceAccess.GetInvoiceMasterDetail(invno);
        }

        public DataTable GetInvoiceMasterDetailPO(string invno)
        {
            return this.invoiceAccess.GetInvoiceMasterDetailPO(invno);
        }

        public DataTable GetRTVRcvables(string invno)
        {
            return this.invoiceAccess.GetRTVRcvables(invno);
        }

        /// <summary>
        /// Service method to search invoice
        /// </summary>

        /// <returns>Data table</returns>
        public DataTable GetStatementofInvoice()
        {
            return this.invoiceAccess.GetStatementofInvoice();
        }
    }
}
