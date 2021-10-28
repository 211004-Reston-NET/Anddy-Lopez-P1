using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            Inventories = new HashSet<Inventory>();
            MyOrders = new HashSet<MyOrder>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddres { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<MyOrder> MyOrders { get; set; }
    }
}
