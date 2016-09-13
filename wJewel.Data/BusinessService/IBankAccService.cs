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
    /// Interface IBankAccService
    /// </summary>
    public interface IBankAccService
    {


        DataTable GetBankAcc();
        
        
    }
}