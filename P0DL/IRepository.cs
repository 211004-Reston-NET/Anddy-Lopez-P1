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
        /// <summary>
        /// Will delete a customer from the db
        /// </summary>
        /// <param name="p_cust">the deleted customer</param>
        /// <returns>return deleted customer</returns>
        Customers DeleteCustomer(Customers p_cust);



        //List Store Fronts
        List<StoreFronts> GetAllStoreFronts();
        //Adds a store
        StoreFronts AddStore(StoreFronts p_store);
        /// <summary>
        /// Returns a specific store based on ID
        /// </summary>
        /// <param name="p_Id">ID that it will check</param>
        /// <returns>Returns store</returns>
        StoreFronts GetStoresById(int p_Id);



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
        /// <param name="p_cust">the customer model you want the order history of</param>
        /// <returns>returns a list of orders</returns>
        List<Orders> GetAllOrders(Customers p_cust);
        /// <summary>
        /// Will give all order placed at a store
        /// </summary>
        /// <param name="p_store">the store model you want to order history from</param>
        /// <returns>returns a list of orders</returns>
        List<Orders> GetAllStoreOrders(StoreFronts p_store);
        //Edits an order
        Orders UpdateOrder(Orders p_update);
        //Returns every order --no filter
        List<Orders> GetEveryOrder();
        Orders GetNewestOrder();



        //List the Line Items
        List<LineItems> GetAllLineItems(LineItems p_item);
        //Allows Line Item Update
        void UpdateLineItem(int p_itemID, int p_quan);
        LineItems UpdateItemQuantity(LineItems p_li);
        LineItems GetItemsById(int p_itemId);
        List<LineItems> GetEveryItem();



        //List the Inventory
        List<Inventory> GetAllInventory();
    }
}