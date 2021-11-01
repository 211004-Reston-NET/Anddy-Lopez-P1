using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("[x] - Exit");
            }
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
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