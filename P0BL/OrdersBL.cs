using System;
using System.Collections.Generic;
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

        //Returns orders with no changes
        public List<Orders> GetAllOrders()
        {
            //return _repo.GetAllOrders();
            throw new System.NotImplementedException();
        }

        //List out the orders
        public List<Orders> GetOrders(string p_item)
        {
            throw new System.NotImplementedException();
        }
    }
}