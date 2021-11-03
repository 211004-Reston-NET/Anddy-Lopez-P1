using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class AddOrder : IMenu
    {
        private static List<LineItems> _itemList = new List<LineItems>();
        private static List<Products> _prodList = new List<Products>();
        
        private ICustomersBL _custBL;
        private ILineItemBL _itemBL;
        private IProductsBL _prodBL;
        public static int _newQuan = 0;
        public static int _price;
        public AddOrder(ICustomersBL p_custBL, ILineItemBL p_itemBL, ProductsBL p_prodBL)
        {
            _custBL = p_custBL;
            _itemBL = p_itemBL;
            _prodBL = p_prodBL;
            _itemList = _itemBL.GetAllLineItems(ShowProducts._findProd);
            _prodList = _prodBL.GetProducts(ShowProducts._findProdName);
        }
        int _currentItem = 0;
        
        public void Menu()
        {
            LineItems Item = _itemBL.GetItemsByID(_itemList[_currentItem].Id);
            //Products Prod = _prodBL
            //List<LineItems> listOfItems = _itemBL.GetItemsByID(User.order.StoreId);
            
            Console.WriteLine("Welcome to the Shopping Center!");
            Console.WriteLine(Item);
            Console.WriteLine("Quantity you wish to purchase - "+ _newQuan);
            Console.WriteLine("[a] - Change quantity");
            Console.WriteLine("[b] - Add another product to your order");
            Console.WriteLine("[c] - Complete your Order and return to the Main Menu");
            Console.WriteLine("[x] - Go back to Main Menu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "a":
                    int _currentItem = _itemList.Count-1;
                    Console.WriteLine("Type in value for Quantity");
                    try
                    {
                         _newQuan = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please put in a number");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.AddOrder;
                    }
                    _itemBL.UpdateItemQuantity(_itemList[_currentItem], _newQuan);
                    
                    User.order.TotalPrice += (_newQuan * _prodList[_currentItem].Price);
                    LineItems Item = _itemBL.GetItemsByID(_itemList[0].Id);
                    //User.order.LineItems.Add(Item);
                    return MenuType.AddOrder;
                case "b":
                    return MenuType.ShowProducts;
                case "c":
                    //_ord.SLocation = _storeList[0].SAddress;
                    Console.WriteLine("Your Order has been placed");
                    Console.WriteLine("You will be sent back to the Main Menu");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
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