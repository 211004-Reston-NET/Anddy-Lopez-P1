using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class CurrentCustomer : IMenu
    {
        private ICustomersBL _custBL;
        public CurrentCustomer(ICustomersBL p_custBL)
        {
            this._custBL = p_custBL;
        }

        public void Menu()
        {
            List<Customers> listOfCust = _custBL.GetCustomers(ShowCustomers._findCustName);

            Console.WriteLine("The following are the search result(s)");
            foreach (Customers cust in listOfCust)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(cust);
                Console.WriteLine("--------------");
            }
            Console.WriteLine("[x] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "x":
                    return MenuType.ShowCustomers;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CurrentCustomer;
            }
        }
    }
}