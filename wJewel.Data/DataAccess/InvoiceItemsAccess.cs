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
    public class InvoiceItemsAccess : ConnectionAccess, IInvoiceItemsAccess
    {

        /// <summary>
        /// Service method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        public DataTable GetInvoiceItemsByInvNo(string invno)
        {
            DataTable dataTable = new DataTable();
           
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetInvoiceItemsByInvNo;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", invno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                //dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataTable;
            }
        }

        /// <summary>
        /// Method to add new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        public bool AddInvoiceItem(InvoiceItemsModel invoiceitem)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlInsertItems;
                

                dbCommand.Parameters.AddWithValue("@INV_NO", invoiceitem.INV_NO);
                dbCommand.Parameters.AddWithValue("@DESC", invoiceitem.DESC);
                dbCommand.Parameters.AddWithValue("@PRICE", invoiceitem.PRICE);
                dbCommand.Parameters.AddWithValue("@QTY", invoiceitem.QTY);
                

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to delete a  invoice
        /// </summary>
        /// <param name="inv_no">invoice no</param>
        /// <returns>true / false</returns>
        public bool DeleteInvoiceItems(string inv_no)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteInvoiceItems;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

    }
}
