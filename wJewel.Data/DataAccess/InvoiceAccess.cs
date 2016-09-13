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
    public class InvoiceAccess : ConnectionAccess, IInvoiceAccess
    {

        /// <summary>
        /// Service method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        public DataRow GetInvoiceByInvNo(string invno)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetInvoiceByInvNo;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", invno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }


        /// <summary>
        /// Method to search customers by multiple parameters
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable SearchInvoice()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.sqlSearchInvoice);

             
                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        /// <summary>
        /// Method to add new invoice
        /// </summary>
        /// <param name="invoice"> invoice model</param>
        /// <returns>true or false</returns>
        public bool AddInvoice(InvoiceModel invoice)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlInsertInvoice;
                Object invoicedate;
                if (invoice.DATE == null)
                    invoicedate = DBNull.Value;
                else
                    invoicedate = invoice.DATE;
                
                dbCommand.Parameters.AddWithValue("@INV_NO", invoice.INV_NO);
                dbCommand.Parameters.AddWithValue("@BACC", invoice.BACC);
                dbCommand.Parameters.AddWithValue("@ACC", invoice.ACC);
                dbCommand.Parameters.AddWithValue("@ADD_COST", invoice.ADD_COST);
                dbCommand.Parameters.AddWithValue("@SNH", invoice.SNH);
                dbCommand.Parameters.AddWithValue("@DATE", invoicedate);
                dbCommand.Parameters.AddWithValue("@PON", invoice.PON);
                dbCommand.Parameters.AddWithValue("@MESSAGE", invoice.MESSAGE);
                dbCommand.Parameters.AddWithValue("@GR_TOTAL", invoice.GR_TOTAL);
                dbCommand.Parameters.AddWithValue("@ADDR1", invoice.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR2", invoice.ADDR2);
                dbCommand.Parameters.AddWithValue("@CITY", invoice.CITY);
                dbCommand.Parameters.AddWithValue("@STATE", invoice.STATE);
                dbCommand.Parameters.AddWithValue("@ZIP", invoice.ZIP);
                dbCommand.Parameters.AddWithValue("@COUNTRY", invoice.COUNTRY);
                dbCommand.Parameters.AddWithValue("@VIA_UPS", invoice.VIA_UPS);
                dbCommand.Parameters.AddWithValue("@IS_COD", invoice.IS_COD);
                dbCommand.Parameters.AddWithValue("@WEIGHT", invoice.WEIGHT);
                dbCommand.Parameters.AddWithValue("@COD_TYPE", invoice.COD_TYPE);
                dbCommand.Parameters.AddWithValue("@CUST_PON", invoice.CUST_PON);
                dbCommand.Parameters.AddWithValue("@SHIP_BY", invoice.SHIP_BY);
                dbCommand.Parameters.AddWithValue("@TERM1", invoice.TERM1);
                dbCommand.Parameters.AddWithValue("@TERM2", invoice.TERM2);
                dbCommand.Parameters.AddWithValue("@TERM3", invoice.TERM3);
                dbCommand.Parameters.AddWithValue("@TERM4", invoice.TERM4);
                dbCommand.Parameters.AddWithValue("@TERM5", invoice.TERM5);
                dbCommand.Parameters.AddWithValue("@TERM6", invoice.TERM6);
                dbCommand.Parameters.AddWithValue("@TERM7", invoice.TERM7);
                dbCommand.Parameters.AddWithValue("@TERM8", invoice.TERM8);
                dbCommand.Parameters.AddWithValue("@TERM_PCT1", invoice.TERM_PCT1);
                dbCommand.Parameters.AddWithValue("@TERM_PCT2", invoice.TERM_PCT2);
                dbCommand.Parameters.AddWithValue("@TERM_PCT3", invoice.TERM_PCT3);
                dbCommand.Parameters.AddWithValue("@TERM_PCT4", invoice.TERM_PCT4);
                dbCommand.Parameters.AddWithValue("@TERM_PCT5", invoice.TERM_PCT5);
                dbCommand.Parameters.AddWithValue("@TERM_PCT6", invoice.TERM_PCT6);
                dbCommand.Parameters.AddWithValue("@TERM_PCT7", invoice.TERM_PCT7);
                dbCommand.Parameters.AddWithValue("@TERM_PCT8", invoice.TERM_PCT8);
                dbCommand.Parameters.AddWithValue("@OPERATOR", invoice.OPERATOR);
                dbCommand.Parameters.AddWithValue("@NAME", invoice.NAME);
                dbCommand.Parameters.AddWithValue("@EARLY", invoice.EARLY);
                dbCommand.Parameters.AddWithValue("@INSURED", invoice.INSURED);
                dbCommand.Parameters.AddWithValue("@PERCENT", invoice.PERCENT);
                dbCommand.Parameters.AddWithValue("@MAN_SHIP", invoice.MAN_SHIP == true ? 1 : 0);
                dbCommand.Parameters.AddWithValue("@RESIDENT", invoice.RESIDENT);
                dbCommand.Parameters.AddWithValue("@IS_FDX", invoice.IS_FDX == true ? 1 : 0);
                dbCommand.Parameters.AddWithValue("@IS_DEB", invoice.IS_DEB == true ? 1: 0);
              

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }


        /// <summary>
        /// Method to add update invoice
        /// </summary>
        /// <param name="invoice"> invoice model</param>
        /// <returns>true or false</returns>
        public bool UpdateInvoice(InvoiceModel invoice)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInvoice;
                Object invoicedate;
                if (invoice.DATE == null)
                    invoicedate = DBNull.Value;
                else
                    invoicedate = invoice.DATE;

                dbCommand.Parameters.AddWithValue("@INV_NO", invoice.INV_NO);
                dbCommand.Parameters.AddWithValue("@BACC", invoice.BACC);
                dbCommand.Parameters.AddWithValue("@ACC", invoice.ACC);
                dbCommand.Parameters.AddWithValue("@ADD_COST", invoice.ADD_COST);
                dbCommand.Parameters.AddWithValue("@SNH", invoice.SNH);
                dbCommand.Parameters.AddWithValue("@DATE", invoicedate);
                dbCommand.Parameters.AddWithValue("@PON", invoice.PON);
                dbCommand.Parameters.AddWithValue("@MESSAGE", invoice.MESSAGE);
                dbCommand.Parameters.AddWithValue("@GR_TOTAL", invoice.GR_TOTAL);
                dbCommand.Parameters.AddWithValue("@ADDR1", invoice.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR2", invoice.ADDR2);
                dbCommand.Parameters.AddWithValue("@CITY", invoice.CITY);
                dbCommand.Parameters.AddWithValue("@STATE", invoice.STATE);
                dbCommand.Parameters.AddWithValue("@ZIP", invoice.ZIP);
                dbCommand.Parameters.AddWithValue("@COUNTRY", invoice.COUNTRY);
                dbCommand.Parameters.AddWithValue("@VIA_UPS", invoice.VIA_UPS);
                dbCommand.Parameters.AddWithValue("@IS_COD", invoice.IS_COD);
                dbCommand.Parameters.AddWithValue("@WEIGHT", invoice.WEIGHT);
                dbCommand.Parameters.AddWithValue("@COD_TYPE", invoice.COD_TYPE);
                dbCommand.Parameters.AddWithValue("@CUST_PON", invoice.CUST_PON);
                dbCommand.Parameters.AddWithValue("@SHIP_BY", invoice.SHIP_BY);
                dbCommand.Parameters.AddWithValue("@TERM1", invoice.TERM1);
                dbCommand.Parameters.AddWithValue("@TERM2", invoice.TERM2);
                dbCommand.Parameters.AddWithValue("@TERM3", invoice.TERM3);
                dbCommand.Parameters.AddWithValue("@TERM4", invoice.TERM4);
                dbCommand.Parameters.AddWithValue("@TERM5", invoice.TERM5);
                dbCommand.Parameters.AddWithValue("@TERM6", invoice.TERM6);
                dbCommand.Parameters.AddWithValue("@TERM7", invoice.TERM7);
                dbCommand.Parameters.AddWithValue("@TERM8", invoice.TERM8);
                dbCommand.Parameters.AddWithValue("@TERM_PCT1", invoice.TERM_PCT1);
                dbCommand.Parameters.AddWithValue("@TERM_PCT2", invoice.TERM_PCT2);
                dbCommand.Parameters.AddWithValue("@TERM_PCT3", invoice.TERM_PCT3);
                dbCommand.Parameters.AddWithValue("@TERM_PCT4", invoice.TERM_PCT4);
                dbCommand.Parameters.AddWithValue("@TERM_PCT5", invoice.TERM_PCT5);
                dbCommand.Parameters.AddWithValue("@TERM_PCT6", invoice.TERM_PCT6);
                dbCommand.Parameters.AddWithValue("@TERM_PCT7", invoice.TERM_PCT7);
                dbCommand.Parameters.AddWithValue("@TERM_PCT8", invoice.TERM_PCT8);
                dbCommand.Parameters.AddWithValue("@NAME", invoice.NAME);
                dbCommand.Parameters.AddWithValue("@EARLY", invoice.EARLY);
                dbCommand.Parameters.AddWithValue("@INSURED", invoice.INSURED);
                dbCommand.Parameters.AddWithValue("@PERCENT", invoice.PERCENT);
                dbCommand.Parameters.AddWithValue("@MAN_SHIP", invoice.MAN_SHIP == true ? 1 : 0);
                dbCommand.Parameters.AddWithValue("@RESIDENT", invoice.RESIDENT);
                dbCommand.Parameters.AddWithValue("@IS_FDX", invoice.IS_FDX == true ? 1 : 0);
                dbCommand.Parameters.AddWithValue("@IS_DEB", invoice.IS_DEB == true ? 1 : 0);


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
        public bool DeleteInvoice(string inv_no)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteInvoice;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        public string GetNextInvoiceNo()
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetnextInvoiceNr;

                
                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["inv_no"].ToString();
            }
        }

        public DataTable GetInvoiceMasterDetail(string invno)
        {
            DataTable dataTable = new DataTable();
           

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetMasterDetailInvoice;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", invno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetInvoiceMasterDetailPO(string invno)
        {
            DataTable dataTable = new DataTable();


            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetMasterDetailInvoicePO;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", invno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetRTVRcvables(string invno)
        {
            DataTable dataTable = new DataTable();


            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.CommandText = "GetRTVRcvables";

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", invno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /// <summary>
        /// Method to Get data for statement of invoice
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetStatementofInvoice()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.sqlStatementOfInvoice);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

    }
}
