using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.DataAccess
{
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;
    public interface IOrderRepairAccess
    {
        string GetNextRepairOrder();

        string InsertOrderRepairdataInRepairItemsTable(RepairorderModel repairorder);

        string AddOrderRepairToRepairTable(RepairorderModel repairorder);

        string ResetSequence(RepairorderModel repairorder);
        DataTable creatdatagridbasedonrepid(string currentrepno);

        DataTable GetOrderRepairData(string currentrepno);
        DataTable GetAllRepairorders();

        DataTable GetRepairItems(string ordnumber);

        string UpdateOrderRepairdataInRepairItemsTable(RepairorderModel repairorder);
        string UpdateOrderRepairToRepairTable(RepairorderModel repairorder);


        DataTable GetItemsFromBothTables();

        DataTable GetCustomerInformationBasedOnAcc(string Acc);

        DataTable GetAllRepairTableDataForInvoice(string repairorder_number);

        DataTable GetAllRepairTableDataForEditInvoice(string repairorder_number);

        string GetStyleInformationForRepairOrderInvoice(string style);

        string SaveRepairOrderInvoice(RepairorderModel repairorder);

        string SaveOrderInvoiceDataIntoInSpItTable(RepairorderModel repairorder);

        string UpdateRpairOrderItemsTable(RepairorderModel repairorder);

        string InsertDataIntoOrderItemTable(RepairorderModel repairorder);

        string InsertDataIntoRepInvTable(RepairorderModel repairorder);

        string CheckInvoiceNumberBasedOnInvoiceNumber(string Inv_no);

        DataTable GetInvoiceHeaderInformatioBasedOnInvoiceNumber(string Inv_no);

        string DeleteInvoice(string Inv_no);

        string DeleteRepairOrders(string REPAIR_NO);

        string DeleteRepairOrderItems(string REPAIR_NO);

        DataTable GetInvoiceInformationForUpdateInvoice(string ordnumber, string inv_no);

        string UpdateRepairOrderInvoice(RepairorderModel repairorder);

        string UpdateRpairOrderItemsTableFromEditInvoice(RepairorderModel repairorder);
        string UpdateDataIntoOrderItemTable(RepairorderModel repairorder);

        string UpdateOrderInvoiceDataIntoInSpItTable(RepairorderModel repairorder);

        string UpdateDataIntoRepInvTable(RepairorderModel repairorde);

        string checkstyle(string style);
    }
}
