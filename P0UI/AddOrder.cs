using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class AddOrder : IMenu
    {
        private static List<LineItems> _itemList = new List<LineItems>();
        private ICustomersBL _custBL;
        private ILineItemBL _itemBL;
        public static int _newQuan;
        public AddOrder(ICustomersBL p_custBL, ILineItemBL p_itemBL)
        {
            _custBL = p_custBL;
            _itemBL = p_itemBL;
            _itemList = _itemBL.GetAllLineItems(ShowProducts._findProd);
        }
        
        public void Menu()
        {
            LineItems listOfItems = _itemBL.GetItemsByID(_itemList[0].Id);
            
            Console.WriteLine("Welcome to the Shopping Center!");
            // foreach (LineItems item in listOfItems)
            // {
            //     Console.WriteLine("--------------------");
            //     Console.WriteLine(item);
            //     Console.WriteLine("--------------------");
            // }
            Console.WriteLine(listOfItems);
            //Console.WriteLine("To place an order, type in what you need");
            //Console.WriteLine("What would you like to do?");
            //Console.WriteLine("Product ID - "+ _ord.Id);
            Console.WriteLine("Quantity you wish to purchase - "+ _newQuan);
            Console.WriteLine("[a] - Change quantity");
            Console.WriteLine("[b] - Add to Order and return to product list");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    Console.WriteLine("Type in value for Quantity");
                    _newQuan = Int32.Parse(Console.ReadLine());
                    _itemList[0].Quantity = _itemList[0].Quantity - _newQuan; //doesn't show in interface 
                    return MenuType.AddOrder;
                case "b":
                    //_custBL.AddOrder();
                    return MenuType.ShowProducts;
                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddOrder;
            }
        }
    }
}