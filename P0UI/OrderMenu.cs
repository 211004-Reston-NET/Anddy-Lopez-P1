using System;
using System.Collections.Generic;
using System.Linq;
using P0BL;
using P0Models;

namespace P0UI
{
    public class OrderMenu : IMenu
    {
        private ICustomersBL _custBL;
        public OrderMenu(ICustomersBL p_custBL)
        {
            this._custBL = p_custBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Customers");
            List<Orders> listOfOrders = _custBL.GetAllOrders(ShowCustomers._findCust);

            foreach (Orders ord in listOfOrders)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(ord);
                Console.WriteLine("--------------------");
            }
            if (listOfOrders.Any() == false)
            {
                Console.WriteLine("\nNo orders to report. Please choose another store.\n");
                Console.WriteLine("[a] - Try again");
            }
            else
            {
                Console.WriteLine("[x] - Exit");
            }
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
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