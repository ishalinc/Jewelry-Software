// -----------------------------------------------------------------------
// <copyright file="IBankAcc.cs" company="Ishal Inc.">
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
    public interface IBankAccAccess
    {
        
        DataTable GetBankAcc();
        
    }
}
