using System.Collections.Generic;
using P0DL;
using P0Models;

namespace P0BL
{
    public class InventoryBL : IInventoryBL
    {
        //Dependency Injection
        private IRepository _repo;
        public InventoryBL(IRepository p_repo) 
        {
            _repo = p_repo;
        }
        
        public List<LineItems> GetAllLineItems()
        {
            throw new System.NotImplementedException();
        }

        public List<LineItems> GetLineItems(string p_item)
        {
            throw new System.NotImplementedException();
        }
    }
}