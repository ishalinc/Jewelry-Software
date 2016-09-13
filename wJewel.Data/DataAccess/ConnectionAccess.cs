// -----------------------------------------------------------------------
// <copyright file="ConnectionAccess.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.DataAccess
{
    using System.Configuration;

    /// <summary>
    /// ConnectionAccess class
    /// </summary>
    public abstract class ConnectionAccess
    {
        /// <summary>
        /// Gets connection string
        /// </summary>
        protected string ConnectionString
        {
            get 
            { 
                return ConfigurationManager
                    .ConnectionStrings["JewelConnection"]
                    .ToString(); 
            }
        }
    }
}
