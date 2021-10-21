using System;

namespace P0UI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("You must select a customer then store to place an order");
            Console.WriteLine("[a] - Add a new customer");
            Console.WriteLine("[b] - See exisiting customers");
            Console.WriteLine("[c] - See all store fronts");
            Console.WriteLine("[x] - Exit");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    return MenuType.AddCustomer;
                case "b":
                    return MenuType.ShowCustomers;
                case "c":
                    return MenuType.ShowStoreFronts;
                case "x":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}