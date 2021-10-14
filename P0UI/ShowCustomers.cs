using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class ShowCustomers : IMenu
    {
        // dotnet add reference ..\P0BL\P0BL.csproj 
        private ICustomersBL _custBL;
        public ShowCustomers(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }

        public void Menu()
        {
            Console.WriteLine("List of Customers");
            // make sure you are in P0UI directory
            // cd .. ---> cd .\P0UI\ ---> dotnet add reference ..\P0Models\P0Models.csproj
            List<Customers> listOfCustomers = _custBL.GetAllCustomers();

            foreach (Customers c in listOfCustomers)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(c);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
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