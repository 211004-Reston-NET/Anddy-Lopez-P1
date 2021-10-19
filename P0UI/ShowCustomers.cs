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
        public static string _findCustName;
        public ShowCustomers(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }

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
            Console.WriteLine("[a] - Search for Customer");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Enter a name for the Customer you want to find");
                    _findCustName = Console.ReadLine();
                    return MenuType.CurrentCustomer;
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