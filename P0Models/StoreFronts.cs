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
        public string SName { get; set; }
        public string SAddress { get; set; }
        List<Products> listOfProducts = new List<Products>();
        List<Orders> listOfStoreOrders = new List<Orders>();

        public override string ToString()
        {
            return $"Store name: {SName}\nAddress: {SAddress}";
        }
    }
}