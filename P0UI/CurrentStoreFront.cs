using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("The following are the search results:");
            foreach (StoreFronts sf in listOfStoreF)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(sf);
                Console.WriteLine("--------------");
            }
            //checks to see if any store is found
            if (listOfStoreF.Any() == false)
            {
                Console.WriteLine("\nStore not found. Please try again.\n");
                Console.WriteLine("[x] - Try again");
            }
            else if (listOfStoreF.Count == 1)
            {
                if (CurrentCustomer._userSelected == 1)
                {
                    Console.WriteLine("[a] - Select this Store to place your order");
                    Console.WriteLine("[x] - Exit");
                }
                else
                {
                    Console.WriteLine("[x] - Exit");
                }
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
                    Console.WriteLine("You have now chosen a shopping center"); //Perhaps show which Store Front
                    Console.WriteLine("Press Enter to proceed to select the products you wish to buy");
                    Console.ReadLine();
                    return MenuType.ShowProducts;
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