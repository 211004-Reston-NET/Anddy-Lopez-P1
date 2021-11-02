using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using P0BL;
using P0Models;

namespace P0UI
{
    public class ItemMenu : IMenu
    {
        private ILineItemBL _itemBL;
        public ItemMenu(ILineItemBL p_itemBL)
        {
            this._itemBL = p_itemBL;
        }
        public static int _itemQ;
        public static string _itemString;
        public void Menu()
        {
            Console.WriteLine("List of Items");
            List<LineItems> listOfItems = _itemBL.GetAllLineItems(ShowProducts._findProd);

            foreach (LineItems items in listOfItems)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(items);
                Console.WriteLine("--------------------");
            }
            if (listOfItems.Any() == false)
            {
                Console.WriteLine("\nItem not found. Please try again.\n");
                Console.WriteLine("[x] - Try again");
            }
            else
            {
                // _itemString = string.Join("test",listOfItems);
                // _itemQ = Int32.Parse(Regex.Match(_itemString, @"\d+").Value);
                Console.WriteLine("[a] - Refill Inventory");
                Console.WriteLine("[x] - Exit");
            }
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    // Console.WriteLine("Enter Item ID you want to change")
                    // {
                    //     //Selects one of the items
                    //     int itemId = Int32.Parse(Console.ReadLine());
                    //     LineItems itemFound = _itemBL.GetItemById(itemId);

                    //     //Asks how much you want to add to the rating
                    //     Console.WriteLine("Input how much you want to add to the quantity");
                    //     int addedQuantity = Int32.Parse(Console.ReadLine());

                    //     //Business layer UpdateItemQuantity method will update the quantity
                    //     _itemBL.UpdateItemQuantity(itemFound, addedQuantity);
                    // }
                    // catch (System.FormatException)
                    // {
                    //     Console.WriteLine("Please input a number and not a character!");
                    //     Console.WriteLine("Press Enter to continue");
                    //     Console.ReadLine();
                    //     return MenuType.ShowProducts;
                    // }
                    return MenuType.ReplenishInventory;
                case "x":
                    return MenuType.ShowProducts;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowProducts;
            }
        }
    }
}