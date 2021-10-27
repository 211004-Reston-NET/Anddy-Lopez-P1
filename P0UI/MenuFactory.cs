//This file is so that Program.cs no longer has all the creation logic
//So that we can follow Single Responsibility Priniciple
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using P0BL;
using P0DL;
using P0DL.Entities; //comment out for database refresh

namespace P0UI
{
    class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            var configuration = new ConfigurationBuilder()  //Configuration builder is the class that came from the Microsoft.Extensions.Configuration package
                .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the P0UI file path
                .AddJsonFile("appsetting.json") //adds the appsetting.json file in our RRUI
                .Build(); //builds our configuration

            //comment out for database refresh
            DbContextOptions<P0DatabaseContext> options = new DbContextOptionsBuilder<P0DatabaseContext>()
                .UseSqlServer(configuration.GetConnectionString("Reference2DB"))
                .Options;

            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.AddCustomer:
                    return new AddCustomer(new CustomersBL(new RepositoryCloud(new P0DatabaseContext(options))));
                case MenuType.ShowCustomers:
                    // cd .. ---> cd .\P0UI\ ---> dotnet add reference ..\P0DL\P0DL.csproj  
                    return new ShowCustomers(new CustomersBL(new RepositoryCloud(new P0DatabaseContext(options))));
                case MenuType.CurrentCustomer:
                    return new CurrentCustomer(new CustomersBL(new RepositoryCloud(new P0DatabaseContext(options))));
                case MenuType.ShowStoreFronts:
                    return new ShowStoreFronts(new StoreFrontsBL(new RepositoryCloud(new P0DatabaseContext(options))));
                case MenuType.CurrentStoreFront:
                    return new CurrentStoreFront(new StoreFrontsBL(new RepositoryCloud(new P0DatabaseContext(options))));
                case MenuType.PlaceOrder: //work in progress :(
                    return new PlaceOrder(new ProductsBL(new Repository()));
                default:
                    return null;
            }
        }
    }
}