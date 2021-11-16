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
    public class CustomerController : Controller
    {
        private ICustomersBL _custBL;
        public CustomerController(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_custBL.GetAllCustomers()
                        .Select(cust => new CustomerVM(cust))
                        .ToList()
            );
        }
        public ActionResult Index1()
        {
            return View(_custBL.GetAllCustomers()
                        .Select(cust => new CustomerVM(cust))
                        .ToList()
            );
        }
        [HttpPost]
        public ActionResult Index2(IFormCollection form)
        {
            return View(_custBL.GetCustomers(form["p_name"])
                        .Select(cust => new CustomerVM(cust))
                        .ToList()
            );
        }
        public ActionResult Select(int p_id)
        {
            Customers toBeSelected = _custBL.GetCustomersById(p_id);
            return View(new CustomerVM(toBeSelected));
        }

        public IActionResult CustomerOrder()
        {
            return View(_custBL.GetAllCustomers()
                        .Select(cust => new CustomerVM(cust))
                        .ToList()
            );
        }

        //[HttpGet] -- don't have to specify since it is the default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerVM custVM)
        {
            if (ModelState.IsValid)
            {
                _custBL.AddCustomer(new Customers()
                {
                    Name = custVM.Name,
                    Address = custVM.Address,
                    Email = custVM.Email,
                    PhoneNumber = custVM.PhoneNumber
                });

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5 --- Will delete a customer
        public ActionResult Delete(int p_id)
        {
            return View(new CustomerVM(_custBL.GetCustomersById(p_id)));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection collection)
        {
            try
            {
                Customers toBeDeleted = _custBL.GetCustomersById(Id);
                _custBL.DeleteCustomer(toBeDeleted);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
