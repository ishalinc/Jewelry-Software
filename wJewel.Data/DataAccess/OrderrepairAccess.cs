

namespace IshalInc.wJewel.Data.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using IshalInc.wJewel.Data.DataModel;
    using IshalInc.wJewel.Data.Sql;
    public class OrderRepairAccess : ConnectionAccess, IOrderRepairAccess
    {
        public string GetNextRepairOrder()
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "Select cast(NEXT VALUE FOR repair_order_seq as varchar(10)) as repair_order_seq";

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["repair_order_seq"].ToString();
            }

        }

        public string ResetSequence(RepairorderModel repairorder)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "alter sequence repair_order_seq restart with "+ repairorder.REPAIR_NO;

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return "";
                //return dataRow["repair_order_seq"].ToString();
            }
        }

        public string InsertOrderRepairdataInRepairItemsTable(RepairorderModel repairorder)
        {  

            string barcode = this.GetNextReceiptBarcodeNo(repairorder);

            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlInsertDataIntoOrderRepairItemTable;
                //Object estdate, lastint, colldate;
                dbCommand.Parameters.AddWithValue("@REPAIR_NO", repairorder.REPAIR_NO);
                dbCommand.Parameters.AddWithValue("@LINE", repairorder.LINE);
                dbCommand.Parameters.AddWithValue("@ITEM", repairorder.ITEM);
                dbCommand.Parameters.AddWithValue("@QTY", Convert.ToDecimal(repairorder.QTY));
                dbCommand.Parameters.AddWithValue("@SHIPED", 0);
                dbCommand.Parameters.AddWithValue("@STAT", repairorder.STAT);
                dbCommand.Parameters.AddWithValue("@VENDOR", repairorder.VENDOR);
                dbCommand.Parameters.AddWithValue("@BARCODE", barcode);
                dbCommand.Parameters.AddWithValue("@SIZE", repairorder.SIZE);
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";


            }
        }


        public string GetNextReceiptBarcodeNo(RepairorderModel repairorder)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "Select cast(NEXT VALUE FOR repair_order_barcode_seq as varchar(10)) as repair_order_barcode_seq";

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["repair_order_barcode_seq"].ToString();
            }
        }

        public string AddOrderRepairToRepairTable(RepairorderModel repairorder)
        {
            //string barcode = this.GetNextReceiptBarcodeNo(repairorder);

            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlInsertDataIntoOrderRepairTable;
                //Object estdate, lastint, colldate;
                dbCommand.Parameters.AddWithValue("@REPAIR_NO", repairorder.REPAIR_NO);
                dbCommand.Parameters.AddWithValue("@ACC", repairorder.ACC);
                dbCommand.Parameters.AddWithValue("@CUS_REP_NO", repairorder.CUS_REP_NO); 
                dbCommand.Parameters.AddWithValue("@CUS_DEB_NO", repairorder.CUS_DEB_NO);
                dbCommand.Parameters.AddWithValue("@DATE", repairorder.DATE);
                dbCommand.Parameters.AddWithValue("@RCV_DATE", repairorder.RCV_DATE);
                dbCommand.Parameters.AddWithValue("@MESSAGE", repairorder.MESSAGE);
                dbCommand.Parameters.AddWithValue("@MESSAGE1", repairorder.MESSAGE);
                dbCommand.Parameters.AddWithValue("@OPEN", 0);
                dbCommand.Parameters.AddWithValue("@OPERATOR", repairorder.OPERATOR);
                dbCommand.Parameters.AddWithValue("@NAME", repairorder.NAME);
                dbCommand.Parameters.AddWithValue("@ADDR1", repairorder.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR2", repairorder.ADDR2);
                dbCommand.Parameters.AddWithValue("@CITY", repairorder.CITY);
                dbCommand.Parameters.AddWithValue("@STATE", repairorder.STATE);
                dbCommand.Parameters.AddWithValue("@ZIP", repairorder.ZIP);
                dbCommand.Parameters.AddWithValue("@CAN_DATE", repairorder.CAN_DATE);
                dbCommand.Parameters.AddWithValue("@COUNTRY", repairorder.COUNTRY);
                dbCommand.Parameters.AddWithValue("@SNH", 0);
                dbCommand.Parameters.AddWithValue("@VIA_UPS", repairorder.SHIPED);
                dbCommand.Parameters.AddWithValue("@IS_COD", repairorder.IS_COD);
                dbCommand.Parameters.AddWithValue("@COD_TYPE", repairorder.COD_TYPE);
                dbCommand.Parameters.AddWithValue("@EARLY", repairorder.EARLY);
                dbCommand.Parameters.AddWithValue("@ISSUE_CRDT", repairorder.ISSUE_CRDT);
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";
                
            }
        }
        public DataTable creatdatagridbasedonrepid(string currentrepno)
        {

            DataTable dataTable = new DataTable();


            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetRepairOrderDetailsFromRepairTable;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", currentrepno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
            //return "";
        }
        public DataTable GetOrderRepairData(string currentrepno)
        {

            DataTable dataTable = new DataTable();


            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetRepairOrderDetailsFromRepairTable;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", currentrepno);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
            //return "";
        }
        public DataTable GetAllRepairorders()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetAllRepairorders;

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetRepairItems(string ordnumber)
        {

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetAllRepairTableData;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", ordnumber);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }




        }

        public DataTable GetItemsFromBothTables()
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.SqlGetAllDataFromRepairAndRepairItemTable;
               // dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", ordnumber);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public string UpdateOrderRepairdataInRepairItemsTable(RepairorderModel repairorder)
        {

           // string barcode = this.GetNextReceiptBarcodeNo(repairorder);

            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlUpdateDataIntoOrderRepairItemTable;
                //Object estdate, lastint, colldate;
                dbCommand.Parameters.AddWithValue("@REPAIR_NO", repairorder.REPAIR_NO);
                dbCommand.Parameters.AddWithValue("@LINE", repairorder.LINE);
                dbCommand.Parameters.AddWithValue("@ITEM", repairorder.ITEM);
                dbCommand.Parameters.AddWithValue("@QTY", Convert.ToDecimal(repairorder.QTY));
                dbCommand.Parameters.AddWithValue("@SHIPED", 0);
                dbCommand.Parameters.AddWithValue("@STAT", repairorder.STAT);
                dbCommand.Parameters.AddWithValue("@VENDOR", repairorder.VENDOR);
                dbCommand.Parameters.AddWithValue("@BARCODE", repairorder.BARCODE);
                dbCommand.Parameters.AddWithValue("@SIZE", repairorder.SIZE);
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";


            }
        }

        public string UpdateOrderRepairToRepairTable(RepairorderModel repairorder)
        {
            //string barcode = this.GetNextReceiptBarcodeNo(repairorder);

            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlUpdateDataIntoOrderRepairTable;
                //Object estdate, lastint, colldate;
                dbCommand.Parameters.AddWithValue("@REPAIR_NO", repairorder.REPAIR_NO);
                dbCommand.Parameters.AddWithValue("@ACC", repairorder.ACC);
                dbCommand.Parameters.AddWithValue("@CUS_REP_NO", repairorder.CUS_REP_NO);
                dbCommand.Parameters.AddWithValue("@CUS_DEB_NO", repairorder.CUS_DEB_NO);
                dbCommand.Parameters.AddWithValue("@DATE", repairorder.DATE);
                dbCommand.Parameters.AddWithValue("@RCV_DATE", repairorder.RCV_DATE);
                dbCommand.Parameters.AddWithValue("@MESSAGE", repairorder.MESSAGE);
                dbCommand.Parameters.AddWithValue("@MESSAGE1", repairorder.MESSAGE);
                dbCommand.Parameters.AddWithValue("@OPEN", 0);
                dbCommand.Parameters.AddWithValue("@OPERATOR", repairorder.OPERATOR);
                dbCommand.Parameters.AddWithValue("@NAME", repairorder.NAME);
                dbCommand.Parameters.AddWithValue("@ADDR1", repairorder.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR2", repairorder.ADDR2);
                dbCommand.Parameters.AddWithValue("@CITY", repairorder.CITY);
                dbCommand.Parameters.AddWithValue("@STATE", repairorder.STATE);
                dbCommand.Parameters.AddWithValue("@ZIP", repairorder.ZIP);
                dbCommand.Parameters.AddWithValue("@CAN_DATE", repairorder.CAN_DATE);
                dbCommand.Parameters.AddWithValue("@COUNTRY", repairorder.COUNTRY);
                dbCommand.Parameters.AddWithValue("@SNH", 0);
                dbCommand.Parameters.AddWithValue("@VIA_UPS", repairorder.SHIPED);
                dbCommand.Parameters.AddWithValue("@IS_COD", repairorder.IS_COD);
                dbCommand.Parameters.AddWithValue("@COD_TYPE", repairorder.COD_TYPE);
                dbCommand.Parameters.AddWithValue("@EARLY", repairorder.EARLY);
                dbCommand.Parameters.AddWithValue("@ISSUE_CRDT", repairorder.ISSUE_CRDT);
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }
       
        public DataTable GetCustomerInformationBasedOnAcc(string Acc)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.SqlGetCustomerInformationBasedOnAcc;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ACC", Acc);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetAllRepairTableDataForInvoice(string ordnumber)
        {

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetAllRepairTableDataForInvoice;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", ordnumber);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }

        }

        public string GetStyleInformationForRepairOrderInvoice(string style)
        {
            DataTable dataTable = new DataTable();
            //DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "SELECT PRICE FROM STYLES WHERE STYLE='"+ style+"'";

                dataAdapter.Fill(dataTable);

               /* dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow["PRICE"].ToString();*/

                string itemprice = "0";
                if (dataTable.Rows.Count > 0)
                    itemprice = dataTable.Rows[0]["PRICE"].ToString();

                return itemprice;
            }
        }

        public string SaveRepairOrderInvoice(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlSaveOrderInvoiceDataInInvoiceTable;


                dbCommand.Parameters.AddWithValue("@INV_NO", repairorder.INV_NO);
                dbCommand.Parameters.AddWithValue("@ACC", repairorder.ACC);
                dbCommand.Parameters.AddWithValue("@BACC", repairorder.BACC);
                dbCommand.Parameters.AddWithValue("@ADD_COST", repairorder.ADD_COST);
                dbCommand.Parameters.AddWithValue("@NAME", repairorder.NAME);
                dbCommand.Parameters.AddWithValue("@SNH", repairorder.SNH);
                dbCommand.Parameters.AddWithValue("@DATE", repairorder.DATE);
                dbCommand.Parameters.AddWithValue("@PON", repairorder.PON);
                dbCommand.Parameters.AddWithValue("@V_CTL_NO", repairorder.V_CTL_NO);
                dbCommand.Parameters.AddWithValue("@MESSAGE", repairorder.MESSAGE);
                dbCommand.Parameters.AddWithValue("@GR_TOTAL", repairorder.GR_TOTAL);
                dbCommand.Parameters.AddWithValue("@ADDR1", repairorder.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR2", repairorder.ADDR2);
                dbCommand.Parameters.AddWithValue("@CITY", repairorder.CITY);
                dbCommand.Parameters.AddWithValue("@STATE", repairorder.STATE);
                dbCommand.Parameters.AddWithValue("@ZIP", repairorder.ZIP);
                dbCommand.Parameters.AddWithValue("@COUNTRY", repairorder.COUNTRY);
                dbCommand.Parameters.AddWithValue("@VIA_UPS", repairorder.VIA_UPS);
                dbCommand.Parameters.AddWithValue("@IS_COD", repairorder.IS_COD);
                dbCommand.Parameters.AddWithValue("@WEIGHT", repairorder.WEIGHT);
                dbCommand.Parameters.AddWithValue("@TERM1", repairorder.TERM1);
                dbCommand.Parameters.AddWithValue("@TERM_PCT1", repairorder.TERM_PCT1);
                dbCommand.Parameters.AddWithValue("@TERM2", repairorder.TERM2);
                dbCommand.Parameters.AddWithValue("@TERM_PCT2", repairorder.TERM_PCT2);
                dbCommand.Parameters.AddWithValue("@TERM3", repairorder.TERM3);
                dbCommand.Parameters.AddWithValue("@TERM_PCT3", repairorder.TERM_PCT3);
                dbCommand.Parameters.AddWithValue("@TERM4", repairorder.TERM4);
                dbCommand.Parameters.AddWithValue("@TERM_PCT4", repairorder.TERM_PCT4);
                dbCommand.Parameters.AddWithValue("@INSURED", repairorder.INSURED);
                dbCommand.Parameters.AddWithValue("@EARLY", repairorder.EARLY);
                dbCommand.Parameters.AddWithValue("@PERCENT", repairorder.PERCENT);
                dbCommand.Parameters.AddWithValue("@RESIDENT", repairorder.RESIDENT);

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
         }
        public string SaveOrderInvoiceDataIntoInSpItTable(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlSaveOrderInvoiceDataIntoInSpItTable;


                dbCommand.Parameters.AddWithValue("@INV_NO", repairorder.INV_NO);
                dbCommand.Parameters.AddWithValue("@DESC", repairorder.DESC);
                dbCommand.Parameters.AddWithValue("@PRICE", repairorder.PRICE);
                dbCommand.Parameters.AddWithValue("@QTY", repairorder.QTY);
                
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }

         public string UpdateRpairOrderItemsTable(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlUpdateRpairOrderInvTable;
                dbCommand.Parameters.AddWithValue("@SHIPED", repairorder.SHIPPED);
                dbCommand.Parameters.AddWithValue("@STYLE", repairorder.STYLE);
                dbCommand.Parameters.AddWithValue("@REPAIR_NO", repairorder.PON);
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";
            }
         }

        public string InsertDataIntoOrderItemTable(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlSaveOrderRepairInvoiceDataIntoOrItemTable;


                dbCommand.Parameters.AddWithValue("@SHIPED", repairorder.SHIPPED);
                dbCommand.Parameters.AddWithValue("@STYLE", repairorder.STYLE);
                dbCommand.Parameters.AddWithValue("@PRICE", repairorder.PRICE);
                dbCommand.Parameters.AddWithValue("@QTY", repairorder.QTY);
                dbCommand.Parameters.AddWithValue("@PON", "REP"+repairorder.PON);
                dbCommand.Parameters.AddWithValue("@DUE_DATE", repairorder.DUE_DATE);
                dbCommand.Parameters.AddWithValue("@BARCODE", repairorder.BARCODE);

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }

        public string InsertDataIntoRepInvTable(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlSaveOrderRepairDataInRepInvTable;


                dbCommand.Parameters.AddWithValue("@REP_NO", repairorder.REPAIR_NO);
                dbCommand.Parameters.AddWithValue("@LINE", repairorder.LINE);
                dbCommand.Parameters.AddWithValue("@INV_NO", repairorder.INV_NO);
                dbCommand.Parameters.AddWithValue("@QTY", repairorder.QTY);
               
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }
        public string CheckInvoiceNumberBasedOnInvoiceNumber(string Inv_no)
        {

            DataTable dataTable = new DataTable();

            string repairnumber = string.Empty;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {

                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = string.Format("SELECT * FROM INVOICE WHERE INV_NO = '{0}'",Inv_no);

                dataAdapter.Fill(dataTable);


                // return dataTable.Rows.Count > 0 ? dataTable.Rows[0]["PON"].ToString() : string.Empty;
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0]["PON"].ToString() : string.Empty;


            }

        }

        public DataTable GetInvoiceHeaderInformatioBasedOnInvoiceNumber(string Inv_no)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetInvoiceHeaderInformatioBasedOnInvoiceNumber;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@INV_NO", Inv_no);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable GetAllRepairTableDataForEditInvoice(string ordnumber)
        {

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetAllRepairTableDataForEditInvoice;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", "REP"+ordnumber);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }

        }
        public string DeleteInvoice(string INV_NO)
        {

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.SqlDeleteOrderInvoice;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@INV_NO", INV_NO);

                dataAdapter.Fill(dataTable);

                return "";
            }

        }

        public string DeleteRepairOrders(string REPAIR_NO)
        {
            DeleteRepairOrderItems(REPAIR_NO);
            DataTable dataTable = new DataTable();
            
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.SqlDeleteRepairOrderfromRepairTable;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", REPAIR_NO);

                dataAdapter.Fill(dataTable);

                return "";
            }
        }

        public string DeleteRepairOrderItems(string REPAIR_NO)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.SqlDeleteRepairOrderfromRepairItemsTable;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", REPAIR_NO);

                dataAdapter.Fill(dataTable);

                
            }
            return "";
        }

        public DataTable GetInvoiceInformationForUpdateInvoice(string ordnumber,string inv_no)
        {

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = script_repairorders.sqlGetAllRepairTableDataForEditRepairInvoice;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@REPAIR_NO", ordnumber);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@INV_NO", inv_no);
                

                dataAdapter.Fill(dataTable);

                return dataTable;
            }

        }

        public string UpdateRepairOrderInvoice(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlUpdateOrderInvoiceDataInInvoiceTable;


                dbCommand.Parameters.AddWithValue("@INV_NO", repairorder.INV_NO);
                dbCommand.Parameters.AddWithValue("@ACC", repairorder.ACC);
                dbCommand.Parameters.AddWithValue("@BACC", repairorder.BACC);
                dbCommand.Parameters.AddWithValue("@ADD_COST", repairorder.ADD_COST);
                dbCommand.Parameters.AddWithValue("@NAME", repairorder.NAME);
                dbCommand.Parameters.AddWithValue("@SNH", repairorder.SNH);
                dbCommand.Parameters.AddWithValue("@DATE", repairorder.DATE);
                dbCommand.Parameters.AddWithValue("@PON", repairorder.PON);
                dbCommand.Parameters.AddWithValue("@V_CTL_NO", repairorder.V_CTL_NO);
                dbCommand.Parameters.AddWithValue("@MESSAGE", repairorder.MESSAGE);
                dbCommand.Parameters.AddWithValue("@GR_TOTAL", repairorder.GR_TOTAL);
                dbCommand.Parameters.AddWithValue("@ADDR1", repairorder.ADDR1);
                dbCommand.Parameters.AddWithValue("@ADDR2", repairorder.ADDR2);
                dbCommand.Parameters.AddWithValue("@CITY", repairorder.CITY);
                dbCommand.Parameters.AddWithValue("@STATE", repairorder.STATE);
                dbCommand.Parameters.AddWithValue("@ZIP", repairorder.ZIP);
                dbCommand.Parameters.AddWithValue("@COUNTRY", repairorder.COUNTRY);
                dbCommand.Parameters.AddWithValue("@VIA_UPS", repairorder.VIA_UPS);
                dbCommand.Parameters.AddWithValue("@IS_COD", repairorder.IS_COD);
                dbCommand.Parameters.AddWithValue("@WEIGHT", repairorder.WEIGHT);
                dbCommand.Parameters.AddWithValue("@TERM1", repairorder.TERM1);
                dbCommand.Parameters.AddWithValue("@TERM_PCT1", repairorder.TERM_PCT1);
                dbCommand.Parameters.AddWithValue("@TERM2", repairorder.TERM2);
                dbCommand.Parameters.AddWithValue("@TERM_PCT2", repairorder.TERM_PCT2);
                dbCommand.Parameters.AddWithValue("@TERM3", repairorder.TERM3);
                dbCommand.Parameters.AddWithValue("@TERM_PCT3", repairorder.TERM_PCT3);
                dbCommand.Parameters.AddWithValue("@TERM4", repairorder.TERM4);
                dbCommand.Parameters.AddWithValue("@TERM_PCT4", repairorder.TERM_PCT4);
                dbCommand.Parameters.AddWithValue("@INSURED", repairorder.INSURED);
                dbCommand.Parameters.AddWithValue("@EARLY", repairorder.EARLY);
                dbCommand.Parameters.AddWithValue("@PERCENT", repairorder.PERCENT);
                dbCommand.Parameters.AddWithValue("@RESIDENT", repairorder.RESIDENT);

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }

        public string UpdateOrderInvoiceDataIntoInSpItTable(RepairorderModel repairorder)
        {

            using (SqlCommand dbCommand = new SqlCommand())
            {

                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlDeleteOrderInvoiceDataIntoInSpItTable;


                dbCommand.Parameters.AddWithValue("@INV_NO", repairorder.INV_NO);
               
                dbCommand.Connection.Open();
                dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlSaveOrderInvoiceDataIntoInSpItTable;


                //dbCommand.Parameters.AddWithValue("@INV_NO", repairorder.INV_NO);
                dbCommand.Parameters.AddWithValue("@DESC", repairorder.DESC);
                dbCommand.Parameters.AddWithValue("@PRICE", repairorder.PRICE);
                dbCommand.Parameters.AddWithValue("@QTY", repairorder.QTY);

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }
        public string UpdateRpairOrderItemsTableFromEditInvoice(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlUpdateRpairOrderItemsTableFromEditInvoice;
                dbCommand.Parameters.AddWithValue("@SHIPED", repairorder.SHIPPED);
                dbCommand.Parameters.AddWithValue("@STYLE", repairorder.STYLE);
                dbCommand.Parameters.AddWithValue("@REPAIR_NO", repairorder.PON);
                dbCommand.Parameters.AddWithValue("@OLD_QTY", Convert.ToInt64(repairorder.OLD_QTY));
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";
            }
        }

        public string UpdateDataIntoOrderItemTable(RepairorderModel repairorder)
        {
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.Connection = new SqlConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = script_repairorders.SqlUpdateOrderRepairInvoiceDataIntoOrItemTable;


                dbCommand.Parameters.AddWithValue("@SHIPED", repairorder.SHIPPED);
                dbCommand.Parameters.AddWithValue("@STYLE", repairorder.STYLE);
                dbCommand.Parameters.AddWithValue("@PRICE", repairorder.PRICE);
                dbCommand.Parameters.AddWithValue("@QTY", repairorder.QTY);
                dbCommand.Parameters.AddWithValue("@PON", "REP" + repairorder.PON);
                dbCommand.Parameters.AddWithValue("@DUE_DATE", repairorder.DUE_DATE);
                dbCommand.Parameters.AddWithValue("@BARCODE", repairorder.BARCODE);

                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                if (rowsAffected > 0)
                    return "1";
                else
                    return "0";

            }
        }

        public string UpdateDataIntoRepInvTable(RepairorderModel repairorder)
        {
            return "";
        }

        public string checkstyle(string style)
        {
            DataTable dataTable = new DataTable();
            //DataRow dataRow;

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {

                dataAdapter.SelectCommand = new SqlCommand();
                dataAdapter.SelectCommand.Connection = new SqlConnection(ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = "SELECT STYLE FROM STYLES WHERE STYLE='" + style + "'";

                dataAdapter.Fill(dataTable);

                string itemprice = "0";
                if (dataTable.Rows.Count > 0)
                    itemprice = dataTable.Rows[0]["STYLE"].ToString();

                return itemprice;
            }
        }
    }
}
