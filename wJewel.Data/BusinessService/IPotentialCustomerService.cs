namespace IshalInc.wJewel.Data.BusinessService
{
    using System.Data;
    using IshalInc.wJewel.Data.DataModel;
    public interface IPotentialCustomerService
    {
        bool AddPotentialCustomer(PotentialcustomerModel potentialmodel);
        bool UpdatePotentialCustomer(PotentialcustomerModel potentialmodel);
        DataTable SearchPotentialCustomers();

        DataRow GetPotentialCustomerById(string custACC);

        bool GetPotentialCustomerByAcc(PotentialcustomerModel potentialmodel);

        DataTable GetAllCustomers();
    }
}
