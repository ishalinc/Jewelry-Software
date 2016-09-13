using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.Sql
{
    public static class script_salesmaninventory
    {
        public static readonly string sqlCheckSalesmanLog = @"SELECT * FROM inc_sls where inv_no = @logno";

        public static readonly string sqlInventoryReport = @"select a.inv_no,a.LINE_NO,a.date,a.style,a.QTY,a.COST,IIF(a.PRICE>0,a.Price,b.Price) as Price,a.WEIGHT,a.SIZE,a.APMNO,stone_wt,color_wt,[desc] from INC_SLS a inner join styles b on a.STYLE = b.style where inv_no = @inv_no";

        public static readonly string sqlStyleTrackingSlsInv = @"select style,line_no,sum(qty) as qty from SLSINVNT where style =@style group by line_no,style";

        public static readonly string sqlCheckSlsInvStyle = @"select top 1 style from SLSINVNT where style =@style order by style";

        public static readonly string sqlGetSlsQtyByStyle = @"select sum(qty) as qty from SLSINVNT where style =@style and line_no = @line_no group by line_no";

    }
}
