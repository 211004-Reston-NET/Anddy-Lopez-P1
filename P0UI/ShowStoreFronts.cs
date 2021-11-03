using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class ShowStoreFronts : IMenu
    {
        private IStoreFrontsBL _storefBL;
        public static string _findStoreName;
        public ShowStoreFronts(IStoreFrontsBL p_storefBL)
        {
            _storefBL = p_storefBL;
        }
        public static StoreFronts _findStore = new StoreFronts();

        public void Menu()
        {
            Console.WriteLine("List of Store Fronts");
            Console.WriteLine("");
            List<StoreFronts> listOfStoreFronts = _storefBL.GetAllStoreFronts();

            foreach (StoreFronts sf in listOfStoreFronts)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(sf);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("");
            Console.WriteLine("[a] - Search for specific Store Front");
            Console.WriteLine("[b] - Search for Store Order History");
            Console.WriteLine("[x] - Exit");
            Console.WriteLine("");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Enter a name for the Store Front you want to find");
                    _findStoreName = Console.ReadLine();
                    return MenuType.CurrentStoreFront;
                case "b":
                    if (CurrentCustomer._userSelected != 0)
                    {
                        Console.WriteLine("Enter Store Front ID:");
                        try
                        {
                                _findStore.Id = Int32.Parse(Console.ReadLine());
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Please put in a number");
                            Console.WriteLine("Press Enter to continue");
                            Console.ReadLine();
                            return MenuType.ShowStoreFronts;
                        }
                        return MenuType.StoreOrderMenu;
                    }
                    else
                    {
                        Console.WriteLine("You must be signed in as a Customer to Search Store Order History");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowStoreFronts;
                    } 
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowStoreFronts;
            }
        }
    }
}