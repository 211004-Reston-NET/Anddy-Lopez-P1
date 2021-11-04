using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/* Will Hold:
Product
Quantity
*/

namespace P0Models
{
    public class LineItems
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }

        public Orders Orders { get; set; }
        public List<Products> Products { get; set; } 

        public override string ToString()
        {
            return $"Product ID: {Id}\nProduct: {Product}\nQuantity: {Quantity}";
        }
    }
}