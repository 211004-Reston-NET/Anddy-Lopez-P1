using System;
using System.Text.RegularExpressions;

/* Will Hold:
Product
Quantity
*/

namespace P0Models
{
    public class LineItems
    {
        public string Product { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Product: {Product}\nQuantity: {Quantity}";
        }
    }
}