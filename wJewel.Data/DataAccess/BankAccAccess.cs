// -----------------------------------------------------------------------
// <copyright file="CustomerAccess.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using IshalInc.wJewel.Data.DataModel;
    using IshalInc.wJewel.Data.Sql;

    /// <summary>
    /// Data access class for Customer table
    /// </summary>
    public class BankAccAccess : ConnectionAccess, IBankAccAccess
    {

      
        public DataTable GetBankAcc()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.sqlGetBankAcc);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }



      
    }
}
