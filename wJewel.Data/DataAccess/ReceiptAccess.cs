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
    public class ReceiptAccess : ConnectionAccess, IReceiptAccess
    {


        public DataTable GetReceiptData(string acc, string receipt_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetReceiptData";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@receipt_no", receipt_no);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetAdjReceivableData(string acc)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetAdjReceivableData";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);
                


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetReceiptEditData(string acc, string receipt_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetReceiptDataEdit";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@receipt_no", receipt_no);
                SqlDataAdapter.SelectCommand.CommandTimeout = 0;

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        public bool DeleteReceipt(string acc, string receipt_no, decimal paid, string transact, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {

                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "DeleteReceipt";

                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@receipt_no", receipt_no);
                    dbCommand.Parameters.AddWithValue("@paid", paid);
                    dbCommand.Parameters.AddWithValue("@transact", transact);


                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }


        public bool DeleteCredit(string acc, string receipt_no, decimal paid, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {

                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "DeleteCredit";

                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@credit_no", receipt_no);
                    dbCommand.Parameters.AddWithValue("@paid", paid);
                    


                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public bool SaveReceipt(DataTable dtPayment, string acc, string receipt_no, DateTime? pay_date, DateTime? chk_date, string bank, decimal chk_amt, decimal discount, bool showmemo, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "SaveReceiptNew";



                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@TBLPAYMENT";
                    parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    parameter.Value = dtPayment;
                    dbCommand.Parameters.Add(parameter);

                    

                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@receipt_no", receipt_no);
                    dbCommand.Parameters.AddWithValue("@pay_date", pay_date);
                    dbCommand.Parameters.AddWithValue("@chk_date", chk_date);
                    dbCommand.Parameters.AddWithValue("@bank", bank);
                    dbCommand.Parameters.AddWithValue("@chk_amt", chk_amt);
                    dbCommand.Parameters.AddWithValue("@discount", discount);
                    dbCommand.Parameters.AddWithValue("@showmemo", showmemo);

                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }


        public bool SaveAdjRcvable(DataTable dtPayment, string acc, string adj_no, DateTime? entry_date, bool showmemo, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "SaveAdjRcvable";



                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@TBLPAYMENT";
                    parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    parameter.Value = dtPayment;
                    dbCommand.Parameters.Add(parameter);
                 

                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@adj_no", adj_no);
                    dbCommand.Parameters.AddWithValue("@entry_date", entry_date);
                    dbCommand.Parameters.AddWithValue("@showmemo", showmemo);

                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public bool EditReceipt(DataTable dtPayment, string acc, string receipt_no, DateTime? pay_date, DateTime? chk_date, string bank, decimal chk_amt, decimal discount, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "EditReceipt";



                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@TBLEDITRECEIPT";
                    parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    parameter.Value = dtPayment;
                    dbCommand.Parameters.Add(parameter);



                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@receipt_no", receipt_no);
                    dbCommand.Parameters.AddWithValue("@pay_date", pay_date);
                    dbCommand.Parameters.AddWithValue("@chk_date", chk_date);
                    dbCommand.Parameters.AddWithValue("@bank", bank);
                    dbCommand.Parameters.AddWithValue("@chk_amt", chk_amt);
                    dbCommand.Parameters.AddWithValue("@discount", discount);

                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public bool EditAdjRcvanble(DataTable dtPayment, string acc, string adj_no, DateTime? entry_date, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "EditAdjRcvable";



                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@TBLEDITRECEIPT";
                    parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    parameter.Value = dtPayment;
                    dbCommand.Parameters.Add(parameter);



                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@ADJ_NO", adj_no);
                    dbCommand.Parameters.AddWithValue("@entry_date", entry_date);
                    

                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public DataTable GetPayItems(string pay_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetPayItemsByPayNo;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@pay_no", pay_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        public DataTable GetPayItemsInvNo(string inv_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetPayItemsByInvNo;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataRow GetPayment(string inv_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetPaymentByInvNo;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable.Rows[0];
            else
                return null;

        }


        public DataRow GetPayment(string inv_no,string rtv_pay)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetPaymentByInvNo_RTV;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@rtv_pay", rtv_pay);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable.Rows[0];
            else
                return null;

        }


        public DataTable GetCreditPayment(string inv_no, string rtv_pay)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetCreditPaymentByInvNo_RTV;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@rtv_pay", rtv_pay);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable;
            else
                return null;

        }

        public DataTable GetCreditData(string acc, string credit_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetCreditData";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@credit_no", credit_no);


                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public bool SaveCredit(DataTable dtPayment, string acc, string credit_no, DateTime? date, DateTime? ref_date, string note, decimal amt, string cred_code, bool showmemo, out string error)
        {
            try
            {
                error = string.Empty;
                using (SqlCommand dbCommand = new SqlCommand())
                {
                    // Set the command object properties
                    dbCommand.Connection = new SqlConnection(this.ConnectionString);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "SaveCreditNew";



                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@TBLPAYMENT";
                    parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    parameter.Value = dtPayment;
                    dbCommand.Parameters.Add(parameter);

                   
                    dbCommand.Parameters.AddWithValue("@acc", acc);
                    dbCommand.Parameters.AddWithValue("@credit_no", credit_no);
                    dbCommand.Parameters.AddWithValue("@date", date);
                    dbCommand.Parameters.AddWithValue("@rdate", ref_date);
                    dbCommand.Parameters.AddWithValue("@note", note);
                    dbCommand.Parameters.AddWithValue("@amt", amt);
                    dbCommand.Parameters.AddWithValue("@cred_code", cred_code);
                    dbCommand.Parameters.AddWithValue("@showmemo", showmemo);

                    dbCommand.CommandTimeout = 0;
                    dbCommand.Connection.Open();
                    var rowsAffected = dbCommand.ExecuteNonQuery();
                    dbCommand.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public DataRow GetCredit(string inv_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetCreditByInvNo;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable.Rows[0];
            else
                return null;

        }

        public DataTable GetCreditDetails(string inv_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = Scripts.sqlGetCreditDetailsByInvNo;

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@inv_no", inv_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable;
            else
                return null;

        }

        public DataTable GetCashCreditByCustRef(string acc,string check_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GETCASHCREDITBYCUSTREF";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc", acc);

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@check_no", check_no);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable;
            else
                return null;

        }

        public DataTable GetRcvableCreditByTimeFrame(string acc1, string acc2, string datetype, string date1, string date2, string trantype)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = "GetRcvableCreditByTimeFrame";

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc1", acc1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@acc2", acc2);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@datetype", datetype);

                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2);
                SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@trantype", trantype);

                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
                return dataTable;
            else
                return null;
        }
    }
}
