using P0Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Models
{
    public class StoreFrontVM
    {
        public StoreFrontVM()
        {

        }

        public StoreFrontVM(StoreFronts p_store)
        {
            this.Id = p_store.Id;
            this.SName = p_store.SName;
            this.SAddress = p_store.SAddress;
        }

        public int Id { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        public string SAddress { get; set; }
    }
}
