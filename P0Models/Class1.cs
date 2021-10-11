using System;
using System.Text.RegularExpressions;

// Testing Upload

namespace P0Models
{
    public class Store
    {
        private string _customer;
        public string customer
        { 
            get { return _customer; } 
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    throw new Exception("Employee can only hold letters!");
                }
                _customer = value;
            }
        }
        private string _storeFront;
        public string StoreFront
        { 
            get { return _storeFront; } 
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    throw new Exception("Store Front can only hold letters!");
                }
                _storeFront = value;
            }
        }
    }
}
