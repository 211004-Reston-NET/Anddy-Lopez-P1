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
        public static string _findCustName;
        public static string _findCustAddress;
        public static string _findCustEmail;
        public static string _findCustPhone;
        public static int _findID;
        
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
            Console.WriteLine("[a] - Search for Customer by name (Case Sensitive)");
            Console.WriteLine("[b] - Search for Customer by address (Case Sensitive)");
            Console.WriteLine("[c] - Search for Customer by email (Case Sensitive)");
            Console.WriteLine("[d] - Search for Customer by phone number (Case Sensitive)");
            Console.WriteLine("[e] - Search for Customer Order History");
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
                    _findCustAddress = null;
                    _findCustEmail = null;
                    _findCustPhone = null;
                    _findID = 0;
                    return MenuType.CurrentCustomer;
                case "b":
                    Console.WriteLine("Enter an address for the Customer you want to find");
                    _findCustAddress = Console.ReadLine();
                    _findCustName = null;
                    _findCustEmail = null;
                    _findCustPhone = null;
                    _findID = 0;
                    return MenuType.CurrentCustomer;
                case "c":
                    Console.WriteLine("Enter an email for the Customer you want to find");
                    _findCustEmail = Console.ReadLine();
                    _findCustAddress = null;
                    _findCustName = null;
                    _findCustPhone = null;
                    _findID = 0;
                    return MenuType.CurrentCustomer;
                case "d":
                    Console.WriteLine("Enter a phone number for the Customer you want to find");
                    _findCustPhone = Console.ReadLine();
                    _findCustAddress = null;
                    _findCustEmail = null;
                    _findCustName = null;
                    _findID = 0;
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
                    _findCustName = null;
                    _findCustAddress = null;
                    _findCustEmail = null;
                    _findCustPhone = null;
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