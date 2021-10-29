using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class AddOrder : IMenu
    {
        private static Orders _ord = new Orders();
        private IOrdersBL _ordBL;
        public AddOrder(IOrdersBL p_ordBL)
        {
            _ordBL = p_ordBL;
        }
        
        public void Menu()
        {
            Console.WriteLine("Welcome to the Shopping Center!");
            Console.WriteLine("To place an order, type in what you need");
            Console.WriteLine("What would you like to do?");
            //Console.WriteLine("Product - "+ _cust.Name);
            //Console.WriteLine("Quantity - "+ _cust.Address);
            Console.WriteLine("[a] - Add product name");
            Console.WriteLine("[b] - Add quantity");
            Console.WriteLine("[c] - Add to Order");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Type in value for Product");
                    //_cust.Name = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "b":
                    Console.WriteLine("Type in value for Quantity");
                    //_cust.Address = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "c":
                    try
                    {
                        _ordBL.AddOrder(_ord);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please input a value in all fields!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer; //Fix
                    }
                    return MenuType.MainMenu;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddCustomer;
            }
        }
    }
}