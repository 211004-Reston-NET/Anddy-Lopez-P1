using System.Collections.Generic;

namespace P0Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }

        public StoreFronts StoreFronts { get; set; }
        public List<LineItems> LineItems { get; set; }
        public List<Products> Products { get; set; }
    }
}