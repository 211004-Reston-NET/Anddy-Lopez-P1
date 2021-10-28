using System.Collections.Generic;
using System.Linq;
using P0DL;
using P0Models;

namespace P0BL  
{
    public class LineItemBL : ILineItemBL
    {
        private IRepository _repo;
        public LineItemBL(IRepository p_repo) 
        {
            _repo = p_repo;
        }
        
        public List<LineItems> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

        public List<LineItems> GetLineItems(string p_prod)
        {
            List<LineItems> listOfLineItems = _repo.GetAllLineItems();

            return listOfLineItems.Where(item => item.Product.Contains(p_prod)).ToList();
        }
    }
}