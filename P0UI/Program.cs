﻿using System;

// Comment for quick change

namespace P0UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            IMenu page = new MainMenu();

            while (repeat)
            {
                Console.Clear();
                
                page.Menu();
                MenuType currentPage =  page.YourChoice();


                switch (currentPage)
                {
                    case MenuType.MainMenu:
                        page = new MainMenu();
                        break;
                    case MenuType.AddCustomer:
                        page = new AddCustomer();
                        break;
                    case MenuType.Exit:
                        Console.WriteLine("You are exiting the app!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Coding in progress. Please return later");
                        repeat = false;
                        break;
                }
            }
        }
    }
}
