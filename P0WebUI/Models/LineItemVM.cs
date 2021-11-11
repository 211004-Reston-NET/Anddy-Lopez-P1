using P0Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM()
        {

        }
        public LineItemVM(LineItems p_item)
        {
            this.Id = p_item.Id;
            this.Product = p_item.Product;
            this.Quantity = p_item.Quantity;
            this.OrderId = p_item.OrderId;
        }
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }
    }
}
