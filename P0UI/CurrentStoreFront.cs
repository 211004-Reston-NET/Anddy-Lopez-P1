using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class CurrentStoreFront : IMenu
    {
        private IStoreFrontsBL _storefBL;
        public CurrentStoreFront(IStoreFrontsBL p_storefBL)
        {
            this._storefBL = p_storefBL;
        }

        public void Menu()
        {
            List<StoreFronts> listOfStoreF = _storefBL.GetStoreFronts(ShowStoreFronts._findStoreName);

            Console.WriteLine("This is the search result");
            foreach (StoreFronts sf in listOfStoreF)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(sf);
                Console.WriteLine("--------------");
            }
            Console.WriteLine("[a] - Select this Store to place your order");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "a":
                    // My lines aren't appearing :/
                    Console.WriteLine("You have now chosen a shopping center"); //Perhaps show which Store Front
                    Console.WriteLine("Select the products you wish to buy:");
                    return MenuType.PlaceOrder;
                case "x":
                    return MenuType.ShowStoreFronts;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CurrentStoreFront;
            }
        }
    }
}