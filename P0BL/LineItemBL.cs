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

        //allows line item addition
        public LineItems AddLineItem(LineItems p_item)
        {
            if (p_item.Quantity== 0)
            {
                // Will only be seen by coder
                throw new Exception("Must have value in all properties");
            }
            return _repo.AddLineItem(p_item);
        }

        //Returns Line Items with no changes
        public List<LineItems> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

        //Searches Line Items
        public List<LineItems> GetLineItems(string p_item)
        {
            List<LineItems> listOfLineItems = _repo.GetAllLineItems();

            return listOfLineItems.Where(item => item.Product.Contains(p_item)).ToList();
        }
    }
}