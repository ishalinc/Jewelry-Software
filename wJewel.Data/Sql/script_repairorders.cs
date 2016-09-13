using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.Sql
{
    public static class script_repairorders
    {
        public static readonly string SqlGetMaxRecordsFromOrderTable = @"SELECT max(REPAIR_NO) FROM REPAIR";

        public static readonly string SqlInsertDataIntoOrderRepairItemTable = @"INSERT INTO REP_ITEM(REPAIR_NO,LINE,ITEM,QTY,SHIPED,STAT,VENDOR,BARCODE,SIZE) VALUES (@REPAIR_NO,@LINE,@ITEM,@QTY,@SHIPED,@STAT,@VENDOR,@BARCODE,@SIZE)";

        public static readonly string SqlInsertDataIntoOrderRepairTable = @"INSERT INTO REPAIR(REPAIR_NO,ACC,CUS_REP_NO,CUS_DEB_NO,DATE,RCV_DATE,MESSAGE,MESSAGE1,OPERATOR,NAME,ADDR1,ADDR2,CITY,STATE ,ZIP,CAN_DATE,COUNTRY,SNH,VIA_UPS,IS_COD,COD_TYPE,EARLY,ISSUE_CRDT) VALUES (@REPAIR_NO,@ACC,@CUS_REP_NO,@CUS_DEB_NO,@DATE,@RCV_DATE,@MESSAGE,@MESSAGE1,@OPERATOR,@NAME,@ADDR1,@ADDR2,@CITY,@STATE,@ZIP,@CAN_DATE,@COUNTRY,@SNH,@VIA_UPS,@IS_COD,@COD_TYPE,@EARLY,@ISSUE_CRDT)";

        //public static readonly string sqlGetRepairOrderDetailsFromRepairTable = @"SELECT REPAIR_NO,LINE,ITEM,QTY,SHIPED,STAT,VENDOR,BARCODE,SIZE FROM REP_ITEM where REPAIR_NO = @REPAIR_NO";

        public static readonly string sqlGetRepairOrderDetailsFromRepairTable = @"SELECT REP_ITEM.REPAIR_NO,REP_ITEM.LINE,REP_ITEM.ITEM,REP_ITEM.QTY,REP_ITEM.SHIPED,REP_ITEM.STAT,REP_ITEM.VENDOR,REP_ITEM.BARCODE,REP_ITEM.SIZE,repair.NAME,Format(repair.DATE,'MM/dd/yyyy') as Date,repair.ADDR1,repair.COUNTRY,repair.MESSAGE,repair.ACC,repair.ISSUE_CRDT,repair.is_cod,repair.cod_type,repair.early,repair.ADDR2,repair.CITY,repair.STATE,repair.ZIP,Format(repair.CAN_DATE,'MM/dd/yyyy') as CAN_DATE ,Format(repair.RCV_DATE,'MM/dd/yyyy') as RCV_DATE,repair.CUS_REP_NO,repair.CUS_DEB_NO,repair.[OPEN] FROM REP_ITEM inner join repair on REP_ITEM.REPAIR_NO = repair.REPAIR_NO  where repair.REPAIR_NO = @REPAIR_NO";

        public static readonly string sqlGetAllRepairorders = @"SELECT REP_ITEM.REPAIR_NO,REP_ITEM.LINE,REP_ITEM.ITEM,REP_ITEM.QTY,REP_ITEM.SHIPED,REP_ITEM.STAT,REP_ITEM.VENDOR,REP_ITEM.BARCODE,REP_ITEM.SIZE,repair.NAME,Format(repair.DATE,'MM/dd/yyyy') as Date,repair.ADDR1,repair.ACC,repair.ADDR2,repair.CITY,repair.STATE,repair.ZIP,Format(repair.CAN_DATE,'MM/dd/yyyy') as CAN_DATE ,Format(repair.RCV_DATE,'MM/dd/yyyy') as RCV_DATE,repair.CUS_REP_NO,repair.CUS_DEB_NO,repair.[OPEN] FROM REP_ITEM inner join repair on REP_ITEM.REPAIR_NO = repair.REPAIR_NO";

        public static readonly string sqlGetAllRepairTableData = @"SELECT ITEM,SIZE,QTY, STAT AS DESCRIPTION,VENDOR AS REFNO,BARCODE FROM REP_ITEM WHERE REPAIR_NO = @REPAIR_NO";

        public static readonly string sqlGetAllRepairordersBasedOnNumber = @"SELECT REP_ITEM.REPAIR_NO,REP_ITEM.LINE,REP_ITEM.ITEM,REP_ITEM.QTY,REP_ITEM.SHIPED,REP_ITEM.STAT,REP_ITEM.VENDOR,REP_ITEM.BARCODE,REP_ITEM.SIZE,repair.NAME,Format(repair.DATE,'MM/dd/yyyy') as Date,repair.ADDR1,repair.ACC,repair.ADDR2,repair.CITY,repair.STATE,repair.ZIP,Format(repair.CAN_DATE,'MM/dd/yyyy') as CAN_DATE ,Format(repair.RCV_DATE,'MM/dd/yyyy') as RCV_DATE,repair.CUS_REP_NO,repair.CUS_DEB_NO,repair.[OPEN] FROM REP_ITEM inner join repair on REP_ITEM.REPAIR_NO = repair.REPAIR_NO";

        public static readonly string SqlUpdateDataIntoOrderRepairItemTable = @"UPDATE REP_ITEM SET REPAIR_NO = @REPAIR_NO, LINE = @LINE, ITEM = @ITEM, QTY = @QTY, SHIPED = @SHIPED,STAT = @STAT,VENDOR = @VENDOR,SIZE = @SIZE WHERE REPAIR_NO = @REPAIR_NO AND BARCODE = @BARCODE";

        public static readonly string SqlUpdateDataIntoOrderRepairTable = @"UPDATE REPAIR SET REPAIR_NO = @REPAIR_NO,ACC = @ACC,CUS_REP_NO= @CUS_REP_NO,CUS_DEB_NO= @CUS_DEB_NO,DATE= @DATE,RCV_DATE= @RCV_DATE,MESSAGE= @MESSAGE,MESSAGE1= @MESSAGE,OPERATOR= @OPERATOR,NAME= @NAME,ADDR1= @ADDR1,ADDR2= @ADDR2,CITY= @CITY,STATE= @STATE ,ZIP= @ZIP,CAN_DATE= @CAN_DATE,COUNTRY= @COUNTRY,SNH= @SNH,VIA_UPS= @VIA_UPS,IS_COD= @IS_COD,COD_TYPE= @COD_TYPE,EARLY= @EARLY,ISSUE_CRDT= @ISSUE_CRDT WHERE REPAIR_NO = @REPAIR_NO";

        // public static readonly string SqlGetAllDataFromRepairAndRepairItemTable = @"select r.*,ri.* from repair r inner join  rep_item ri on  r.REPAIR_NO = ri.REPAIR_NO";

        public static readonly string SqlGetAllDataFromRepairAndRepairItemTable = @"select r.REPAIR_NO,r.ACC,r.CUS_REP_NO,r.CUS_DEB_NO,Format(r.DATE,'MM/dd/yyyy') as Date ,Format(r.RCV_DATE,'MM/dd/yyyy') as RCV_DATE,r.MESSAGE,r.MESSAGE1 ,r.[OPEN] ,r.OPERATOR,r.NAME,r.ADDR1 ,r.ADDR2,r.CITY,r.STATE,r.ZIP, Format(r.CAN_DATE,'MM/dd/yyyy') as CAN_DATE,r.COUNTRY,r.SNH,r.VIA_UPS,r.IS_COD,r.COD_TYPE,r.EARLY,r.ISSUE_CRDT ,ri.* from repair r inner join  rep_item ri on  r.REPAIR_NO = ri.REPAIR_NO";

        public static readonly string SqlGetCustomerInformationBasedOnAcc = @"SELECT * FROM CUSTOMER WHERE ACC=@ACC";

        public static readonly string sqlGetAllRepairTableDataForInvoice = @"SELECT RI.ITEM,RI.SIZE,RI.STAT AS DESCRIPTION,RI.QTY AS RPRQTY,(RI.QTY - RI.SHIPED) as [OPEN],(RI.QTY - RI.SHIPED) AS RSRVD,NULL AS INVQTY,NULL AS CHARGE,RI.VENDOR AS REFNO FROM REP_ITEM RI LEFT JOIN REPAIR R ON RI.REPAIR_NO = R.REPAIR_NO  WHERE RI.REPAIR_NO = @REPAIR_NO AND (RI.QTY - RI.SHIPED) != 0";
        //public static readonly string SqlGetStyleInformationForRepairOrderInvoice = @"SELECT PRICE FROM STYLES WHERE STYLE=@STYLE";

        public static readonly string SqlSaveOrderInvoiceDataInInvoiceTable = @"INSERT INTO INVOICE(INV_NO,ACC,BACC,ADD_COST,NAME,SNH,DATE,PON,V_CTL_NO,MESSAGE,GR_TOTAL,ADDR1,ADDR2,CITY,STATE,ZIP,COUNTRY,VIA_UPS,IS_COD,WEIGHT,TERM1,TERM_PCT1,TERM2,TERM_PCT2,TERM3,TERM_PCT3,TERM4,TERM_PCT4,INSURED,EARLY,[PERCENT],RESIDENT) VALUES (@INV_NO,@ACC,@BACC,@ADD_COST,@NAME,@SNH,@DATE,@PON,@V_CTL_NO,@MESSAGE,@GR_TOTAL,@ADDR1,@ADDR2,@CITY,@STATE,@ZIP,@COUNTRY,@VIA_UPS,@IS_COD,@WEIGHT,@TERM1,@TERM_PCT1,@TERM2,@TERM_PCT2,@TERM3,@TERM_PCT3,@TERM4,@TERM_PCT4,@INSURED,@EARLY,@PERCENT,@RESIDENT)";

        public static readonly string SqlSaveOrderInvoiceDataIntoInSpItTable = @"INSERT INTO IN_SP_IT (INV_NO,[DESC],PRICE,QTY) VALUES (@INV_NO,@DESC,@PRICE,@QTY)";

        public static readonly string SqlSaveOrderRepairInvoiceDataIntoOrItemTable = @"INSERT INTO OR_ITEMS (PON,STYLE,QTY,PRICE,SHIPED,DUE_DATE,BARCODE) VALUES (@PON,@STYLE,@QTY,@PRICE,@SHIPED,@DUE_DATE,@BARCODE)";
        public static readonly string SqlSaveOrderRepairDataInRepInvTable = @"INSERT INTO REP_INV (REP_NO,LINE,INV_NO,QTY) VALUES (@REP_NO,@LINE,@INV_NO,@QTY)";
        public static readonly string SqlUpdateRpairOrderInvTable = @"UPDATE REP_ITEM SET [SHIPED] = [SHIPED] + @SHIPED WHERE REPAIR_NO = @REPAIR_NO AND ITEM = @STYLE";
        public static readonly string SqlCheckInvoiceBasedOnInvocieNumber = @"SELECT * FROM INVOICE WHERE INV_NO = @INV_NO";
        public static readonly string sqlGetInvoiceHeaderInformatioBasedOnInvoiceNumber = @"SELECT * FROM INVOICE WHERE INV_NO = @INV_NO";

        public static readonly string sqlGetAllRepairTableDataForEditInvoice = @"SELECT STYLE AS ITEM,SIZE,NOTE AS DESCRIPTION ,QTY AS RPRQTY,(QTY - SHIPED) as [OPEN],(QTY - SHIPED) AS RSRVD,QTY AS INVQTY,PRICE AS CHARGE,ITEM_NO AS REFNO FROM OR_ITEMS  WHERE PON = @REPAIR_NO";

        public static readonly string SqlDeleteOrderInvoice = @"DELETE FROM INVOICE WHERE INV_NO=@INV_NO";

        public static readonly string SqlDeleteRepairOrderfromRepairTable = @"DELETE FROM REPAIR WHERE REPAIR_NO = @REPAIR_NO";

        public static readonly string SqlDeleteRepairOrderfromRepairItemsTable = @"DELETE FROM REP_ITEM WHERE REPAIR_NO= @REPAIR_NO";

        public static readonly string sqlGetAllRepairTableDataForEditRepairInvoice = @"SELECT rp.ITEM AS ITEM,rp.SIZE,rp.STAT AS DESCRIPTION, rp.QTY AS RPRQTY,(rp.QTY - rp.SHIPED) + isi.qty as [OPEN],(rp.QTY - rp.SHIPED) + isi.qty AS RSRVD,isi.qty as INVQTY,isi.price as CHARGE,rp.barcode AS REFNO,isi.qty as INVQTY1 FROM rep_item rp JOIN invoice iv ON iv.pon=rp.repair_no JOIN in_sp_it isi ON isi.inv_no=iv.inv_no AND LEFT(isi.[desc],15)=rp.item AND isi.qty != 0 WHERE rp.repair_no=@REPAIR_NO AND iv.INV_NO = @INV_NO";

        public static readonly string SqlUpdateOrderInvoiceDataInInvoiceTable = @"UPDATE INVOICE  SET ACC = @ACC,BACC = @BACC,ADD_COST = @ADD_COST,NAME = @NAME,SNH = @SNH,DATE = @DATE,PON = @PON,V_CTL_NO = @V_CTL_NO,MESSAGE = @MESSAGE,GR_TOTAL = @GR_TOTAL,ADDR1 = @ADDR1,ADDR2 = @ADDR2,CITY = @CITY,STATE = @STATE,ZIP = @ZIP,COUNTRY = @COUNTRY,VIA_UPS = @VIA_UPS,IS_COD = @IS_COD,WEIGHT = @WEIGHT,TERM1 = @TERM1,TERM_PCT1 = @TERM_PCT1,TERM2 = @TERM2,TERM_PCT2 = @TERM_PCT2,TERM3 = @TERM3,TERM_PCT3 = @TERM_PCT3,TERM4 = @TERM4,TERM_PCT4 = @TERM_PCT4,INSURED = @INSURED,EARLY = @EARLY,[PERCENT] = @PERCENT,RESIDENT = @RESIDENT WHERE INV_NO = @INV_NO";

        public static readonly string SqlUpdateRpairOrderItemsTableFromEditInvoice = @"UPDATE REP_ITEM SET [SHIPED] = [SHIPED] + (@SHIPED - @OLD_QTY) WHERE REPAIR_NO = @REPAIR_NO AND ITEM = @STYLE";

        public static readonly string SqlDeleteOrderInvoiceDataIntoInSpItTable = @"DELETE FROM IN_SP_IT WHERE INV_NO = @INV_NO";

        public static readonly string SqlUpdateOrderRepairDataInRepInvTable = @"UPDATE REP_INV SET LINE = @LINE , QTY = @QTY WHERE  REP_NO = @REP_NO AND INV_NO = @INV_NO";

        public static readonly string SqlUpdateOrderRepairInvoiceDataIntoOrItemTable = @"UPDATE OR_ITEMS SET STYLE = @STYLE, QTY = @QTY, PRICE = @PRICE, SHIPED = @SHIPED ,DUE_DATE = @DUE_DATE WHERE PON = @PON AND STYLE = @STYLE AND BARCODE = @BARCODE";

        public static readonly string SqlStyleFromStyleTable = @"SELECT * FROM STYLES WHERE STYLE = @STYLE";
    }
}
