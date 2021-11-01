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
            Console.WriteLine("[b] - Set new inventory amount");
            Console.WriteLine("[c] - Implement changes");
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
                    _item.Id = _item.Id;
                    _item.Product = _item.Product;
                    _item.OrderId = _item.OrderId;
                    return MenuType.ReplenishInventory;
                case "b":
                    Console.WriteLine("Type in new value for Quantity");
                    _addAmount = Int32.Parse(Console.ReadLine());
                    _item.Quantity = _addAmount;
                    _item.Id = _item.Id;
                    _item.Product = _item.Product;
                    _item.OrderId = _item.OrderId;
                    return MenuType.ReplenishInventory;
                case "c":
                    // try
                    // {
                        _itemBL.UpdateLineItem(_item);
                    // }
                    // catch (System.Exception)
                    // {
                    //     Console.WriteLine("Please input a value in designated fields!");
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