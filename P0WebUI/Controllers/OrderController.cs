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
        private ILineItemBL _itemBL;
        public OrderController(IOrdersBL p_ordBL, ICustomersBL p_custBL, IStoreFrontsBL p_storeBL, ILineItemBL p_itemBL)
        {
            _ordBL = p_ordBL;
            _custBL = p_custBL;
            _storeBL = p_storeBL;
            _itemBL = p_itemBL;
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
                    StoreId = 1
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
        public ActionResult Edit2(int Id, int Quantity, IFormCollection form)
        {
            LineItems itemFound = _itemBL.GetItemsByID(Id);
            _itemBL.UpdateItemQuantity(itemFound, Quantity);
            Orders toBeUpdated = _ordBL.GetNewestOrder();
            int p_price = Convert.ToInt32(form["Price"].ToString()); //This doesn't work!!!
            _ordBL.UpdateOrderTotal(toBeUpdated, Quantity, p_price); 
            return RedirectToAction("Index", "Product");
        }
    }
}
