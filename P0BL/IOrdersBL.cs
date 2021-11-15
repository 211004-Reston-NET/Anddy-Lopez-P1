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

        //Returns every single order --no filter
        List<Orders> GetEveryOrder();

        //Allows order search by store location
        Orders GetOrder(string p_item);

        //Selects the most recently made order by order ID
        Orders GetNewestOrder();

        //updates order by adding store ID and address
        Orders UpdateOrderStoreInfo(Orders p_update, int sID, string sAddress);

        //updates the total price of the order
        Orders UpdateOrderTotal(Orders p_update, int p_quan, int p_price);
    }
}