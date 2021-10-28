using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class PlaceOrder : IMenu
    {
        // private IProductsBL _prodBL;
        // public static string _findProdName;
        // public PlaceOrder(IProductsBL p_prodBL)
        // {
        //     _prodBL = p_prodBL;
        // }

        // public void Menu()
        // {
        //     Console.WriteLine("List of Products");

        //     List<Products> listOfProducts = _prodBL.GetAllProducts();

        //     foreach (Products prod in listOfProducts)
        //     {
        //         Console.WriteLine("--------------------");
        //         Console.WriteLine(prod);
        //         Console.WriteLine("--------------------");
        //     }
        //     Console.WriteLine("[a] - Search Products by name");
        //     Console.WriteLine("[x] - Exit");
        // }

        // public MenuType YourChoice()
        // {
        //     string userChoice = Console.ReadLine();

        //     switch (userChoice)
        //     {
        //         case "a":
        //             Console.WriteLine("Enter a name for the Customer you want to find");
        //             _findProdName = Console.ReadLine();
        //             return MenuType.PlaceOrder;
        //         case "x":
        //             return MenuType.ShowStoreFronts;
        //         default:
        //             Console.WriteLine("Please input a valid response!");
        //             Console.WriteLine("Press Enter to continue");
        //             Console.ReadLine();
        //             return MenuType.CurrentStoreFront;
        //     }
        // }
        public void Menu()
        {
            throw new NotImplementedException();
        }

        public MenuType YourChoice()
        {
            throw new NotImplementedException();
        }
    }
}