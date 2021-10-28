using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            Products = new HashSet<Product>();
        }

        public int InvId { get; set; }
        public string InvProduct { get; set; }
        public int InvQuantity { get; set; }
        public int StoreId { get; set; }

        public virtual StoreFront Store { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
