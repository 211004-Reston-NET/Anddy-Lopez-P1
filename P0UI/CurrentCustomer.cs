using System;
using System.Collections.Generic;
using System.Linq;
using P0BL;
using P0Models;

namespace P0UI
{
    public class CurrentCustomer : IMenu
    {
        private static List<Customers> _custList = new List<Customers>();
        private ICustomersBL _custBL;
        public CurrentCustomer(ICustomersBL p_custBL)
        {
            this._custBL = p_custBL;
            _custList = _custBL.GetCustomers(ShowCustomers._findCust.Name);
        }
        // This will be used to sign in as a user, so it can save one's order to the right location
        public static int _userSelected;
        public static string _userName;
        
        public void Menu()
        {
            if (ShowCustomers._searchOption == 1)
            {
                List<Customers> listOfCust = _custBL.GetCustomers(ShowCustomers._findCust.Name);

                Console.WriteLine("The following are the search results:");
                Console.WriteLine("");
                foreach (Customers cust in listOfCust)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine(cust);
                    Console.WriteLine("--------------");
                }
                Console.WriteLine("");
                //checks to see if any customer is found
                if (listOfCust.Any() == false)
                {
                    Console.WriteLine("\nCustomer not found. Please try again.\n");
                    Console.WriteLine("[x] - Try again");
                }
                else if (listOfCust.Count == 1)
                {
                    Console.WriteLine("[a] - Select this customer as your User");
                    Console.WriteLine("[x] - Exit");
                }
                else
                {
                    Console.WriteLine("[x] - Exit");
                }
            }
            else if (ShowCustomers._searchOption == 2)
            {
                List<Customers> listOfCust = _custBL.GetCustomersAdd(ShowCustomers._findCust.Address);

                Console.WriteLine("The following are the search results:");
                foreach (Customers cust in listOfCust)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine(cust);
                    Console.WriteLine("--------------");
                }
                
                //checks to see if any customer is found
                if (listOfCust.Any() == false)
                {
                    Console.WriteLine("\nCustomer not found. Please try again.\n");
                    Console.WriteLine("[x] - Try again");
                }
                else if (listOfCust.Count == 1)
                {
                    Console.WriteLine("[a] - Select this customer as your User");
                    Console.WriteLine("[x] - Exit");
                }
                else
                {
                    Console.WriteLine("[x] - Exit");
                }
            }
            else if (ShowCustomers._searchOption == 3)
            {
                List<Customers> listOfCust = _custBL.GetCustomersEmail(ShowCustomers._findCust.Email);

                Console.WriteLine("The following are the search results:");
                foreach (Customers cust in listOfCust)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine(cust);
                    Console.WriteLine("--------------");
                }
                
                //checks to see if any customer is found
                if (listOfCust.Any() == false)
                {
                    Console.WriteLine("\nCustomer not found. Please try again.\n");
                    Console.WriteLine("[x] - Try again");
                }
                else if (listOfCust.Count == 1)
                {
                    Console.WriteLine("[a] - Select this customer as your User");
                    Console.WriteLine("[x] - Exit");
                }
                else
                {
                    Console.WriteLine("[x] - Exit");
                }
            }
            else if (ShowCustomers._searchOption == 4)
            {
                List<Customers> listOfCust = _custBL.GetCustomersPhone(ShowCustomers._findCust.PhoneNumber);

                Console.WriteLine("The following are the search results:");
                foreach (Customers cust in listOfCust)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine(cust);
                    Console.WriteLine("--------------");
                }
                
                //checks to see if any customer is found
                if (listOfCust.Any() == false)
                {
                    Console.WriteLine("\nCustomer not found. Please try again.\n");
                    Console.WriteLine("[x] - Try again");
                }
                else if (listOfCust.Count == 1)
                {
                    Console.WriteLine("[a] - Select this customer as your User");
                    Console.WriteLine("[x] - Exit");
                }
                else
                {
                    Console.WriteLine("[x] - Exit");
                }
            }
            // else if (ShowCustomers._findID != 0)
            // {
            //     List<Customers> listOfCust = _custBL.GetCustomersById(ShowCustomers._findID);

            //     Console.WriteLine("The following are the search results:");
            //     foreach (Customers cust in listOfCust)
            //     {
            //         Console.WriteLine("--------------");
            //         Console.WriteLine(cust);
            //         Console.WriteLine("--------------");
            //     }
                
            //     //checks to see if any customer is found
            //     if (listOfCust.Any() == false)
            //     {
            //         Console.WriteLine("\nCustomer not found. Please try again.\n");
            //         Console.WriteLine("[x] - Try again");
            //     }
            //     else if (listOfCust.Count == 1)
            //     {
            //         Console.WriteLine("[a] - Select this customer as your User");
            //         Console.WriteLine("[x] - Exit");
            //     }
            //     else
            //     {
            //         Console.WriteLine("[x] - Exit");
            //     }
            // }
            Console.WriteLine("");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "a":
                    int _currentUser = _custList.Count-1;
                    _userSelected = _custList[_currentUser].Id;
                    _userName = _custList[_currentUser].Name;
                    Console.WriteLine("You are now signed in as "+ _userName);
                    Console.WriteLine("Press Enter to proceed to select a store to shop from");
                    Console.ReadLine();
                    return MenuType.ShowStoreFronts;
                case "x":
                    return MenuType.ShowCustomers;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CurrentCustomer;
            }
        }
    }
}