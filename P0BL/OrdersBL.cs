using System;
using System.Collections.Generic;
using System.Linq;
using P0DL;
using P0Models;

namespace P0BL
{
    public class OrdersBL : IOrdersBL
    {
        //Dependency Injection
        private IRepository _repo;
        public OrdersBL(IRepository p_repo) 
        {
            _repo = p_repo;
        }

        //adds an order
        public Orders AddOrder(Orders p_ord)
        {
            if (p_ord.SLocation == null || p_ord.TotalPrice == 0 || p_ord.StoreId == 0 || p_ord.CustId == 0)
            {
                // Will only be seen by coder
                throw new Exception("Must have value in all properties");
            }
            return _repo.AddOrder(p_ord);
        }

        public List<Orders> GetAllOrders(Customers p_cust)
        {
             return _repo.GetAllOrders(p_cust);
        }

        public List<Orders> GetAllStoreOrders(StoreFronts p_store)
        {
             return _repo.GetAllStoreOrders(p_store);
        }

        public List<Orders> GetEveryOrder()
        {
            return _repo.GetEveryOrder();
        }

        //List out the orders
        public List<Orders> GetOrders(string p_item)
        {
            List<Orders> listOfOrders = _repo.GetEveryOrder();
            
            return listOfOrders.Where(ord => ord.SLocation.Contains(p_item)).ToList();
        }

        public Orders UpdateOrder(Orders p_update)
        {
            return _repo.UpdateOrder(p_update);
        }
    }
}