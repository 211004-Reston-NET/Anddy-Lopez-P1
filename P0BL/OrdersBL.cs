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
        
        //Returns orders with no changes
        public List<Orders> GetAllOrders()
        {
            //return _repo.GetAllOrders();
            throw new System.NotImplementedException();
        }

        public List<Orders> GetOrders(string p_item)
        {
            throw new System.NotImplementedException();
        }
    }
}