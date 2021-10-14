using System.Collections.Generic;
using P0Models;

namespace P0DL
{
    public interface IRepository
    {
        Customers AddCustomer(Customers p_cust);

        List<Customers> GetAllCustomers();

        List<StoreFronts> GetAllStoreFronts();
    }
}