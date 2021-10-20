using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class PlaceOrder : IMenu
    {
        private IProductsBL _prodBL;
        // public static string _findProdName; - will use if I want to search products
        public PlaceOrder(IProductsBL p_prodBL)
        {
            _prodBL = p_prodBL;
        }

        public void Menu()
        {
            Console.WriteLine("List of Customers");
            
            List<Products> listOfProducts = _prodBL.GetAllProducts();

            foreach (Products prod in listOfProducts)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(prod);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("[a] - Place an order");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            throw new System.NotImplementedException();
        }
    }
}