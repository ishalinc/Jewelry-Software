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
    public class MemoAccess : ConnectionAccess, IMemoAccess
    {

        /// <summary>
        /// Service method to get  Invoice by Inv No
        /// </summary>
        /// <param name="id">Invoice No</param>
        /// <returns>Data row</returns>
        public DataRow GetMemoByInvNo(string memo_no)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetMemoByInvNo;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@memo_no", memo_no);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }


        /// <summary>
        /// Method to search memo 
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable SearchMemo()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(Scripts.sqlSearchMemo);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }



        /// <summary>
        /// Method to Get data for statement of memo
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetMemoStatement(string memo_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetMemoStatus";

                // Add the parameter to the parameter collection
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@memo_no", memo_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetStyleTrackingData(string styles, bool showinvoice, int memoval, string date1, string date2)
        {
            DataTable dataTable = new DataTable();

           
            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "InvoiceMemoStyleTracking";

                // Add the parameter to the parameter collection
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@styleno", styles);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@showinvoice", showinvoice ? 1 : 0);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@memoval", memoval);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetStyleTrackingSummaryData(string styles,bool showinvoice, int memoval, string date1, string date2)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "InvoiceMemoStyleTrackingSummary";

                // Add the parameter to the parameter collection
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@styleno", styles);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@showinvoice", showinvoice ? 1 : 0);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@memoval", memoval);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetStatementofMemoData(string memo, bool onlyopenmemo, string date1, string date2, out decimal ccrda, out decimal ccrdb, out decimal ccrdc)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "StatementofMemo";

                // Add the parameter to the parameter collection
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@memo", memo);
                //SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@onlyopenmemo", onlyopenmemo? 1 : 0);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2);

                SqlParameter outccrda = new SqlParameter("@ccrda", SqlDbType.Decimal);
                outccrda.Direction = ParameterDirection.Output;
                SqlDataAdapter.SelectCommand.Parameters.Add(outccrda);

                SqlParameter outccrdb = new SqlParameter("@ccrdb", SqlDbType.Decimal);
                outccrdb.Direction = ParameterDirection.Output;
                SqlDataAdapter.SelectCommand.Parameters.Add(outccrdb);

                SqlParameter outccrdc = new SqlParameter("@ccrdc", SqlDbType.Decimal);
                outccrdc.Direction = ParameterDirection.Output;
                SqlDataAdapter.SelectCommand.Parameters.Add(outccrdc);

              

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
                ccrda = outccrda.Value != DBNull.Value ? (decimal)outccrda.Value : 0;
                ccrdb = outccrdb.Value != DBNull.Value ? (decimal)outccrdb.Value : 0;
                ccrdc = outccrdc.Value != DBNull.Value ? (decimal)outccrdc.Value : 0;
            }

            return dataTable;
        }

        public DataTable ListofItemsMemodOut(string date1, string date2)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetListofItemsMemodOut";

               
                //SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@onlyopenmemo", onlyopenmemo? 1 : 0);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2);
                

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
               
            }

            return dataTable;
        }

        public DataTable OpenMemoItems(string bacc1, string bacc2)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetOpenmemoItems";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@bacc1", bacc1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@bacc2", bacc2);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);

            }

            return dataTable;
        }
    }
}
