//This file is so that Program.cs no longer has all the creation logic
//So that we can follow Single Responsibility Priniciple
using P0BL;
using P0DL;

namespace P0UI
{
    class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.AddCustomer:
                    return new AddCustomer(new CustomersBL(new Repository()));
                case MenuType.ShowCustomers:
                    // cd .. ---> cd .\P0UI\ ---> dotnet add reference ..\P0DL\P0DL.csproj  
                    return new ShowCustomers(new CustomersBL(new Repository()));
                case MenuType.CurrentCustomer:
                    return new CurrentCustomer(new CustomersBL(new Repository()));
                case MenuType.ShowStoreFronts:
                    return new ShowStoreFronts(new StoreFrontsBL(new Repository()));
                case MenuType.CurrentStoreFront:
                    return new CurrentStoreFront(new StoreFrontsBL(new Repository()));
                default:
                    return null;
            }
        }
    }
}