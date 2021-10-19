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
                        page = new AddCustomer(new CustomersBL(new Repository()));
                        break;
                    case MenuType.ShowCustomers:
                        // cd .. ---> cd .\P0UI\ ---> dotnet add reference ..\P0DL\P0DL.csproj  
                        page = new ShowCustomers(new CustomersBL(new Repository()));
                        break;
                    case MenuType.CurrentCustomer:
                        page = new CurrentCustomer(new CustomersBL(new Repository()));
                        break; 
                    case MenuType.ShowStoreFronts:
                        page = new ShowStoreFronts(new StoreFrontsBL(new Repository()));
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
