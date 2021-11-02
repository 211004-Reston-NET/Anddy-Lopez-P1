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
        public int Id { get; set; }
        public string SLocation { get; set; }
        public int TotalPrice { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }

        public Customers Customers { get; set; }
        public StoreFronts StoreFronts { get; set; }
        public List<LineItems> LineItems { get; set; }
        
        public override string ToString()
        {
            return $"Order ID: {Id}\nLocation: {SLocation}\nTotal Price: {TotalPrice}";
        }
    }
}