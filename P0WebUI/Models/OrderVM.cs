using P0Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        {

        }
        public OrderVM(Orders p_ord)
        {
            this.Id = p_ord.Id;
            this.SLocation = p_ord.SLocation;
            this.TotalPrice = p_ord.TotalPrice;
            this.CustId = p_ord.CustId;
            this.StoreId = p_ord.StoreId;
        }
        public int Id { get; set; }
        public string SLocation { get; set; }
        public int TotalPrice { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
    }
}
