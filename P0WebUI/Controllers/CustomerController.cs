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
            //We got our list of customers from our business layer
            //We converted that Model customer into CustomerVM using Select method
            //Finally we changed it to a List with ToList()
            return View(_custBL.GetAllCustomers()
                        .Select(cust => new CustomerVM(cust))
                        .ToList()
            );
        }

        //[HttpGet] - don't have to specify since it is the default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerVM custVM)
        {
            //This if statement checks if the current model that is being passed is valid
            //If not, the asp-validation-for attribute elements will appear and autofill in the proper feedback for the user
            //to correct themselves
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

            //Will return back to the creat view if user didn't specify the right input
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
