using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class ShowProducts : IMenu
    {
        private IProductsBL _prodBL;
        public static string _findProdName;
        public ShowProducts(IProductsBL p_prodBL)
        {
            _prodBL = p_prodBL;
        }

        public void Menu()
        {
            Console.WriteLine("List of Products");
            List<Products> listOfProds = _prodBL.GetAllProducts();

            foreach (Products prod in listOfProds)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(prod);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("[a] - Search for specific Product");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Enter a name for the Product you want to find");
                    _findProdName = Console.ReadLine();
                    return MenuType.CurrentProduct;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowProducts;
            }
        }
    }
}