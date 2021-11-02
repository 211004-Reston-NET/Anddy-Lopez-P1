namespace P0UI
{
    public enum MenuType
    {
        MainMenu,
        AddCustomer,
        ShowCustomers,
        CurrentCustomer,
        ShowStoreFronts,
        CurrentStoreFront,
        ShowProducts,
        CurrentProduct,
        PlaceOrder,
        OrderMenu,
        StoreOrderMenu,
        StoreInventory,
        ReplenishInventory,
        ItemMenu,
        UpdateCustomer,
        AddOrder,
        Exit
    }

    public interface IMenu
    {
        void Menu();


        MenuType YourChoice();
    }
}