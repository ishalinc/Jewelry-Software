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
    public class BankAccService : IBankAccService
    {
        /// <summary>
        /// interface of BankAccAccess
        /// </summary>
        private IBankAccAccess bankaccAccess;

        public BankAccService()
        {
            this.bankaccAccess = new BankAccAccess();
        }


        public DataTable GetBankAcc()
        {
            return this.bankaccAccess.GetBankAcc();
        }

       
       
    }
}
