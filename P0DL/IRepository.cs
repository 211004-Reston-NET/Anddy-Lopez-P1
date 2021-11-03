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
        //Modify Customer?
        Customers UpdateCustomer(Customers p_update);


        //List Store Fronts
        List<StoreFronts> GetAllStoreFronts();


        /// <summary>
        /// this will hopefully get all the products from a store
        /// will probably only get the products i seeded for know
        /// </summary>
        /// <returns>will return a list of products</returns>
        List<Products> GetAllProducts();


        //Allows Order addition
        Orders AddOrder(Orders p_ord); //placing an order
        /// <summary>
        /// Will give all orders from a customer
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns>returns a list of orders</returns>
        List<Orders> GetAllOrders(Customers p_cust);
        List<Orders> GetAllStoreOrders(StoreFronts p_store);


        //List the Line Items
        List<LineItems> GetAllLineItems(LineItems p_item);
        //Allows Line Item Update
        void UpdateLineItem(int p_itemID, int p_quan);
        LineItems UpdateItemQuantity(LineItems p_li);
        LineItems GetItemsById(int p_itemId);
        //List<LineItems> GetLineItems(int p_Id);


        //List the Inventory
        List<Inventory> GetAllInventory();
    }
}