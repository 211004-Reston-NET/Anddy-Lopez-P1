using Microsoft.AspNetCore.Mvc;
using P0BL;
using P0WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsBL _prodBL;
        public ProductController(IProductsBL p_prodBL)
        {
            _prodBL = p_prodBL;
        }
        
        public IActionResult Index()
        {
            return View(_prodBL.GetAllProducts()
                        .Select(prod => new ProductVM(prod))
                        .ToList()
            );
        }
    }
}
