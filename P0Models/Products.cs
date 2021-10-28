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
        public int Id { get; set; }
        public string PName { get; set; }
        public double Price { get; set; }
        public int InvId { get; set; }
        public int LiId { get; set; }

        public Inventory Inventory { get; set; }
        public LineItems LineItems { get; set; }

        //Optional
        //public string Description { get; set; }
        //public string category { get; set; }

        public override string ToString()
        {
            return $"Product name: {PName}\nPrice: {Price}";
        }
    }
}