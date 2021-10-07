using System;

namespace P0UI 
{
    public class AddCustomer : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Customer Addition!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[a] - Add customer name");
            Console.WriteLine("[b] - Add customer address");
            Console.WriteLine("[c] - Add customer email");
            Console.WriteLine("[d] - Add customer phone number");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    return MenuType.AddCustomer;
                case "b":
                    return MenuType.AddCustomer;
                case "c":
                    return MenuType.AddCustomer;
                case "d":
                    return MenuType.AddCustomer;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddCustomer;
            }
        }
    }
}