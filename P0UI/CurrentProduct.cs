using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("The following are the search results:");
            foreach (Products prod in listOfProds)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(prod);
                Console.WriteLine("--------------");
            }
            //checks to see if any product is found
            if (listOfProds.Any() == false)
            {
                Console.WriteLine("\nProduct not found. Please try again.\n");
                Console.WriteLine("[x] - Try again");
            }
            // else if (listOfProds.Count == 1)
            // {
            //     Console.WriteLine("[a] - Go to add to your order");
            //     Console.WriteLine("[x] - Exit");
            // }
            else
            {
                Console.WriteLine("[x] - Exit");
            }  
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                // case "a":
                //     return MenuType.AddOrder;
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