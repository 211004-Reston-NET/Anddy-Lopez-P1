using System;
using System.Collections.Generic;
using System.Linq;
using P0BL;
using P0Models;

namespace P0UI
{
    public class CurrentCustomer : IMenu
    {
        private ICustomersBL _custBL;
        public CurrentCustomer(ICustomersBL p_custBL)
        {
            this._custBL = p_custBL;
        }
        // This will be used to sign in as a user, so it can save one's order to the right location
        // private Customers _custMo;
        // public CurrentCustomer(Customers p_custMo)
        // {
        //     this._custMo = p_custMo;
        // }
        public static int _userSelected;
        
        public void Menu()
        {
            if (ShowCustomers._findCustName != null)
            {
                List<Customers> listOfCust = _custBL.GetCustomers(ShowCustomers._findCustName);

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
            else if (ShowCustomers._findCustAddress != null)
            {
                List<Customers> listOfCust = _custBL.GetCustomersAdd(ShowCustomers._findCustAddress);

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
            else if (ShowCustomers._findCustEmail != null)
            {
                List<Customers> listOfCust = _custBL.GetCustomersEmail(ShowCustomers._findCustEmail);

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
            else if (ShowCustomers._findCustPhone != null)
            {
                List<Customers> listOfCust = _custBL.GetCustomersPhone(ShowCustomers._findCustPhone);

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
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "a":
                    //_userSelected = _custMo.Id; 
                    _userSelected = 1;
                    Console.WriteLine("You are now proceeding as your chosen Customer");
                    Console.WriteLine(_userSelected);
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