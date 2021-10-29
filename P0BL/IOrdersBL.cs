using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IOrdersBL
    {
        //List the orders
        List<Orders> GetAllOrders();
        
        //Allows Order addition
        Orders AddOrder(Orders p_ord);

        //Allows order search -- might not need
        List<Orders> GetOrders(string p_item);
    }
}