using System;
using P0BL;
using P0Models;

namespace P0UI 
{
    public class AddCustomer : IMenu
    {
        private static Customers _cust = new Customers();
        private ICustomersBL _custBL;
        public AddCustomer(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }
        
        public void Menu()
        {
            Console.WriteLine("Welcome to Customer Addition!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Name - "+ _cust.Name);
            Console.WriteLine("Address - "+ _cust.Address);
            Console.WriteLine("Email - "+ _cust.Email);
            Console.WriteLine("Phone Number - "+ _cust.PhoneNumber);
            Console.WriteLine("[a] - Add customer name");
            Console.WriteLine("[b] - Add customer address");
            Console.WriteLine("[c] - Add customer email");
            Console.WriteLine("[d] - Add customer phone number");
            Console.WriteLine("[e] - Add Customer");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Type in value for Name");
                    _cust.Name = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "b":
                    Console.WriteLine("Type in value for Address");
                    _cust.Address = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "c":
                    Console.WriteLine("Type in value for Email");
                    _cust.Email = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "d":
                    Console.WriteLine("Type in value for Phone Number");
                    _cust.PhoneNumber = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "e":
                    try
                    {
                        _custBL.AddCustomer(_cust);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please input a value in all fields!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
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