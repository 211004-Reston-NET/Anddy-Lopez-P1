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

        public void Menu()
        {
            Console.WriteLine("List of Store Fronts");
            List<StoreFronts> listOfStoreFronts = _storefBL.GetAllStoreFronts();

            foreach (StoreFronts sf in listOfStoreFronts)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(sf);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("[a] - Search for Store Front");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Enter a name for the Store Front you want to find");
                    _findStoreName = Console.ReadLine();
                    return MenuType.ShowStoreFronts;
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