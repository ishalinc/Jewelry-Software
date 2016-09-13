using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.DataModel
{
    public class InvoiceItemsModel
    {
       public string INV_NO { get; set; }
    
        public string DESC { get; set; }
    
        public decimal? PRICE { get; set; }
    
        public decimal? QTY { get; set; }

    }


}
