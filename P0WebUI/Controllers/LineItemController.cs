using Microsoft.AspNetCore.Mvc;
using P0BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Controllers
{
    public class LineItemController : Controller
    {
        private ILineItemBL _itemBL;
        public LineItemController(ILineItemBL p_itemBL)
        {
            _itemBL = p_itemBL;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
