/* Will Hold:
List of Line Items
Store Front's Location (that the order was placed)
Total Price
*/

using System.Collections.Generic;

namespace P0Models
{
    public class Orders
    {
        List<LineItems> listOfLineItems = new List<LineItems>();
        public string SLocation { get; set; }
        public int TotalPrice { get; set; }

        
        
        public override string ToString()
        {
            return $"Total Price: {TotalPrice}";
        }
    }
}