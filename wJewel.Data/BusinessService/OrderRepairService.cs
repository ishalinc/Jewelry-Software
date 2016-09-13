using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.BusinessService
{

    using System.Data;
    using IshalInc.wJewel.Data.DataAccess;
    using IshalInc.wJewel.Data.DataModel;
    //RepairorderModel
    public class OrderRepairService : IOrderRepairService
    {
       
        private IOrderRepairAccess orderrepairAccess;

        public OrderRepairService()
        {
            orderrepairAccess = new OrderRepairAccess();
        }

        // public bool AddPotentialCustomer(PotentialcustomerModel potentialcustomer)
        public string GetNextRepairOrder()
        {


            return this.orderrepairAccess.GetNextRepairOrder();
        }

        public string InsertOrderRepairdataInRepairItemsTable(RepairorderModel repairorder)
        {


            return this.orderrepairAccess.InsertOrderRepairdataInRepairItemsTable(repairorder);
        }
        public string AddOrderRepairToRepairTable(RepairorderModel repairorder)
        {


            return this.orderrepairAccess.AddOrderRepairToRepairTable(repairorder);
        }
        public string ResetSequence(RepairorderModel repairorder)
        {


            return this.orderrepairAccess.ResetSequence(repairorder);
        }

        public DataTable GetOrderRepairData(string currentrepno)
        {


            return this.orderrepairAccess.GetOrderRepairData(currentrepno);
        }

        public DataTable GetAllRepairorders()
        {
            return this.orderrepairAccess.GetAllRepairorders();
        }

        public DataTable GetRepairItems(string ordnumber)
        {
            return this.orderrepairAccess.GetRepairItems(ordnumber);
        }
        public DataTable creatdatagridbasedonrepid(string currentrepno)
        {


            return this.orderrepairAccess.creatdatagridbasedonrepid(currentrepno);
        }
        public string UpdateOrderRepairdataInRepairItemsTable(RepairorderModel repairorder)
        {


            return this.orderrepairAccess.UpdateOrderRepairdataInRepairItemsTable(repairorder);
        }
        public string UpdateOrderRepairToRepairTable(RepairorderModel repairorder)
        {


            return this.orderrepairAccess.UpdateOrderRepairToRepairTable(repairorder);
        }

        public DataTable GetItemsFromBothTables()
        {
            return this.orderrepairAccess.GetItemsFromBothTables();
        }

        public DataTable GetCustomerInformationBasedOnAcc(string Acc)
        {
            return this.orderrepairAccess.GetCustomerInformationBasedOnAcc(Acc);
        }

        public DataTable GetAllRepairTableDataForInvoice(string repairorder_number)
        {
            return this.orderrepairAccess.GetAllRepairTableDataForInvoice(repairorder_number);
        }

        public DataTable GetAllRepairTableDataForEditInvoice(string repairorder_number)
        {
            return this.orderrepairAccess.GetAllRepairTableDataForEditInvoice(repairorder_number);
        }

        public string GetStyleInformationForRepairOrderInvoice(string style)
        {


            return this.orderrepairAccess.GetStyleInformationForRepairOrderInvoice(style);
        }

        public string  SaveRepairOrderInvoice(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.SaveRepairOrderInvoice(repairorder);
        }

        public string SaveOrderInvoiceDataIntoInSpItTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.SaveOrderInvoiceDataIntoInSpItTable(repairorder);
        }

        public string UpdateRpairOrderItemsTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.UpdateRpairOrderItemsTable(repairorder);
        }

        public string InsertDataIntoOrderItemTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.InsertDataIntoOrderItemTable(repairorder);
        }

        public string InsertDataIntoRepInvTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.InsertDataIntoRepInvTable(repairorder);
        }

        public string CheckInvoiceNumberBasedOnInvoiceNumber(string Inv_no)
        {
            return this.orderrepairAccess.CheckInvoiceNumberBasedOnInvoiceNumber(Inv_no);
        }

        public DataTable GetInvoiceHeaderInformatioBasedOnInvoiceNumber(string Inv_no)
        {
            return this.orderrepairAccess.GetInvoiceHeaderInformatioBasedOnInvoiceNumber(Inv_no);
        }

        public string DeleteInvoice(string INV_NO)
        {
            return this.orderrepairAccess.DeleteInvoice(INV_NO);
        }

        public string DeleteRepairOrders(string REPAIR_NO)
        {
            return this.orderrepairAccess.DeleteRepairOrders(REPAIR_NO);
        }

        public string DeleteRepairOrderItems(string REPAIR_NO)
        {
            return this.orderrepairAccess.DeleteRepairOrderItems(REPAIR_NO);
        }

        public DataTable GetInvoiceInformationForUpdateInvoice(string ordnumber,string inv_no)
        {
            return this.orderrepairAccess.GetInvoiceInformationForUpdateInvoice(ordnumber, inv_no);
        }

        public string UpdateRepairOrderInvoice(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.UpdateRepairOrderInvoice(repairorder);
        }

        public string UpdateRpairOrderItemsTableFromEditInvoice(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.UpdateRpairOrderItemsTableFromEditInvoice(repairorder);
        }

        public string UpdateDataIntoOrderItemTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.UpdateDataIntoOrderItemTable(repairorder);
        }

        public string UpdateOrderInvoiceDataIntoInSpItTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.UpdateOrderInvoiceDataIntoInSpItTable(repairorder);
        }

        public string UpdateDataIntoRepInvTable(RepairorderModel repairorder)
        {
            return this.orderrepairAccess.UpdateDataIntoRepInvTable(repairorder);
        }

        public string checkstyle(string style)
        {
            return this.orderrepairAccess.checkstyle(style);
        }
    }
}
