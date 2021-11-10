using System;
using System.Collections.Generic;
using System.Linq;
using P0DL;
using P0Models;

namespace P0BL
{
    public class StoreFrontsBL : IStoreFrontsBL
    {
        //Dependency Injection
        private IRepository _repo;
        public StoreFrontsBL(IRepository p_repo) 
        {
            _repo = p_repo;
        }

        public StoreFronts AddStore(StoreFronts p_store)
        {
            if (p_store.SName == null || p_store.SAddress == null)
            {
                // Will only be seen by coder
                throw new Exception("Must have value in all properties");
            }
            return _repo.AddStore(p_store);
        }

        //Returns Stores with no changes
        public List<StoreFronts> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        public List<Orders> GetAllStoreOrders(StoreFronts p_store)
        {
            return _repo.GetAllStoreOrders(p_store);
        }

        //Searches stores by name
        public List<StoreFronts> GetStoreFronts(string p_sname)
        {
            List<StoreFronts> listOfStoreFronts = _repo.GetAllStoreFronts();

            return listOfStoreFronts.Where(storef => storef.SName.Contains(p_sname)).ToList();
        }

        
    }
}