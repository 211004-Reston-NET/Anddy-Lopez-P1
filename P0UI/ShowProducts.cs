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
        public static LineItems _findProd = new LineItems();
        public ShowProducts(IProductsBL p_prodBL)
        {
            _prodBL = p_prodBL;
        }

        public void Menu()
        {
            Console.WriteLine("List of Products and their price");
            List<Products> listOfProds = _prodBL.GetAllProducts();

            foreach (Products prod in listOfProds)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(prod);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("[a] - Search for specific Product");
            Console.WriteLine("[b] - Search for Product and refill inventory");
            Console.WriteLine("[c] - Search for Product and add to order");
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
                case "b":
                    Console.WriteLine("Enter a Product ID:");
                    try
                    {
                         _findProd.Id = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please put in a number");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowProducts;
                    }
                    return MenuType.ItemMenu;
                case "c":
                    Console.WriteLine("Enter a Product ID:");
                    try
                    {
                         _findProd.Id = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please put in a number");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowProducts;
                    }
                    Console.WriteLine("Enter the Product name");
                    _findProdName = Console.ReadLine();
                    return MenuType.AddOrder;
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