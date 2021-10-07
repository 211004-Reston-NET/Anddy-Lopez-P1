using System;

namespace P0UI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("[a] - Add a new customer");
            Console.WriteLine("[b] - Search for an exisiting customer");
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
                    return MenuType.FindCustomer;
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