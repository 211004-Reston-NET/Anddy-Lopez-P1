using System;
using System.Text.RegularExpressions;

/* Will Hold:
Name
Address
Email
Phone Number
List of Orders
*/

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
    }
}
