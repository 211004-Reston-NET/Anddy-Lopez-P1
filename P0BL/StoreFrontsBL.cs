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

        //Returns Stores with no changes
        public List<StoreFronts> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        //Searches stores by name
        public List<StoreFronts> GetStoreFronts(string p_sname)
        {
            List<StoreFronts> listOfStoreFronts = _repo.GetAllStoreFronts();

            return listOfStoreFronts.Where(storef => storef.SName.Contains(p_sname)).ToList();
        }
    }
}