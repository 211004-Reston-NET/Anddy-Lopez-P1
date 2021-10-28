using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class MyOrder
    {
        public MyOrder()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public string OrderAddress { get; set; }
        public int? OrderPrice { get; set; }
        public int? CustId { get; set; }
        public int? StoreId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual StoreFront Store { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
