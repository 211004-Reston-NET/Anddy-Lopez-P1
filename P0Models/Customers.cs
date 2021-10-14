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
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    throw new Exception("Employee can only hold letters!");
                }
                _name = value;
            }
        }
        
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public override string ToString()
        {
            return $"Customer name: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone Number: {PhoneNumber}";
        }
    }
}
