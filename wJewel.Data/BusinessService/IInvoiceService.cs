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
    public interface IInvoiceService
    {
        /// <summary>
        /// Method to Invoice By Invoice No
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetInvoiceByInvNo(string invno);


        /// <summary>
        /// Search Invoice
        /// </summary>
        /// <returns>true or false</returns>
        DataTable SearchInvoice();

        /// <summary>
        /// Service method to create new invoice
        /// </summary>
        /// <param name="customer">invoice model</param>
        /// <returns>true or false</returns>
        bool InsertInvoice(InvoiceModel invoice);

        /// <summary>
        /// Service method to update invoice
        /// </summary>
        /// <param name="invoice">invoice model</param>
        /// <returns>true or false</returns>
        bool UpdateInvoice(InvoiceModel invoice);

        /// <summary>
        /// Method to delete a  invoice
        /// </summary>
        /// <param name="inv_no">invoice no</param>
        /// <returns>true / false</returns>
        bool DeleteInvoice(string inv_no);


        string GetNextInvoiceNo();

        DataTable GetInvoiceMasterDetail(string invno);

        DataTable GetInvoiceMasterDetailPO(string invno);

        DataTable GetRTVRcvables(string invno);

        DataTable GetStatementofInvoice();
    }
}