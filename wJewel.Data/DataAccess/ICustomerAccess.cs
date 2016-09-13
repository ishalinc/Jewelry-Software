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
    public interface ICustomerAccess
    {
        /// <summary>
        /// Method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetCustomerById(int Id);

        /// <summary>
        /// Method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllCustomers();



        /// <summary>
        /// Method to search customers 
        /// </summary>
       /// <returns>Data table</returns>
        DataTable SearchCustomers();


        DataTable SearchInvoiceCustomers();

        /// <summary>
        /// Method to create new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        bool AddCustomer(CustomerModel customer);

        /// <summary>
        /// Method to update  customer details
        /// </summary>
        /// <param name="customer"> customer</param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerModel customer);

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        bool DeleteCustomer(int id);


        /// <summary>
        /// Method to get all salesmen code and name
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetSalesmen();

        /// <summary>
        /// Method to get all price file no
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
