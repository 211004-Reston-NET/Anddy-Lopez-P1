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

        /// <summary>
        /// Returns a customer based on ID
        /// </summary>
        /// <param name="p_Id">ID that it will check</param>
        /// <returns>Returns customer</returns>
        Customers GetCustomersById(int p_Id);

        /// <summary>
        /// Will give all orders from a customer
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns>returns a list of orders</returns>
        List<Orders> GetAllOrders(Customers p_cust);
    }
}