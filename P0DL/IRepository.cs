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

        //List Products
        List<Products> GetAllProducts();

        /// <summary>
        /// Will give all orders from a customer
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns>returns a list of orders</returns>
        List<Orders> GetAllOrders(Customers p_cust);

        /// <summary>
        /// Returns a customer based on ID
        /// </summary>
        /// <param name="p_Id">ID that it will check</param>
        /// <returns>Returns customer</returns>
        Customers GetCustomersById(int p_Id);
    }
}