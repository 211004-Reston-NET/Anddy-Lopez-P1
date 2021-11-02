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
        void ILineItemBL.UpdateLineItem(int p_itemID, int p_quan)
        {
            _repo.UpdateLineItem(p_itemID, p_quan);
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