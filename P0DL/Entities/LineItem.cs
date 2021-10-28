using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class LineItem
    {
        public int LiId { get; set; }
        public string LiProduct { get; set; }
        public int? LiQuantity { get; set; }
        public int? OrderId { get; set; }
        public int? InvId { get; set; }

        public virtual Inventory Inv { get; set; }
        public virtual MyOrder Order { get; set; }
    }
}
