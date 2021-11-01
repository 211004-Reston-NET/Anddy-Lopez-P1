using System;
using P0BL;
using P0Models;

namespace P0UI
{
    public class ReplenishInventory : IMenu
    {
        private static LineItems _item = new LineItems();
        private ILineItemBL _itemBL;
        public ReplenishInventory(ILineItemBL p_itemBL)
        {
            _itemBL = p_itemBL;
        }
        public static int _addAmount;
        
        public void Menu()
        {
            Console.WriteLine("Welcome to Inventory Replenishor!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Quantity - "+ _item.Quantity);
            Console.WriteLine("[a] - Add quantity amount to current inventory");
            Console.WriteLine("[b] - Set inventory amount");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Type in value for Quantity to add");
                    _addAmount = Int32.Parse(Console.ReadLine());
                    _item.Quantity += _addAmount;
                    return MenuType.ReplenishInventory;
                case "b":
                    // try
                    // {
                        _itemBL.AddLineItem(_item);
                    // }
                    // catch (System.Exception)
                    // {
                    //     Console.WriteLine("Please input a value in all fields!");
                    //     Console.WriteLine("Press Enter to continue");
                    //     Console.ReadLine();
                    //     return MenuType.ReplenishInventory;
                    // }
                    return MenuType.MainMenu;
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