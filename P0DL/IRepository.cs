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

        /// <summary>
        /// Returns a specific customer based on ID
        /// </summary>
        /// <param name="p_Id">ID that it will check</param>
        /// <returns>Returns customer</returns>
        Customers GetCustomersById(int p_Id);

        //List Store Fronts
        List<StoreFronts> GetAllStoreFronts();

        /// <summary>
        /// this will hopefully get all the products from a store
        /// will probably only get the products i seeded for know
        /// </summary>
        /// <returns>will return a list of products</returns>
        List<Products> GetAllProducts();

        //Allows Order addition
        Orders AddOrder(Orders p_ord);

        /// <summary>
        /// Will give all orders from a customer
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns>returns a list of orders</returns>
        List<Orders> GetAllOrders(); //You are not read for this in the slightest

        //List the Line Items
        List<LineItems> GetAllLineItems();

        //List the Inventory
        List<Inventory> GetAllInventory();
    }
}