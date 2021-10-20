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
    public class Customers
    {
        private string _name;
        public string Name
        { 
            get { return _name; } 
            set
            {
                //Checks to make sure that customer name is only made up of letters
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    throw new Exception("Customer name can only hold letters! Please try again.");
                }
                _name = value;
            }
        }
        
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //List<string> listOfOrders = new List<string>();
        
        public override string ToString()
        {
            return $"Customer name: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone Number: {PhoneNumber}";
        }
    }
}
