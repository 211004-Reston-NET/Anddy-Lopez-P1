using System;
using P0BL;
using P0DL;

// Comment for quick change 1,2,3

namespace P0UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            IFactory factory = new MenuFactory();

            IMenu page = factory.GetMenu(MenuType.MainMenu);

            while (repeat)
            {
                Console.Clear();
                
                page.Menu();
                MenuType currentPage =  page.YourChoice();

                if (currentPage == MenuType.Exit)
                {
                    Console.WriteLine("You are exiting the app!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        repeat = false;
                }
                else
                {
                    page = factory.GetMenu(currentPage);
                }
            }
        }
    }
}
