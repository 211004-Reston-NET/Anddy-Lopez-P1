using P0Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Models
{
    public class ProductVM
    {
        public ProductVM()
        {

        }
        public ProductVM(Products p_prod)
        {
            this.Id = p_prod.Id;
            this.PName = p_prod.PName;
            this.Price = p_prod.Price;
            this.InvId = p_prod.InvId;
            this.LiId = p_prod.InvId;
        }
        public int Id { get; set; }
        public string PName { get; set; }
        public int Price { get; set; }
        public int InvId { get; set; }
        public int LiId { get; set; }
    }
}
