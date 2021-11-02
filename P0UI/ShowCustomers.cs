using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class ShowCustomers : IMenu
    {
        // dotnet add reference ..\P0BL\P0BL.csproj ------ Do 2nd
        private ICustomersBL _custBL;
        public ShowCustomers(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }
        public static Customers _findCust = new Customers();
        public static int _searchOption;
        
        public void Menu()
        {
            Console.WriteLine("List of Customers");
            // make sure you are in P0UI directory
            // cd .. ---> cd .\P0UI\ ---> dotnet add reference ..\P0Models\P0Models.csproj ------ Do 1st
            List<Customers> listOfCustomers = _custBL.GetAllCustomers();

            foreach (Customers c in listOfCustomers)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(c);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("[a] - Select and search for Customer by name (Case Sensitive)"); //Must be done first for whatever reason
            Console.WriteLine("[b] - Select and search for Customer by address (Case Sensitive)");
            Console.WriteLine("[c] - Select and search for Customer by email (Case Sensitive)");
            Console.WriteLine("[d] - Select and search for Customer by phone number (Case Sensitive)");
            Console.WriteLine("[e] - Select and search for Customer Order History");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    _searchOption = 1;
                    Console.WriteLine("Enter a name for the Customer you want to find");
                    _findCust.Name = Console.ReadLine();
                    return MenuType.CurrentCustomer;
                case "b":
                    _searchOption = 2;
                    Console.WriteLine("Enter an address for the Customer you want to find");
                    _findCust.Address = Console.ReadLine();
                    return MenuType.CurrentCustomer;
                case "c":
                    _searchOption = 3;
                    Console.WriteLine("Enter an email for the Customer you want to find");
                    _findCust.Email = Console.ReadLine();
                    return MenuType.CurrentCustomer;
                case "d":
                    _searchOption = 4;
                    Console.WriteLine("Enter a phone number for the Customer you want to find");
                    _findCust.PhoneNumber = Console.ReadLine();
                    return MenuType.CurrentCustomer;
                case "e":
                    Console.WriteLine("Enter Customer ID:");
                    try
                    {
                         _findCust.Id = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please put in a number");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowCustomers;
                    }
                    return MenuType.OrderMenu;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowCustomers;
            }
        }
    }
}