using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            MyOrders = new HashSet<MyOrder>();
            Products = new HashSet<Product>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddres { get; set; }

        public virtual ICollection<MyOrder> MyOrders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
