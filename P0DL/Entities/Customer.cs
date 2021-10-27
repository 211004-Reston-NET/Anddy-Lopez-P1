using System;
using System.Collections.Generic;

#nullable disable

namespace P0DL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            MyOrders = new HashSet<MyOrder>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustAddres { get; set; }
        public string CustEmail { get; set; }
        public int? CustPhonenumber { get; set; }

        public virtual ICollection<MyOrder> MyOrders { get; set; }
    }
}
