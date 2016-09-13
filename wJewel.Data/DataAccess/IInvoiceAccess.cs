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
    public interface IInvoiceAccess
    {
        /// <summary>
        /// Method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        DataRow GetInvoiceByInvNo(string invno);


        /// <summary>
        /// Search Invoice
        /// </summary>
        /// <returns>true or false</returns>
        DataTable SearchInvoice();

        /// <summary>
        /// Method to create new invoice
        /// </summary>
        /// <param name="customer"> invoice model</param>
        /// <returns>true or false</returns>
        bool AddInvoice(InvoiceModel invoice);


        /// <summary>
        /// Method to update invoice
        /// </summary>
        /// <param name="invoice"> invoice model</param>
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
