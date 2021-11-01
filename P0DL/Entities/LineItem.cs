using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class LineItem
    {
        public LineItem()
        {
            Products = new HashSet<Product>();
        }

        public int LiId { get; set; }
        public string LiProduct { get; set; }
        public int LiQuantity { get; set; }
        public int? OrderId { get; set; }

        public virtual MyOrder Order { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
