using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int? ProdPric { get; set; }
        public int? StoreId { get; set; }

        public virtual StoreFront Store { get; set; }
    }
}
