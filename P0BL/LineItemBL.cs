using System;
using System.Collections.Generic;
using System.Linq;
using P0DL;
using P0Models;

namespace P0BL  
{
    public class LineItemBL : ILineItemBL
    {
        //Dependency Injection
        private IRepository _repo;
        public LineItemBL(IRepository p_repo) 
        {
            _repo = p_repo;
        }

        //allows line item modification - not even close
        public LineItems UpdateLineItem(LineItems p_item)
        {
            if (p_item.Quantity== 0)
            {
                // Will only be seen by coder
                throw new Exception("Must have value in designated properties");
            }
            return _repo.UpdateLineItem(p_item);
        }


        public LineItems GetItemsByID(int p_itemId)
        {
            LineItems itemFound = _repo.GetItemsById(p_itemId);
            if (itemFound == null)
            {
                throw new Exception("Item not found!");
            }
            return itemFound;
        }

        public List<LineItems> GetAllLineItems(LineItems p_item)
        {
            return _repo.GetAllLineItems(p_item);
        }

        public List<LineItems> GetLineItems(string p_item)
        {
            throw new NotImplementedException();
        }
    }
}