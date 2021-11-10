using P0Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
