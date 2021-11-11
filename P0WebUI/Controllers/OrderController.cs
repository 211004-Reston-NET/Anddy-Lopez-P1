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
        private ICustomersBL _custBL;
        private IStoreFrontsBL _storeBL;
        public OrderController(IOrdersBL p_ordBL, ICustomersBL p_custBL, IStoreFrontsBL p_storeBL)
        {
            _ordBL = p_ordBL;
            _custBL = p_custBL;
            _storeBL = p_storeBL;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerOrder(int p_Id)
        {
            Customers theCustomer = _custBL.GetCustomersById(p_Id);
            return View(_ordBL.GetAllOrders(theCustomer)
                        .Select(ord => new OrderVM(ord))
                        .ToList()
            );
        }
        public IActionResult StoreOrder(int p_Id)
        {
            StoreFronts theStore = _storeBL.GetStoresById(p_Id);
            return View(_ordBL.GetAllStoreOrders(theStore)
                        .Select(ord => new OrderVM(ord))
                        .ToList()
            );
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
