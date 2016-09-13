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
    public class CustomerAccess : ConnectionAccess, ICustomerAccess
    {
        /// <summary>
        /// Method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.SqlGetAllCustomers;

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;            
        }

        /// <summary>
        /// Method to get  customer by Id
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>Data row</returns>
        public DataRow GetCustomerById(int id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetCustomerById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", id);

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
        public DataTable SearchCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.SqlSearchCustomers);

               

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        public DataTable SearchInvoiceCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.SqlSearchInvoiceCustomers);



                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to add new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        public bool AddCustomer(CustomerModel customer)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.SqlInsertCustomer;
                Object estdate, lastint, colldate;
                if (customer.EST_DATE == null)
                    estdate = DBNull.Value;
                else
                    estdate = customer.EST_DATE;

                if (customer.LAST_INT == null)
                    lastint = DBNull.Value;
                else
                    lastint = customer.LAST_INT;


                if (customer.COLCDATE == null)
                    colldate = DBNull.Value;
                else
                    colldate = customer.COLCDATE;


                dbCommand.Parameters.AddWithValue("@Acc", customer.ACC);
                dbCommand.Parameters.AddWithValue("@Name", customer.NAME);
                dbCommand.Parameters.AddWithValue("@Addr1", customer.ADDR1);
                dbCommand.Parameters.AddWithValue("@Addr12", customer.ADDR12);
                dbCommand.Parameters.AddWithValue("@City1", customer.CITY1);
                dbCommand.Parameters.AddWithValue("@State1", customer.STATE1);
                dbCommand.Parameters.AddWithValue("@Zip1", customer.ZIP1);
                dbCommand.Parameters.AddWithValue("@Tel", customer.TEL);
                dbCommand.Parameters.AddWithValue("@Country", customer.COUNTRY);
                dbCommand.Parameters.AddWithValue("@www", customer.WWW);
                dbCommand.Parameters.AddWithValue("@Email", customer.EMAIL);
                dbCommand.Parameters.AddWithValue("@Tax_id", customer.TAX_ID);
                dbCommand.Parameters.AddWithValue("@PRICE_FILE", customer.PRICE_FILE);
                dbCommand.Parameters.AddWithValue("@EST_DATE", estdate);
                dbCommand.Parameters.AddWithValue("@JBT", customer.JBT);
                dbCommand.Parameters.AddWithValue("@NAME2", customer.NAME2);
                dbCommand.Parameters.AddWithValue("@BILL_ACC", customer.BILL_ACC);
                dbCommand.Parameters.AddWithValue("@ADDR2", customer.ADDR2);
                dbCommand.Parameters.AddWithValue("@ADDR22", customer.ADDR22);
                dbCommand.Parameters.AddWithValue("@CITY2", customer.CITY2);
                dbCommand.Parameters.AddWithValue("@STATE2", customer.STATE2);
                dbCommand.Parameters.AddWithValue("@ZIP2", customer.ZIP2);
                dbCommand.Parameters.AddWithValue("@FAX", customer.FAX);
                dbCommand.Parameters.AddWithValue("@Country2", customer.COUNTRY2);
                dbCommand.Parameters.AddWithValue("@BUYER", customer.BUYER);
                dbCommand.Parameters.AddWithValue("@SHIP_VIA", customer.SHIP_VIA);
                dbCommand.Parameters.AddWithValue("@ON_MAIL", customer.ON_MAIL);
                dbCommand.Parameters.AddWithValue("@RESIDENT", customer.RESIDENT);
                dbCommand.Parameters.AddWithValue("@IS_COD", customer.IS_COD);
                dbCommand.Parameters.AddWithValue("@COD_TYPE", customer.COD_TYPE);
                dbCommand.Parameters.AddWithValue("@NOTE", customer.NOTE);
                dbCommand.Parameters.AddWithValue("@INTEREST", customer.INTEREST);
                dbCommand.Parameters.AddWithValue("@LAST_INT", lastint);
                dbCommand.Parameters.AddWithValue("@GRACE", customer.GRACE);
                dbCommand.Parameters.AddWithValue("@SALESMAN1", customer.SALESMAN1);
                dbCommand.Parameters.AddWithValue("@SALESMAN2", customer.SALESMAN2);
                dbCommand.Parameters.AddWithValue("@SALESMAN3", customer.SALESMAN3);
                dbCommand.Parameters.AddWithValue("@SALESMAN4", customer.SALESMAN4);
                dbCommand.Parameters.AddWithValue("@PERCENT1", customer.PERCENT1);
                dbCommand.Parameters.AddWithValue("@PERCENT2", customer.PERCENT2);
                dbCommand.Parameters.AddWithValue("@PERCENT3", customer.PERCENT3);
                dbCommand.Parameters.AddWithValue("@PERCENT4", customer.PERCENT4);
                dbCommand.Parameters.AddWithValue("@TERM1", customer.TERM1);
                dbCommand.Parameters.AddWithValue("@TERM2", customer.TERM2);
                dbCommand.Parameters.AddWithValue("@TERM3", customer.TERM3);
                dbCommand.Parameters.AddWithValue("@TERM4", customer.TERM4);
                dbCommand.Parameters.AddWithValue("@TERM5", customer.TERM5);
                dbCommand.Parameters.AddWithValue("@TERM6", customer.TERM6);
                dbCommand.Parameters.AddWithValue("@TERM7", customer.TERM7);
                dbCommand.Parameters.AddWithValue("@TERM8", customer.TERM8);
                dbCommand.Parameters.AddWithValue("@TERM_PCT1", customer.TERM_PCT1);
                dbCommand.Parameters.AddWithValue("@TERM_PCT2", customer.TERM_PCT2);
                dbCommand.Parameters.AddWithValue("@TERM_PCT3", customer.TERM_PCT3);
                dbCommand.Parameters.AddWithValue("@TERM_PCT4", customer.TERM_PCT4);
                dbCommand.Parameters.AddWithValue("@TERM_PCT5", customer.TERM_PCT5);
                dbCommand.Parameters.AddWithValue("@TERM_PCT6", customer.TERM_PCT6);
                dbCommand.Parameters.AddWithValue("@TERM_PCT7", customer.TERM_PCT7);
                dbCommand.Parameters.AddWithValue("@TERM_PCT8", customer.TERM_PCT8);
                dbCommand.Parameters.AddWithValue("@CREDIT", customer.CREDIT);
                dbCommand.Parameters.AddWithValue("@PERCENT", customer.PERCENT);
                dbCommand.Parameters.AddWithValue("@ON_HOLD", customer.ON_HOLD);
                dbCommand.Parameters.AddWithValue("@REASON", customer.REASON);
                dbCommand.Parameters.AddWithValue("@COLCSENT", customer.COLCSENT);
                dbCommand.Parameters.AddWithValue("@COLCDATE", colldate);
                dbCommand.Parameters.AddWithValue("@COLCRSN", customer.COLCRSN);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to update  customer
        /// </summary>
        /// <param name="customer"> customer</param>
        /// <returns>true / false</returns>
        public bool UpdateCustomer(CustomerModel customer)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateCustomer;

                // Add the input parameters to the parameter collection

                Object estdate, lastint, colldate;
                if (customer.EST_DATE == null)
                    estdate = DBNull.Value;
                else
                    estdate = customer.EST_DATE;

                if (customer.LAST_INT == null)
                    lastint = DBNull.Value;
                else
                    lastint = customer.LAST_INT;


                if (customer.COLCDATE == null)
                    colldate = DBNull.Value;
                else
                    colldate = customer.COLCDATE;

                dbCommand.Parameters.AddWithValue("@Id", customer.ID);
                dbCommand.Parameters.AddWithValue("@Acc", customer.ACC);
                dbCommand.Parameters.AddWithValue("@Name", customer.NAME);
                dbCommand.Parameters.AddWithValue("@Addr1", customer.ADDR1);
                dbCommand.Parameters.AddWithValue("@Addr12", customer.ADDR12);
                dbCommand.Parameters.AddWithValue("@City1", customer.CITY1);
                dbCommand.Parameters.AddWithValue("@State1", customer.STATE1);
                dbCommand.Parameters.AddWithValue("@Zip1", customer.ZIP1);
                dbCommand.Parameters.AddWithValue("@Tel", customer.TEL);
                dbCommand.Parameters.AddWithValue("@Country", customer.COUNTRY);
                dbCommand.Parameters.AddWithValue("@www", customer.WWW);
                dbCommand.Parameters.AddWithValue("@Email", customer.EMAIL);
                dbCommand.Parameters.AddWithValue("@Tax_id", customer.TAX_ID);
                dbCommand.Parameters.AddWithValue("@PRICE_FILE", customer.PRICE_FILE);
                dbCommand.Parameters.AddWithValue("@EST_DATE", estdate);
                dbCommand.Parameters.AddWithValue("@JBT", customer.JBT);
                dbCommand.Parameters.AddWithValue("@NAME2", customer.NAME2);
                dbCommand.Parameters.AddWithValue("@BILL_ACC", customer.BILL_ACC);
                dbCommand.Parameters.AddWithValue("@ADDR2", customer.ADDR2);
                dbCommand.Parameters.AddWithValue("@ADDR22", customer.ADDR22);
                dbCommand.Parameters.AddWithValue("@CITY2", customer.CITY2);
                dbCommand.Parameters.AddWithValue("@STATE2", customer.STATE2);
                dbCommand.Parameters.AddWithValue("@ZIP2", customer.ZIP2);
                dbCommand.Parameters.AddWithValue("@FAX", customer.FAX);
                dbCommand.Parameters.AddWithValue("@Country2", customer.COUNTRY2);
                dbCommand.Parameters.AddWithValue("@BUYER", customer.BUYER);
                dbCommand.Parameters.AddWithValue("@SHIP_VIA", customer.SHIP_VIA);
                dbCommand.Parameters.AddWithValue("@ON_MAIL", customer.ON_MAIL);
                dbCommand.Parameters.AddWithValue("@RESIDENT", customer.RESIDENT);
                dbCommand.Parameters.AddWithValue("@IS_COD", customer.IS_COD);
                dbCommand.Parameters.AddWithValue("@COD_TYPE", customer.COD_TYPE);
                dbCommand.Parameters.AddWithValue("@NOTE", customer.NOTE);
                dbCommand.Parameters.AddWithValue("@INTEREST", customer.INTEREST);
                dbCommand.Parameters.AddWithValue("@LAST_INT", lastint);
                dbCommand.Parameters.AddWithValue("@GRACE", customer.GRACE);
                dbCommand.Parameters.AddWithValue("@SALESMAN1", customer.SALESMAN1);
                dbCommand.Parameters.AddWithValue("@SALESMAN2", customer.SALESMAN2);
                dbCommand.Parameters.AddWithValue("@SALESMAN3", customer.SALESMAN3);
                dbCommand.Parameters.AddWithValue("@SALESMAN4", customer.SALESMAN4);
                dbCommand.Parameters.AddWithValue("@PERCENT1", customer.PERCENT1);
                dbCommand.Parameters.AddWithValue("@PERCENT2", customer.PERCENT2);
                dbCommand.Parameters.AddWithValue("@PERCENT3", customer.PERCENT3);
                dbCommand.Parameters.AddWithValue("@PERCENT4", customer.PERCENT4);
                dbCommand.Parameters.AddWithValue("@TERM1", customer.TERM1);
                dbCommand.Parameters.AddWithValue("@TERM2", customer.TERM2);
                dbCommand.Parameters.AddWithValue("@TERM3", customer.TERM3);
                dbCommand.Parameters.AddWithValue("@TERM4", customer.TERM4);
                dbCommand.Parameters.AddWithValue("@TERM5", customer.TERM5);
                dbCommand.Parameters.AddWithValue("@TERM6", customer.TERM6);
                dbCommand.Parameters.AddWithValue("@TERM7", customer.TERM7);
                dbCommand.Parameters.AddWithValue("@TERM8", customer.TERM8);
                dbCommand.Parameters.AddWithValue("@TERM_PCT1", customer.TERM_PCT1);
                dbCommand.Parameters.AddWithValue("@TERM_PCT2", customer.TERM_PCT2);
                dbCommand.Parameters.AddWithValue("@TERM_PCT3", customer.TERM_PCT3);
                dbCommand.Parameters.AddWithValue("@TERM_PCT4", customer.TERM_PCT4);
                dbCommand.Parameters.AddWithValue("@TERM_PCT5", customer.TERM_PCT5);
                dbCommand.Parameters.AddWithValue("@TERM_PCT6", customer.TERM_PCT6);
                dbCommand.Parameters.AddWithValue("@TERM_PCT7", customer.TERM_PCT7);
                dbCommand.Parameters.AddWithValue("@TERM_PCT8", customer.TERM_PCT8);
                dbCommand.Parameters.AddWithValue("@CREDIT", customer.CREDIT);
                dbCommand.Parameters.AddWithValue("@PERCENT", customer.PERCENT);
                dbCommand.Parameters.AddWithValue("@ON_HOLD", customer.ON_HOLD);
                dbCommand.Parameters.AddWithValue("@REASON", customer.REASON);
                dbCommand.Parameters.AddWithValue("@COLCSENT", customer.COLCSENT);
                dbCommand.Parameters.AddWithValue("@COLCDATE", colldate);
                dbCommand.Parameters.AddWithValue("@COLCRSN", customer.COLCRSN);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        public bool DeleteCustomer(int id)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteCustomer;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@Id", id);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetSalesmen()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetSalesMan;

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        /// <summary>
        /// Method to get all customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetPricefile()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetPriceFile;

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to check valid account code
        /// </summary>
        /// <param name="acc">customer code</param>
        /// <returns>Datarow</returns>
        public DataRow CheckValidCustomerCode(string acc)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlCheckValidCustomerCode;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }


        /// <summary>
        /// Method to check valid account code
        /// </summary>
        /// <param name="acc">customer code</param>
        /// <returns>Datarow</returns>
        public DataRow CheckValidBillingAcct(string billacc)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlCheckValidBillAccountCode;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@bill_acc", billacc);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }

        /// <summary>
        /// Method to check valid account code
        /// </summary>
        /// <param name="acc">customer code</param>
        /// <returns>Datarow</returns>
        public string GetEmail(string acc)
        {
            DataTable dataTable = new DataTable();
           

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetEmailIdByAcc;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the email from the table
               return dataTable.Rows.Count > 0 ? dataTable.Rows[0]["email"].ToString() : string.Empty;

            }
        }
    }
}
