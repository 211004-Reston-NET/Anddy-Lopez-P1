using Microsoft.AspNetCore.Http;
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
        public IActionResult Create(int Id)
        {
            if (ModelState.IsValid)
            {
                _ordBL.AddOrder(new Orders()
                {
                    SLocation = "Place Holder",
                    TotalPrice = 0,
                    CustId = Id,
                    StoreId = 0
                });

                return RedirectToAction("Index1","StoreFront");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1(int Id, string SAddress, IFormCollection collection)
        {
            try
            {
                Orders toBeUpdated = _ordBL.GetOrder("Place Holder");
                _ordBL.UpdateOrderStoreInfo(toBeUpdated, Id, SAddress);
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(int Quantity, int Price, IFormCollection collection)
        {
            try
            {
                Orders toBeUpdated = _ordBL.GetNewestOrder();
                _ordBL.UpdateOrderTotal(toBeUpdated, Quantity, Price);
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
