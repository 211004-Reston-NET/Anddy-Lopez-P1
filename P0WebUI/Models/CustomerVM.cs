using P0Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        {

        }
        public CustomerVM(Customers p_cust)
        {
            this.Id = p_cust.Id;
            this.Name = p_cust.Name;
            this.Address = p_cust.Address;
            this.Email = p_cust.Email;
            this.PhoneNumber = p_cust.PhoneNumber;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
