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
    public class StoreFrontController : Controller
    {
        private IStoreFrontsBL _storeBL;
        public StoreFrontController(IStoreFrontsBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        
        // GET: StoreFrontController
        public ActionResult Index()
        {
            return View(_storeBL.GetAllStoreFronts()
                        .Select(store => new StoreFrontVM(store))
                        .ToList()
            );
        }

        public ActionResult Index1()
        {
            return View(_storeBL.GetAllStoreFronts()
                        .Select(store => new StoreFrontVM(store))
                        .ToList()
            );
            
        }
        public ActionResult Select(int p_id)
        {
            StoreFronts toBeSelected = _storeBL.GetStoresById(p_id);
            return View(new StoreFrontVM(toBeSelected));
        }
        public IActionResult StoreOrder()
        {
            return View(_storeBL.GetAllStoreFronts()
                        .Select(store => new StoreFrontVM(store))
                        .ToList()
            );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StoreFrontVM storeVM)
        {
            if (ModelState.IsValid)
            {
                _storeBL.AddStore(new StoreFronts()
                {
                    SName = storeVM.SName,
                    SAddress = storeVM.SAddress
                });

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: StoreFrontController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreFrontController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreFrontController/Edit/5
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

        // GET: StoreFrontController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreFrontController/Delete/5
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
