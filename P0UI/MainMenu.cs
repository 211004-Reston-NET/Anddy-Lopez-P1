using System;

namespace P0UI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu of the Store App!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[a] - Add a new customer");
            Console.WriteLine("[b] - See exisiting customers");
            Console.WriteLine("[c] - See all store fronts");
            Console.WriteLine("[d] - Place an order");
            Console.WriteLine("[e] - View Order History");
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
                case "d":
                    Console.WriteLine("You must select a customer first to place an order");
                    Console.WriteLine("Press Enter to continue and select one of the following");
                    Console.ReadLine();
                    return MenuType.ShowCustomers;
                case "e":
                    Console.WriteLine("Search order history through Customer search menu");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowCustomers;
                case "1":
                    return MenuType.CurrentProduct;
                case "g":
                    return MenuType.ReplenishInventory;
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