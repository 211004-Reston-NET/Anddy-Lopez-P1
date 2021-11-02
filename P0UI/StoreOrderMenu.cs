using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class StoreOrderMenu : IMenu
    {
        private IStoreFrontsBL _storefBL;
        public StoreOrderMenu(IStoreFrontsBL p_storefBL)
        {
            this._storefBL = p_storefBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Stores");
            List<Orders> listOfOrders = _storefBL.GetAllStoreOrders(ShowStoreFronts._findStore);

            foreach (Orders ord in listOfOrders)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(ord);
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