using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int ProdPrice { get; set; }
        public int InvId { get; set; }

        public virtual Inventory Inv { get; set; }
    }
}
