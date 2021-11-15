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

        public Orders GetNewestOrder()
        {
            List<Orders> listOfOrders = _repo.GetEveryOrder();
            
            return listOfOrders.FirstOrDefault(ord => ord.Id.Equals(int.MaxValue));
        }

        //List out the orders from a store location
        public Orders GetOrder(string p_item)
        {
            List<Orders> listOfOrders = _repo.GetEveryOrder();
            
            return listOfOrders.FirstOrDefault(ord => ord.SLocation.Contains(p_item));
        }
        public Orders UpdateOrderStoreInfo(Orders p_update, int sID, string sAddress)
        {
            p_update.StoreId = sID;
            p_update.SLocation = sAddress;
            return _repo.UpdateOrder(p_update);
        }

        public Orders UpdateOrderTotal(Orders p_update, int p_quan, int p_price)
        {
            int newTotal = p_update.TotalPrice;
            newTotal = p_price*p_quan;
            p_update.TotalPrice = newTotal;
            return _repo.UpdateOrder(p_update);
        }
    }
}