using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P0BL;
using P0Models;
using P0WebUI.Models;
using Serilog;
using Serilog.Formatting.Json;
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
        
        public IActionResult Index(int p_id, int p_price)
        {
            ViewData.Add("Price", p_price);
            return View(new LineItemVM(_itemBL.GetItemsByID(p_id)));
        }
        public ActionResult EveryIndex()
        {
            return View(_itemBL.GetEveryItem()
                        .Select(item => new LineItemVM(item))
                        .ToList()
            );
        }
        public ActionResult Restock(int p_id)
        {
            return View(new LineItemVM(_itemBL.GetItemsByID(p_id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Restock(int Id, int Quantity, IFormCollection collection)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(new JsonFormatter(), "Logs/LineItemLogs.json")
                .CreateLogger();
            try
            {
                Log.Information("Restocking a Line Item by ID");
                LineItems toBeUpdated = _itemBL.GetItemsByID(Id);
                _itemBL.UpdateLineItem(Id, Quantity);
                return RedirectToAction(nameof(EveryIndex));
            }
            catch
            {
                Log.Information("Could not restock item");
                return View();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
