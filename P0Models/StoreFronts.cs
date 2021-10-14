using System;
using System.Text.RegularExpressions;

/* Will Hold:
Name
Address
List of Products
List of Orders
*/

namespace P0Models
{
    public class StoreFronts
    {
        public string SName { get; set; }
        public string SAddress { get; set; }
        // IDK how list works for inputs
        // public string ListOfProducts { get; set; }
        // public string ListOfOrders { get; set; }

        public override string ToString()
        {
            return $"Store name: {SName}\nAddress: {SAddress}";
        }
    }
}