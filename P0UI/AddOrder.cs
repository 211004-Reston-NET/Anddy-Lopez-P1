using System;
using System.Collections.Generic;
using P0BL;
using P0Models;

namespace P0UI
{
    public class AddOrder : IMenu
    {
        private static Orders _ord = new Orders();
        private static List<LineItems> _itemList = new List<LineItems>();
        private static List<Products> _prodList = new List<Products>();
        private ILineItemBL _itemBL;
        private IProductsBL _prodBL;
        private IOrdersBL _ordBL;
        public static int _newQuan = 0;
        public AddOrder(ILineItemBL p_itemBL, ProductsBL p_prodBL, OrdersBL p_ordBL)
        {
            _itemBL = p_itemBL;
            _prodBL = p_prodBL;
            _ordBL = p_ordBL;
            _itemList = _itemBL.GetAllLineItems(ShowProducts._findProd);
            _prodList = _prodBL.GetProducts(ShowProducts._findProdName);
        }
        int _currentItem = 0;
        
        public void Menu()
        {
            LineItems Item = _itemBL.GetItemsByID(_itemList[_currentItem].Id);

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
                    
                    _ord.TotalPrice += (_newQuan * _prodList[_currentItem].Price);

                    return MenuType.AddOrder;
                case "b":
                    return MenuType.ShowProducts;
                case "c":
                    _ord.SLocation = CurrentStoreFront._storeLocation;
                    _ord.CustId = CurrentCustomer._userSelected;
                    _ord.StoreId = CurrentStoreFront._storeID;
                    try
                    {
                        _ordBL.AddOrder(_ord);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please input a value in all fields!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
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