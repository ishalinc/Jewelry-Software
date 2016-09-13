using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IshalInc.wJewel.Data.BusinessService
{

    using System.Data;
    using IshalInc.wJewel.Data.DataAccess;
    using IshalInc.wJewel.Data.DataModel;
    public class PotentialCustomerService : IPotentialCustomerService
    {
        private IPotentialcustomerAccess potentialCustomerAccess;

        public PotentialCustomerService()
        {
            potentialCustomerAccess = new PotentialcustomerAccess();
        }
        public bool AddPotentialCustomer(PotentialcustomerModel potentialcustomer)
        {


            return this.potentialCustomerAccess.AddPotentialCustomer(potentialcustomer);
        }
        public bool UpdatePotentialCustomer(PotentialcustomerModel potentialcustomer)
        {


            return this.potentialCustomerAccess.UpdatePotentialCustomer(potentialcustomer);
        }
        public DataTable SearchPotentialCustomers()
        {
            return this.potentialCustomerAccess.SearchPotentialCustomers();
        }

        public DataRow GetPotentialCustomerById(string custACC)
        {
            return this.potentialCustomerAccess.GetPotentialCustomerById(custACC);
        }

        public bool GetPotentialCustomerByAcc(PotentialcustomerModel potentialcustomer)
        {
            return this.potentialCustomerAccess.GetPotentialCustomerByAcc(potentialcustomer);
        }

        public DataTable GetAllCustomers()
        {
            return this.potentialCustomerAccess.GetAllCustomers();
        }
    }
}
