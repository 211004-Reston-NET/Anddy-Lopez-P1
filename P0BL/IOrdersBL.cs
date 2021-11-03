using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IOrdersBL
    {
        //List the orders from customers
        List<Orders> GetAllOrders(Customers p_cust);

        //list the orders from stores
        List<Orders> GetAllStoreOrders(StoreFronts p_store);
        
        //Allows Order addition
        Orders AddOrder(Orders p_ord);

        //Allows order search -- might not need
        List<Orders> GetOrders(string p_item);
    }
}