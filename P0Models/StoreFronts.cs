using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        
        public List<Orders> Orders { get; set; }
        public List<Inventory> Inventory { get; set; }

        public override string ToString()
        {
            return $"Store name: {SName}\nAddress: {SAddress}";
        }
    }
}