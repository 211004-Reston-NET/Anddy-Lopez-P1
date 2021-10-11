using System;
using System.Text.RegularExpressions;

/* Will Hold:
Name
Address
LIst of Products
List of Orders
*/

namespace P0Models
{
    public class Store1
    {
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