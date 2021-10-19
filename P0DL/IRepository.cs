using System.Collections.Generic;
using P0Models;

namespace P0DL
{
    public interface IRepository
    {
        //Allows customer addition
        Customers AddCustomer(Customers p_cust);

        //List Customers
        List<Customers> GetAllCustomers();

        //List Store Fronts
        List<StoreFronts> GetAllStoreFronts();
    }
}