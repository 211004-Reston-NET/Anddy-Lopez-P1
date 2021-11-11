using Microsoft.AspNetCore.Mvc;
using P0BL;
using P0Models;
using P0WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P0WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrdersBL _ordBL;
        public OrderController(IOrdersBL p_ordBL)
        {
            _ordBL = p_ordBL;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderVM ordVM)
        {
            if (ModelState.IsValid)
            {
                _ordBL.AddOrder(new Orders()
                {
                    SLocation = ordVM.SLocation,
                    TotalPrice = ordVM.TotalPrice,
                    CustId = ordVM.CustId,
                    StoreId = ordVM.StoreId
                });

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
