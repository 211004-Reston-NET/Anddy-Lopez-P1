using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class CurrentProduct : IMenu
    {
        private IProductsBL _prodBL;
        public CurrentProduct(IProductsBL p_prodBL)
        {
            this._prodBL = p_prodBL;
        }
        
        public void Menu()
        {
            List<Products> listOfProds = _prodBL.GetProducts(ShowProducts._findProdName);

            Console.WriteLine("This is the search result");
            foreach (Products prod in listOfProds)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(prod);
                Console.WriteLine("--------------");
            }
            Console.WriteLine("[a] - Select this product to add to your order");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "a":
                    return MenuType.CurrentProduct;
                case "x":
                    return MenuType.ShowProducts;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CurrentStoreFront;
            }
        }
    }
}