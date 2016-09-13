// -----------------------------------------------------------------------
// <copyright file="Scripts.cs" company="Ishal Inc.">
// Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------

namespace IshalInc.wJewel.Data.Sql
{
    /// <summary>
    /// DBConstants static class contains sql string constants
    /// </summary>
    public static class Scripts
    {
        /// <summary>
        /// Sql to get a  customer details by Id
        /// </summary>
        public static readonly string sqlGetCustomerById = @"SELECT ACC,NAME,SOUNDX,ADDR1,ADDR12,CITY1,STATE1,ZIP1,NAME2,
            ADDR2,ADDR22,CITY2,STATE2,ZIP2,SHIP_VIA,BUYER,TEL,FAX,[PERCENT],BILL_ACC,TERM_PCT1,TERM1,TERM_PCT2,TERM2,
            TERM_PCT3,TERM3,TERM_PCT4,TERM4,SALESMAN1,SHARE1,PERCENT1,SALESMAN2,SHARE2,PERCENT2,SALESMAN3,SHARE3,
            PERCENT3,SALESMAN4,SHARE4,PERCENT4,CREDIT,THEYOWE,SKU_FILE,PRICE_FILE,ITEMIZED,ITEM_NO,JBT,TOT_MEM,
            EST_DATE,CHANGED,SNH,BH_VEND_NO,DEPT,STORE,F_INV,F_DATE,PAY_NO,DEDUCTION,BH_DIV,SOURCE,IS_COD,COD_TYPE,
            NOTE1,ON_HOLD,ON_MAIL,INTEREST,NOTE2,NOTE3,DO_INT,COUNTRY,WWW,EMAIL,GRACE,LAST_INT,COUNTRY2,PASSPORT,
            TAGS,RESIDENT,TERM5,TERM_PCT5,TERM6,TERM_PCT6,TERM7,TERM_PCT7,TERM8,TERM_PCT8,FOLOUP,FOL_DATE,REASON,COLCSENT,
            COLCDATE,COLCRSN,TERM9,TERM_PCT9,TERM10,TERM_PCT10,TERM11,TERM_PCT11,TERM12,TERM_PCT12,FNAME,LNAME,NOTE,
            TAX_ID,FDX_NO,ID FROM CUSTOMER Where Id = @Id";

        /// <summary>
        /// Sql to get all customers
        /// </summary>
        public static readonly string SqlGetAllCustomers = @"SELECT ID,ACC,NAME,BILL_ACC,NAME2,CITY1,STATE1,ZIP1,COUNTRY,STATE1,STATE2,COUNTRY2,ADDR2,TEL,SALESMAN1,SALESMAN2,SALESMAN3,SALESMAN4,BUYER,NOTE,ON_HOLD,COLCDATE FROM CUSTOMER";

        /// <summary>
        /// sql to insert a  customer details
        /// </summary>
        public static readonly string SqlInsertCustomer = @"Insert Into Customer(ACC,NAME,ADDR1,ADDR12,CITY1,STATE1,ZIP1,NAME2,
            ADDR2,ADDR22,CITY2,STATE2,ZIP2,SHIP_VIA,ON_MAIL,RESIDENT,BUYER,TEL,FAX,[PERCENT],BILL_ACC,TERM_PCT1,TERM1,TERM_PCT2,TERM2,
            TERM_PCT3,TERM3,TERM_PCT4,TERM4,TERM_PCT5,TERM5,TERM_PCT6,TERM6,TERM_PCT7,TERM7,TERM_PCT8,TERM8,SALESMAN1,PERCENT1,SALESMAN2,PERCENT2,SALESMAN3,
            PERCENT3,SALESMAN4,PERCENT4,CREDIT,PRICE_FILE,JBT,EST_DATE,ON_HOLD,INTEREST,COUNTRY,WWW,EMAIL,GRACE,LAST_INT,COUNTRY2,REASON,COLCSENT,
            COLCDATE,COLCRSN,NOTE,TAX_ID,IS_COD,COD_TYPE)
            Values(@ACC,@NAME,@ADDR1,@ADDR12,@CITY1,@STATE1,@ZIP1,@NAME2,
            @ADDR2,@ADDR22,@CITY2,@STATE2,@ZIP2,@SHIP_VIA,@ON_MAIL,@RESIDENT,@BUYER,@TEL,@FAX,@PERCENT,@BILL_ACC,@TERM_PCT1,@TERM1,@TERM_PCT2,@TERM2,
            @TERM_PCT3,@TERM3,@TERM_PCT4,@TERM4,@TERM_PCT5,@TERM5,@TERM_PCT6,@TERM6,@TERM_PCT7,@TERM7,@TERM_PCT8,@TERM8,
			@SALESMAN1,@PERCENT1,@SALESMAN2,@PERCENT2,@SALESMAN3,@PERCENT3,@SALESMAN4,@PERCENT4,@CREDIT,@PRICE_FILE,@JBT,
            @EST_DATE,@ON_HOLD,@INTEREST,@COUNTRY,@WWW,@EMAIL,@GRACE,@LAST_INT,@COUNTRY2,@REASON,@COLCSENT,
            @COLCDATE,@COLCRSN,@NOTE,@TAX_ID,@IS_COD,@COD_TYPE)";

        /// <summary>
        /// sql to search for customers
        /// </summary>
        public static readonly string SqlSearchCustomers = @"SELECT ID,ACC,NAME,TEL,EMAIL,ADDR1,STATE1,ZIP1 FROM CUSTOMER";

        public static readonly string SqlSearchInvoiceCustomers = @"SELECT ID,ACC,NAME,TEL,EMAIL,ADDR1,STATE1,ZIP1 FROM CUSTOMER WHERE ACC = BILL_ACC";

        /// <summary>
        /// sql to search for customers
        /// </summary>
        public static readonly string sqlGetEmailIdByAcc = @"SELECT ISNULL(EMAIL,'') as EMAIL FROM CUSTOMER WHERE ACC=@ACC";


        /// <summary>
        /// sql to update  customer details
        /// </summary>
        public static readonly string sqlUpdateCustomer = @"Update Customer set ACC=@ACC,NAME=@NAME,ADDR1=@ADDR1,ADDR12=@ADDR12,CITY1=@CITY1,
            STATE1=@STATE1,ZIP1=@ZIP1,NAME2=@NAME2,ADDR2=@ADDR2,ADDR22=@ADDR22,CITY2=@CITY2,STATE2=@STATE2,ZIP2=@ZIP2,
            SHIP_VIA=@SHIP_VIA,ON_MAIL=@ON_MAIL,IS_COD=@IS_COD,@COD_TYPE=COD_TYPE,RESIDENT=@RESIDENT,BUYER=@BUYER,TEL=@TEL,FAX=@FAX,[PERCENT]=@PERCENT,BILL_ACC=@BILL_ACC,TERM_PCT1=@TERM_PCT1,
            TERM1=@TERM1,TERM_PCT2=@TERM_PCT2,TERM2=@TERM2,TERM_PCT3=@TERM_PCT3,TERM3=@TERM3,TERM_PCT4=@TERM_PCT4,TERM4=@TERM4,
			TERM_PCT5=@TERM_PCT5,TERM5=@TERM5,TERM_PCT6=@TERM_PCT6,TERM6=@TERM6,TERM_PCT7=@TERM_PCT7,TERM7=@TERM7,TERM_PCT8=@TERM_PCT8,TERM8=@TERM8,
            SALESMAN1=@SALESMAN1,PERCENT1=@PERCENT1,SALESMAN2=@SALESMAN2,PERCENT2=@PERCENT2,SALESMAN3=@SALESMAN3,
            PERCENT3=@PERCENT3,SALESMAN4=@SALESMAN4,PERCENT4=@PERCENT4,CREDIT=@CREDIT,PRICE_FILE=@PRICE_FILE,JBT=@JBT,
            EST_DATE=@EST_DATE,ON_HOLD=@ON_HOLD,INTEREST=@INTEREST,COUNTRY=@COUNTRY,WWW=@WWW,EMAIL=@EMAIL,GRACE=@GRACE,
            LAST_INT=@LAST_INT,COUNTRY2=@COUNTRY2,REASON=@REASON,COLCSENT=@COLCSENT,COLCDATE=@COLCDATE,COLCRSN=@COLCRSN,
            NOTE=@NOTE,TAX_ID=@TAX_ID Where([Id] = @Id)";


        /// <summary>
        /// sql to validate billing account
        /// </summary>
        public static readonly string sqlValidBillingAcct = "select * from customer where bill_acc = @bill_acc and bill_acc = acc";

        /// <summary>
        /// sql to delete a  customer record
        /// </summary>
        public static readonly string sqlDeleteCustomer = "Delete From Customer Where (Id = @Id)";

        /// <summary>
        /// sql to get salesman name and code
        /// </summary>
        public static readonly string sqlGetSalesMan = "select '' as Name,'' as Code from salesmen union select name,code from salesmen";

        /// <summary>
        /// sql to get salesman name and code
        /// </summary>
        public static readonly string sqlGetPriceFile = "select '' as file_no from salesmen union select file_no from prices";

        /// <summary>
        /// sql to check valid account code
        /// </summary>
        public static readonly string sqlCheckValidCustomerCode = "select *  From Customer Where acc=@acc";

        /// <summary>
        /// sql to check valid bill acccount code
        /// </summary>
        public static readonly string sqlCheckValidBillAccountCode = "select *  From Customer Where bill_acc=@bill_acc and bill_acc = acc";

        /// <summary>
        /// sql to get invoice by invoice #
        /// </summary>
        public static readonly string sqlGetInvoiceByInvNo = "select *  From Invoice Where inv_no=@inv_no";


        /// <summary>
        /// sql to get invoice by invoice #
        /// </summary>
        public static readonly string sqlGetInvoiceItemsByInvNo = "select inv_no,[desc],price  From in_sp_it Where inv_no=@inv_no";


        /// <summary>
        /// sql to search for customers
        /// </summary>
        public static readonly string sqlSearchInvoice = @"SELECT ID,INV_NO,CUSTOMER.ACC,CUSTOMER.NAME,TEL,INVOICE.DATE,CUSTOMER.ADDR1,STATE1,ZIP1,GR_TOTAL FROM INVOICE INNER JOIN CUSTOMER ON INVOICE.ACC = CUSTOMER.ACC";

        /// <summary>
        /// sql to search for invoice statement
        /// </summary>
        public static readonly string sqlStatementOfInvoice = @"SELECT INV_NO,INVOICE.BACC as BILL_ACC,INVOICE.DATE,IIF(ISNULL(RSFM_AMT,0) = 0,GR_TOTAL,0) AS INVOICE,IIF(ISNULL(RSFM_AMT,0) > 0,GR_TOTAL,0) AS SFM,ISNULL(CREDITS,0) AS CREDITS,GR_TOTAL-ISNULL(CREDITS,0) AS BALANCE,ISNULL(RSFM_AMT,0) AS RSFM,GR_TOTAL,ISNULL(INVOICE.DEDUCTION,0) AS DEDUCTIONS,CUSTOMER.NAME,CUST_PON,CUSTOMER.STATE1,CUSTOMER.COUNTRY,CUSTOMER.SALESMAN1,CUSTOMER.SALESMAN2,CUSTOMER.SALESMAN3,CUSTOMER.SALESMAN4,CUSTOMER.ACC FROM INVOICE INNER JOIN CUSTOMER ON INVOICE.ACC = CUSTOMER.ACC";



        /// <summary>
        /// sql to get Insert invoice #
        /// </summary>
        public static readonly string sqlInsertInvoice = @"INSERT INTO INVOICE (INV_NO,BACC,ACC,ADD_COST,SNH,DATE,PON,MESSAGE,GR_TOTAL,ADDR1,ADDR2,CITY,STATE,ZIP,COUNTRY,VIA_UPS,IS_COD,WEIGHT,COD_TYPE,CUST_PON,SHIP_BY,
                                                           Term1,Term2,TERM3,TERM4,Term5,Term6,TERM7,TERM8,TERM_PCT1,TERM_PCT2,TERM_PCT3,TERM_PCT4,TERM_PCT5,TERM_PCT6,TERM_PCT7,TERM_PCT8,Operator,Name,Insured, Early,[Percent],Man_Ship,Resident,IS_FDX,IS_DEB)
                                                          VALUES(@INV_NO, @BACC, @ACC, @ADD_COST, @SNH, @DATE, @PON, @MESSAGE, @GR_TOTAL, @ADDR1, @ADDR2, @CITY, @STATE, @ZIP, @COUNTRY, @VIA_UPS, @IS_COD,
                                                         @WEIGHT, @COD_TYPE, @CUST_PON, @SHIP_BY,@TERM1, @TERM2, @TERM3, @TERM4,@TERM5, @TERM6, @TERM7, @TERM8, @TERM_PCT1, @TERM_PCT2, @TERM_PCT3, @TERM_PCT4, @TERM_PCT5, @TERM_PCT6, @TERM_PCT7, @TERM_PCT8,@OPERATOR, @Name, @Insured, @Early, @Percent, @Man_Ship, @Resident, @IS_FDX, @IS_DEB)";

        /// <summary>
        /// sql to get Update invoice #
        /// </summary>
        public static readonly string sqlUpdateInvoice = @"Update Invoice set BACC=@BACC,ACC=@ACC,ADD_COST=@ADD_COST,SNH=@SNH,DATE=@DATE,PON=@PON,MESSAGE=@MESSAGE,GR_TOTAL= @GR_TOTAL,
                                                    ADDR1=@ADDR1,ADDR2=@ADDR2,CITY=@CITY,STATE=@STATE,ZIP=@ZIP,COUNTRY=@COUNTRY,VIA_UPS=@VIA_UPS,IS_COD=@IS_COD,WEIGHT= @WEIGHT,COD_TYPE=@COD_TYPE,
                                                    CUST_PON=@CUST_PON,SHIP_BY=@SHIP_BY,TERM1=@TERM1,TERM2=@TERM2,TERM3=@TERM3,TERM4=@TERM4,TERM5=@TERM5,TERM6=@TERM6,TERM7=@TERM7,TERM8=@TERM8,TERM_PCT1=@TERM_PCT1,TERM_PCT2=@TERM_PCT2,
                                                    TERM_PCT3=@TERM_PCT3,TERM_PCT4=@TERM_PCT4,TERM_PCT5=@TERM_PCT5,TERM_PCT6=@TERM_PCT6,TERM_PCT7=@TERM_PCT7,TERM_PCT8=@TERM_PCT8,NAME=@NAME,INSURED=@INSURED,EARLY=@EARLY,[PERCENT]=@PERCENT,MAN_SHIP=@MAN_SHIP,RESIDENT=@RESIDENT,IS_FDX=@IS_FDX,IS_DEB=@IS_DEB WHERE INV_NO=@INV_NO";
        



        /// <summary>
        /// sql to get Update invoice #
        /// </summary>
        public static readonly string sqlDeleteInvoice = "DELETE FROM INVOICE WHERE INV_NO = @INV_NO";

        /// <summary>
        /// sql to get Insert invoice #
        /// </summary>
        public static readonly string sqlInsertItems = @"INSERT INTO IN_SP_IT (INV_NO,[DESC],PRICE,QTY)
                                                          VALUES(@INV_NO,@DESC,@PRICE,@QTY)";




        /// <summary>
        /// sql to get Delete invoice Items with Styles#
        /// </summary>
        public static readonly string sqlDeleteInvoiceItems = "DELETE FROM IN_SP_IT WHERE INV_NO = @INV_NO";

        /// <summary>
        /// sql to get Insert invoice #
        /// </summary>
        public static readonly string sqldDeleteItems = @"DELETE FROM IN_SP_IT WHERE INV_NO = @INV_NO";


        public static readonly string sqlGetnextInvoiceNr = "Select cast(NEXT VALUE FOR InvoiceSequence as varchar(10)) as inv_no";

        public static readonly string sqlGetMasterDetailInvoice = @"SELECT INVOICE.INV_NO, INVOICE.BACC, INVOICE.ACC, INVOICE.ADD_COST, INVOICE.SNH, INVOICE.DATE, INVOICE.PON, INVOICE.MESSAGE, 
INVOICE.MESSAGE1, INVOICE.MESSAGE2, INVOICE.GR_TOTAL, INVOICE.NAME, INVOICE.ADDR1, INVOICE.ADDR2, INVOICE.CITY, INVOICE.STATE, INVOICE.ZIP, INVOICE.COUNTRY, 
INVOICE.DEDUCTION, INVOICE.VIA_UPS, INVOICE.IS_COD, INVOICE.WEIGHT, INVOICE.COD_TYPE, INVOICE.CUST_PON, INVOICE.OPERATOR, INVOICE.SHIP_BY,
INVOICE.TERM1,INVOICE.TERM2,INVOICE.TERM3,INVOICE.TERM4,INVOICE.TERM5,INVOICE.TERM6,INVOICE.TERM7,INVOICE.TERM8,INVOICE.TERM_PCT1,INVOICE.TERM_PCT2,INVOICE.TERM_PCT3,INVOICE.TERM_PCT4,   
INVOICE.TERM_PCT5,INVOICE.TERM_PCT6,INVOICE.TERM_PCT7,INVOICE.TERM_PCT8,IN_SP_IT.[DESC], IN_SP_IT.PRICE, IN_SP_IT.QTY, CUSTOMER.NAME as CNAME,CUSTOMER.ADDR1 as CADDR1,CUSTOMER.ADDR12 as CADDR2, CUSTOMER.ZIP1 as CZIP, CUSTOMER.CITY1 as CCITY, CUSTOMER.STATE1 as CSTATE,CUSTOMER.COUNTRY as CCOUNTRY
FROM INVOICE LEFT OUTER JOIN IN_SP_IT ON INVOICE.INV_NO = IN_SP_IT.INV_NO
INNER JOIN CUSTOMER ON INVOICE.ACC = CUSTOMER.ACC WHERE INVOICE.INV_NO =  @INV_NO ";



        public static readonly string sqlGetMasterDetailInvoicePO = @"SELECT INVOICE.INV_NO, INVOICE.BACC, INVOICE.ACC, INVOICE.ADD_COST, INVOICE.SNH, INVOICE.DATE, INVOICE.PON, INVOICE.MESSAGE, 
INVOICE.MESSAGE1, INVOICE.MESSAGE2, INVOICE.GR_TOTAL, INVOICE.NAME, INVOICE.ADDR1, INVOICE.ADDR2, INVOICE.CITY, INVOICE.STATE, INVOICE.ZIP, INVOICE.COUNTRY, 
INVOICE.DEDUCTION, INVOICE.VIA_UPS, INVOICE.IS_COD, INVOICE.WEIGHT, INVOICE.COD_TYPE, INVOICE.CUST_PON, INVOICE.OPERATOR, INVOICE.SHIP_BY,
INVOICE.TERM1,INVOICE.TERM2,INVOICE.TERM3,INVOICE.TERM4,INVOICE.TERM5,INVOICE.TERM6,INVOICE.TERM7,INVOICE.TERM8,INVOICE.TERM_PCT1,INVOICE.TERM_PCT2,INVOICE.TERM_PCT3,INVOICE.TERM_PCT4,   
INVOICE.TERM_PCT5,INVOICE.TERM_PCT6,INVOICE.TERM_PCT7,INVOICE.TERM_PCT8,IN_ITEMS.STYLE,IN_ITEMS.SIZE,IIF(LEN(IN_ITEMS.[DESC])> 0,IN_ITEMS.[DESC],IIF(LEN(STYLES.[DESC]) > 0,STYLES.[DESC], + 'CERT #' +  CERT_NO)) AS [DESC], 
IN_ITEMS.PRICE, IN_ITEMS.QTY,IN_ITEMS.[WEIGHT] AS WEIGHT1,ROUND(IIF(BY_WT=1,IN_ITEMS.WEIGHT,IN_ITEMS.QTY)* IN_ITEMS.PRICE,2) AS AMOUNT, CUSTOMER.NAME AS CNAME,CUSTOMER.ADDR1 AS CADDR1,CUSTOMER.ADDR12 AS CADDR2, CUSTOMER.ZIP1 AS CZIP, CUSTOMER.CITY1 AS CCITY, CUSTOMER.STATE1 AS CSTATE,CUSTOMER.COUNTRY AS CCOUNTRY,CUSTOMER.BUYER,CUSTOMER.TEL
FROM INVOICE LEFT OUTER JOIN IN_ITEMS ON INVOICE.INV_NO = IN_ITEMS.INV_NO
LEFT OUTER JOIN STYLES ON IN_ITEMS.STYLE = STYLES.STYLE
INNER JOIN CUSTOMER ON INVOICE.ACC = CUSTOMER.ACC WHERE INVOICE.INV_NO =  @INV_NO ORDER BY IN_ITEMS.STYLE";


        /// <summary>
        /// sql to search for customers
        /// </summary>
        public static readonly string sqlSearchMemo = @"SELECT ID,MEMO_NO,CUSTOMER.ACC,CUSTOMER.NAME,TEL,MEMO.DATE,CUSTOMER.ADDR1,STATE1,ZIP1,GR_TOTAL,PON FROM MEMO INNER JOIN CUSTOMER ON MEMO.ACC = CUSTOMER.ACC";

        /// <summary>
        /// sql to get memo by memono #
        /// </summary>
        public static readonly string sqlGetMemoByInvNo = "select *  From Memo Where memo_no=@memo_no";

        public static readonly string sqlGetBankAcc = "select * from bank_acc";

        public static readonly string sqlGetPayItemsByPayNo = "select * from pay_item where pay_no =@pay_no";

        public static readonly string sqlGetPayItemsByInvNo = "select * from pay_item where inv_no =@inv_no";

        public static readonly string sqlGetPaymentByInvNo = "select * from payments where rtv_pay = 'P' and Ltrim(inv_no) = @inv_no";

        public static readonly string sqlGetPaymentByInvNo_RTV = "select * from payments where rtv_pay = @rtv_pay and Ltrim(inv_no) = @inv_no";

        public static readonly string sqlGetCreditPaymentByInvNo_RTV = "select * from pay_item where pay_no in (select pay_no from pay_item where rtv_pay = @rtv_pay and Ltrim(inv_no) = @inv_no) order by rtv_pay,inv_no";

        public static readonly string sqlGetCreditByInvNo = "select * from credits where Ltrim(inv_no) = @inv_no";

        public static readonly string sqlGetCreditDetailsByInvNo = "SELECT credits.*, customer.name, customer.addr1, customer.addr12, customer.city1, customer.state1,customer.zip1, customer.country, payments.check_no, payments.chk_date from credits, payments, customer  WHERE credits.inv_no= @inv_no AND credits.acc= customer.acc AND credits.inv_no = payments.inv_no  and rtv_pay = 'C'";
        /// <summary>
        /// sql to add potential customer information in to mailingtable #
        /// </summary>
        public static readonly string SqlInsertPotentialCustomer = @"Insert Into MAILING(ACC,NAME,ADDR1,ADDR12,CITY1,STATE1,ZIP1,BUYER,
            TEL,EST_DATE,FAX,DNB,JBT,CHANGED,STORES,SOURCE,NOTE1,NOTE2,SALESMAN,COUNTRY,EMAIL,WWW)
            Values(@ACC,@NAME,@ADDR1,@ADDR12,@CITY1,@STATE1,@ZIP1,@BUYER,@TEL,@EST_DATE,@FAX,@DNB,@JBT,@CHANGED,@STORE,@SOURCE,@NOTE1,@NOTE2,@SALESMAN,@COUNTRY,@EMAIL,@WWW)";

        /// <summary>
        /// sql to search for potential customers
        /// </summary>
        public static readonly string SqlSearchPotentialCustomers = @"SELECT 0 as ID,ACC,NAME,TEL,EMAIL,ADDR1,STATE1,ZIP1 FROM MAILING";


        public static readonly string sqlGetPotentialCustomerById = @"SELECT ACC,NAME,TEL,EMAIL,ADDR1,STATE1,ZIP1,CITY1,COUNTRY,JBT,STORES,SOURCE,SALESMAN,BUYER,WWW,NOTE1,NOTE2,TEL,FAX,EST_DATE FROM MAILING Where ACC = @ACC";

        public static readonly string sqlUpdatePotentialCustomer = @"Update MAILING set NAME=@NAME,TEL=@TEL,EMAIL=@EMAIL,ADDR1=@ADDR1,ADDR12=@ADDR12,STATE1=@STATE1,ZIP1=@ZIP1,CITY1=@CITY1,COUNTRY=@COUNTRY,JBT=@JBT,STORES=@STORES,SOURCE=@SOURCE,SALESMAN=@SALESMAN,BUYER=@BUYER,WWW=@WWW,NOTE1=@NOTE1,NOTE2=@NOTE2,FAX=@FAX,EST_DATE=@EST_DATE Where([ACC] = @ACC)";

        public static readonly string sqlDeletePotentialCustomerByACC = @"DELETE FROM MAILING Where ACC = @ACC";

        public static readonly string SqlGetAllPotentialCustomers = @"SELECT ACC,NAME,TEL,EMAIL,ADDR1,STATE1,ZIP1,CITY1,COUNTRY,JBT,STORES,SOURCE,SALESMAN,BUYER,WWW,NOTE1,NOTE2,TEL,FAX,EST_DATE FROM MAILING";

        public static readonly string SqlInsertCustomerFromPotentialCustomerTable = @"Insert Into Customer(ACC,NAME,ADDR1,CITY1,STATE1,ZIP1,TEL,COUNTRY,WWW,EMAIL,EST_DATE,JBT,FAX,BUYER,NOTE,SALESMAN1) Values (@ACC,@NAME,@ADDR1,@CITY1,@STATE1,@ZIP1,@TEL,@COUNTRY,@WWW,@EMAIL,@EST_DATE,@JBT,@FAX,@BUYER,@NOTE,@SALESMAN1)";

        public static readonly string SqlGetMaxRecordsFromOrderTable = @"SELECT max(REPAIR_NO) FROM REPAIR";

        public static readonly string SqlInsertDataIntoOrderRepairItemTable = @"INSERT INTO REP_ITEM(REPAIR_NO,LINE,ITEM,QTY,SHIPED,STAT,VENDOR,BARCODE,SIZE) VALUES (@REPAIR_NO,@LINE,@ITEM,@QTY,@SHIPED,@STAT,@VENDOR,@BARCODE,@SIZE)";

        public static readonly string SqlInsertDataIntoOrderRepairTable = @"INSERT INTO REPAIR(REPAIR_NO,ACC,CUS_REP_NO,CUS_DEB_NO,DATE,RCV_DATE,MESSAGE,MESSAGE1,OPERATOR,NAME,ADDR1,ADDR2,CITY,STATE ,ZIP,CAN_DATE,COUNTRY,SNH,VIA_UPS,IS_COD,COD_TYPE,EARLY,ISSUE_CRDT) VALUES (@REPAIR_NO,@ACC,@CUS_REP_NO,@CUS_DEB_NO,@DATE,@RCV_DATE,@MESSAGE,@MESSAGE1,@OPERATOR,@NAME,@ADDR1,@ADDR2,@CITY,@STATE,@ZIP,@CAN_DATE,@COUNTRY,@SNH,@VIA_UPS,@IS_COD,@COD_TYPE,@EARLY,@ISSUE_CRDT)";

        //public static readonly string sqlGetRepairOrderDetailsFromRepairTable = @"SELECT REPAIR_NO,LINE,ITEM,QTY,SHIPED,STAT,VENDOR,BARCODE,SIZE FROM REP_ITEM where REPAIR_NO = @REPAIR_NO";

        public static readonly string sqlGetRepairOrderDetailsFromRepairTable = @"SELECT REP_ITEM.REPAIR_NO,REP_ITEM.LINE,REP_ITEM.ITEM,REP_ITEM.QTY,REP_ITEM.SHIPED,REP_ITEM.STAT,REP_ITEM.VENDOR,REP_ITEM.BARCODE,REP_ITEM.SIZE,repair.NAME,Format(repair.DATE,'MM/dd/yyyy') as Date,repair.ADDR1,repair.ACC,repair.ADDR2,repair.CITY,repair.STATE,repair.ZIP,Format(repair.CAN_DATE,'MM/dd/yyyy') as CAN_DATE ,Format(repair.RCV_DATE,'MM/dd/yyyy') as RCV_DATE,repair.CUS_REP_NO,repair.CUS_DEB_NO,repair.[OPEN] FROM REP_ITEM inner join repair on REP_ITEM.REPAIR_NO = repair.REPAIR_NO  where repair.REPAIR_NO = @REPAIR_NO";

        public static readonly string sqlGetSalesmenCodes = "select distinct code from salesmen";
    }
}
