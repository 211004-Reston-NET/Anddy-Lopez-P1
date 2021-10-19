using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface ICustomersBL
    {
        //List customers
        List<Customers> GetAllCustomers();

        //Allows Customer addition
        Customers AddCustomer(Customers p_cust);

        //Allows Customer search by name
        List<Customers> GetCustomers(string p_name);
    }
}