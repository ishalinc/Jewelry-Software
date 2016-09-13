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
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// interface of CustomerAccess
        /// </summary>
        private ICustomerAccess customerAccess;

        /// <summary>
        /// Initializes a new instance of the CustomerService class
        /// </summary>
        public CustomerService()
        {
            this.customerAccess = new CustomerAccess();
        }

        /// <summary>
        /// Service method to get  customer by Id
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>Data row</returns>
        public DataRow GetCustomerById(int id)
        {
            return this.customerAccess.GetCustomerById(id);
        }

        /// <summary>
        /// Service method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllCustomers()
        {            
            return this.customerAccess.GetAllCustomers();
        }

        /// <summary>
        /// Service method to search customer
        /// </summary>
    
        /// <returns>Data table</returns>
        public DataTable SearchCustomers()
        {
            return this.customerAccess.SearchCustomers();
        }        


        public DataTable SearchInvoiceCustomers()
        {
            return this.customerAccess.SearchInvoiceCustomers();
        }
        /// <summary>
        /// Service method to create new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        public bool RegisterCustomer(CustomerModel customer)
        {
            return this.customerAccess.AddCustomer(customer);
        }

        /// <summary>
        /// Service method to update  customer
        /// </summary>
        /// <param name="customer"> customer</param>
        /// <returns>true / false</returns>
        public bool UpdateCustomer(CustomerModel customer)
        {
            return this.customerAccess.UpdateCustomer(customer);
        }

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        public bool DeleteCustomer(int id)
        {
            return this.customerAccess.DeleteCustomer(id);
        }

        /// <summary>
        /// Service method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetSalesmen()
        {
            return this.customerAccess.GetSalesmen();
        }

        /// <summary>
        /// Service method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetPricefile()
        {
            return this.customerAccess.GetPricefile();
        }


        /// <summary>
        /// Service method to check account code is valid
        /// </summary>
        /// <returns>Datarow</returns>
        public DataRow CheckValidCustomerCode(string acc)
        {
            return this.customerAccess.CheckValidCustomerCode(acc);
        }

        /// <summary>
        /// Service method to check account code is valid
        /// </summary>
        /// <returns>Datarow</returns>
        public DataRow CheckValidBillingAcct(string bill_acc)
        {
            return this.customerAccess.CheckValidBillingAcct(bill_acc);
        }


        /// <summary>
        /// Service method to return email
        /// </summary>
        /// <returns>string</returns>
        public string GetEmail(string acc)
        {
            return this.customerAccess.GetEmail(acc);
        }

    }
}
