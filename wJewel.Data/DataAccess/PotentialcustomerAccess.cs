
namespace IshalInc.wJewel.Data.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using IshalInc.wJewel.Data.DataModel;
    using IshalInc.wJewel.Data.Sql;

    class PotentialcustomerAccess : ConnectionAccess, IPotentialcustomerAccess
    {
        public bool AddPotentialCustomer(PotentialcustomerModel potentialmodel)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                Object estdate;
                if (potentialmodel.EST_DATE == null)
                    estdate = DBNull.Value;
                else
                    estdate = potentialmodel.EST_DATE;
                 //textc = "Insert Into MAILING(ACC,NAME,ADDR1,ADDR12,CITY1,STATE1,ZIP1,BUYER, TEL,EST_DATE,FAX,DNB,JBT,CHANGED,STORES,SOURCE,NOTE1,NOTE2,SALESMAN,COUNTRY,EMAIL,WWW) Values ('potentialmodel.ACC', 'potentialmodel.NAME', 'potentialmodel.ADDR1','potentialmodel.ADDR12', 'potentialmodel.CITY1', @STATE1, @ZIP1, @BUYER, @TEL, @EST_DATE, @FAX, @DNB, @JBT, @CHANGED, @STORE, @SOURCE, @NOTE1, @NOTE2, @SALESMAN, @COUNTRY, @EMAIL, @WWW)";
             
                dbCommand.CommandText = script_potentialcustomer.SqlInsertPotentialCustomer;
                dbCommand.Parameters.AddWithValue("@ACC", potentialmodel.ACC);
                dbCommand.Parameters.AddWithValue("@NAME", potentialmodel.NAME);
                dbCommand.Parameters.AddWithValue("@ADDR1", potentialmodel.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR12", potentialmodel.ADDR12);
                dbCommand.Parameters.AddWithValue("@CITY1", potentialmodel.CITY1);
                dbCommand.Parameters.AddWithValue("@STATE1", potentialmodel.STATE1);
                dbCommand.Parameters.AddWithValue("@ZIP1", potentialmodel.ZIP1);
                dbCommand.Parameters.AddWithValue("@BUYER", potentialmodel.BUYER);
                dbCommand.Parameters.AddWithValue("@TEL", potentialmodel.TEL);
                dbCommand.Parameters.AddWithValue("@EST_DATE", estdate);
                dbCommand.Parameters.AddWithValue("@FAX", potentialmodel.FAX);
                dbCommand.Parameters.AddWithValue("@DNB", "");
                dbCommand.Parameters.AddWithValue("@JBT", potentialmodel.JBT);
                dbCommand.Parameters.AddWithValue("@CHANGED", 1);
                dbCommand.Parameters.AddWithValue("@STORE", 1);
                dbCommand.Parameters.AddWithValue("@SOURCE", potentialmodel.SOURCE);
                dbCommand.Parameters.AddWithValue("@NOTE1", potentialmodel.NOTE1);
                dbCommand.Parameters.AddWithValue("@NOTE2", potentialmodel.NOTE2);
                dbCommand.Parameters.AddWithValue("@SALESMAN", potentialmodel.SALESMAN);
                dbCommand.Parameters.AddWithValue("@COUNTRY", potentialmodel.COUNTRY);
                dbCommand.Parameters.AddWithValue("@EMAIL", potentialmodel.EMAIL);
                dbCommand.Parameters.AddWithValue("@WWW", potentialmodel.WWW);

               

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
               

            }
                
            //return false;
        }
        public bool UpdatePotentialCustomer(PotentialcustomerModel potentialmodel)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                Object estdate;
                if (potentialmodel.EST_DATE == null)
                    estdate = DBNull.Value;
                else
                    estdate = potentialmodel.EST_DATE;
                //textc = "Insert Into MAILING(ACC,NAME,ADDR1,ADDR12,CITY1,STATE1,ZIP1,BUYER, TEL,EST_DATE,FAX,DNB,JBT,CHANGED,STORES,SOURCE,NOTE1,NOTE2,SALESMAN,COUNTRY,EMAIL,WWW) Values ('potentialmodel.ACC', 'potentialmodel.NAME', 'potentialmodel.ADDR1','potentialmodel.ADDR12', 'potentialmodel.CITY1', @STATE1, @ZIP1, @BUYER, @TEL, @EST_DATE, @FAX, @DNB, @JBT, @CHANGED, @STORE, @SOURCE, @NOTE1, @NOTE2, @SALESMAN, @COUNTRY, @EMAIL, @WWW)";
                // public static readonly string sqlUpdatePotentialCustomer = @"Update MAILING set NAME=@NAME,ADDR1=@ADDR1,ADDR12=@ADDR2,TEL=@TEL,EMAIL=@EMAIL,STATE1=@STATE1,ZIP1=@ZIP1,CITY1=@CITY1,COUNTRY=@COUNTRY,JBT=@JBT,STORES=@STORES,SOURCE=@SOURCE,SALESMAN=@SALESMAN,BUYER=@BUYER,WWW=@WWW,NOTE1=@NOTE1,NOTE2=@NOTE2,TEL=@TEL,FAX=@FAX,EST_DATE=@EST_DATE Where([ACC] = @ACC)";


                dbCommand.CommandText = script_potentialcustomer.sqlUpdatePotentialCustomer;
                dbCommand.Parameters.AddWithValue("@ACC", potentialmodel.ACC);
                dbCommand.Parameters.AddWithValue("@NAME", potentialmodel.NAME);
                dbCommand.Parameters.AddWithValue("@ADDR1", potentialmodel.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR12", potentialmodel.ADDR12);
                dbCommand.Parameters.AddWithValue("@CITY1", potentialmodel.CITY1);
                dbCommand.Parameters.AddWithValue("@STATE1", potentialmodel.STATE1);
                dbCommand.Parameters.AddWithValue("@ZIP1", potentialmodel.ZIP1);
                dbCommand.Parameters.AddWithValue("@BUYER", potentialmodel.BUYER);
                dbCommand.Parameters.AddWithValue("@TEL", potentialmodel.TEL);
                dbCommand.Parameters.AddWithValue("@EST_DATE", estdate);
                dbCommand.Parameters.AddWithValue("@FAX", potentialmodel.FAX);
                dbCommand.Parameters.AddWithValue("@DNB", "");
                dbCommand.Parameters.AddWithValue("@JBT", potentialmodel.JBT);
                //dbCommand.Parameters.AddWithValue("@CHANGED", 1);
                dbCommand.Parameters.AddWithValue("@STORES", 1);
                dbCommand.Parameters.AddWithValue("@SOURCE", potentialmodel.SOURCE);
                dbCommand.Parameters.AddWithValue("@NOTE1", potentialmodel.NOTE1);
                dbCommand.Parameters.AddWithValue("@NOTE2", potentialmodel.NOTE2);
                dbCommand.Parameters.AddWithValue("@SALESMAN", potentialmodel.SALESMAN);
                dbCommand.Parameters.AddWithValue("@COUNTRY", potentialmodel.COUNTRY);
                dbCommand.Parameters.AddWithValue("@EMAIL", potentialmodel.EMAIL);
                dbCommand.Parameters.AddWithValue("@WWW", potentialmodel.WWW);



                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;


            }

            //return false;
        }

        public DataTable SearchPotentialCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                SqlDataAdapter.SelectCommand = new SqlCommand();
                SqlDataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                SqlDataAdapter.SelectCommand.CommandText = string.Format(script_potentialcustomer.SqlSearchPotentialCustomers);



                // Fill the table from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }
        public DataRow GetPotentialCustomerById(string custACC)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_potentialcustomer.sqlGetPotentialCustomerById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ACC", custACC);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }

        public bool GetPotentialCustomerByAcc(PotentialcustomerModel potentialmodel)
        {



            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                

                dbCommand.CommandText = script_potentialcustomer.sqlDeletePotentialCustomerByACC;
                dbCommand.Parameters.AddWithValue("@ACC", potentialmodel.ACC);
               // dbCommand.CommandText = Scripts.sqlUpdatePotentialCustomer;
               // dbCommand.Parameters.AddWithValue("@ACC", potentialmodel.ACC);

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;


            }
    
           
        }

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
                SqlDataAdapter.SelectCommand.CommandText = script_potentialcustomer.SqlGetAllPotentialCustomers;

                // Fill the datatable from adapter
                SqlDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }
    }
}
