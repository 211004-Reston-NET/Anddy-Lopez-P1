using System;
using System.Text.RegularExpressions;

/* Will Hold:
Name
Price
Description (OPTIONAL)
Category (OPTIONAL)
*/

namespace P0Models
{
    public class Products
    {
        public string PName { get; set; }
        public double Price { get; set; }

        //Optional
        //public string Description { get; set; }
        //public string category { get; set; }

        public override string ToString()
        {
            return $"Product name: {PName}\nPrice: {Price}";
        }
    }
}