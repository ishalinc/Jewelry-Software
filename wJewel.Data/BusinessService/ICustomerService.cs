
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
    public interface ICustomerService
    {
        /// <summary>
        /// Method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetCustomerById(int Id);

        /// <summary>
        /// Service method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllCustomers();

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        DataTable SearchCustomers();


        DataTable SearchInvoiceCustomers();
        /// <summary>
        /// Service method to create new customer
        /// </summary>
        /// <param name="customer">customer model</param>
        /// <returns>true or false</returns>
        bool RegisterCustomer(CustomerModel customer);

        /// <summary>
        /// Method to update  customer details
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerModel customer);

        /// <summary>
        /// Method to delete a customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        bool DeleteCustomer(int id);

        /// <summary>
        /// Service method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetSalesmen();

        /// <summary>
        /// Service method to get all price file
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetPricefile();


        /// <summary>
        /// Service method to check account code is valid
        /// </summary>
        /// <returns>Datarow</returns>
        DataRow CheckValidCustomerCode(string acc);


        /// <summary>
        /// Service method to check billing account no is valid
        /// </summary>
        /// <returns>Datarow</returns>
        DataRow CheckValidBillingAcct(string billacc);

        /// <summary>
        /// Service method to return email
        /// </summary>
        /// <returns>string</returns>
        string GetEmail(string acc);
    }
}



