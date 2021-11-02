using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class AddOrder : IMenu
    {
        private static LineItems _ord = new LineItems();
        private IOrdersBL _ordBL;
        public static int _newQuan;
        public AddOrder(IOrdersBL p_ordBL)
        {
            _ordBL = p_ordBL;
        }
        
        public void Menu()
        {
            Console.WriteLine("Welcome to the Shopping Center!");
            Console.WriteLine("To place an order, type in what you need");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Product ID - "+ _ord.Id);
            Console.WriteLine("Quantity - "+ _ord.Quantity);
            Console.WriteLine("[a] - Add product");
            Console.WriteLine("[b] - Add quantity");
            Console.WriteLine("[c] - Add to Order and return to product list");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Type in value for Product ID");
                    _ord.Id = Int32.Parse(Console.ReadLine());
                    return MenuType.AddOrder;
                case "b":
                    Console.WriteLine("Type in value for Quantity");
                    _ord.Quantity = Int32.Parse(Console.ReadLine());
                    return MenuType.AddOrder;
                case "c":
                    //_ordBL.AddOrder(_ord); //Won't work since can't convert item to order
                    _newQuan = _ord.Quantity; 
                    return MenuType.ShowProducts;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddOrder;
            }
        }
    }
}