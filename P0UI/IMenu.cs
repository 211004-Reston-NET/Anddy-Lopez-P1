namespace P0UI
{
    public enum MenuType
    {
        MainMenu,
        AddCustomer,
        FindCustomer,
        PlaceOrder,
        OrderHistory,
        StoreInventory,
        RefillInventory,
        Exit
    }

    public interface IMenu
    {
        void Menu();


        MenuType YourChoice();
    }
}