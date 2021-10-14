/* Will Hold:
List of Line Items
Store Front's Location (that the order was placed)
Total Price
*/

namespace P0Models
{
    public class Orders
    {
        // public string ListOfLineItems { get; set; }
        // public string SFLocation { get; set; }
        public int TotalPrice { get; set; }

        
        
        public override string ToString()
        {
            return $"Total Price: {TotalPrice}";
        }
    }
}