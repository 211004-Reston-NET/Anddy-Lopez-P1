using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IOrdersBL
    {
        //List the orders
        List<Orders> GetAllOrders();

        //Allows order search -- might not need
        List<Orders> GetOrders(string p_item);
    }
}