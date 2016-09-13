using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.DataAccess
{
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;
    interface IPotentialcustomerAccess
    {
        bool AddPotentialCustomer(PotentialcustomerModel potentialmodel);

        bool UpdatePotentialCustomer(PotentialcustomerModel potentialmodel);

        DataTable SearchPotentialCustomers();

        DataRow GetPotentialCustomerById(string custACC);

        bool GetPotentialCustomerByAcc(PotentialcustomerModel potentialmodel);

        DataTable GetAllCustomers();
    }
}
