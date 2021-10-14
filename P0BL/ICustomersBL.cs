using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface ICustomersBL
    {
        List<Customers> GetAllCustomers();

        Customers AddCustomer(Customers p_cust);
    }
}