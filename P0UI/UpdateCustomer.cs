using System;
using P0BL;
using P0Models;

namespace P0UI 
{
    public class UpdateCustomer : IMenu
    {
        private static Customers _cust = new Customers();
        private ICustomersBL _custBL;
        public UpdateCustomer(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }
        


        public void Menu()
        {
            Customers selectedCust = _custBL.UpdateCustomer(ShowCustomers._findCust);
            Console.WriteLine("Welcome to Update!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Name - "+ selectedCust.Name);
            Console.WriteLine("Address - "+ selectedCust.Address);
            Console.WriteLine("Email - "+ selectedCust.Email);
            Console.WriteLine("Phone Number - "+ selectedCust.PhoneNumber);
            Console.WriteLine("[a] - Update customer name");
            Console.WriteLine("[b] - Update customer address");
            Console.WriteLine("[c] - Update customer email");
            Console.WriteLine("[d] - Update customer phone number");
            Console.WriteLine("[e] - Update Customer");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Type in new value for Name");
                    _cust.Name = Console.ReadLine();
                    return MenuType.UpdateCustomer;
                case "b":
                    Console.WriteLine("Type in new value for Address");
                    _cust.Address = Console.ReadLine();
                    return MenuType.UpdateCustomer;
                case "c":
                    Console.WriteLine("Type in new value for Email");
                    _cust.Email = Console.ReadLine();
                    return MenuType.UpdateCustomer;
                case "d":
                    Console.WriteLine("Type in new value for Phone Number");
                    _cust.PhoneNumber = Console.ReadLine();
                    return MenuType.UpdateCustomer;
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
                        return MenuType.UpdateCustomer;
                    }
                    return MenuType.MainMenu;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.UpdateCustomer;
            }
        }
    }
}