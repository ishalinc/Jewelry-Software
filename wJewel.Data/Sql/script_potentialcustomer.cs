using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.Sql
{
    public static class script_potentialcustomer
    {
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

    }
}
