using System;
using System.Collections.Generic;
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
        private string _phonenum;
        public int Id { get; set; }
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
        public string PhoneNumber 
        { 
            get { return _phonenum; } 
            set 
            {
                //Checks to make sure that customer phone number is only made up of numbers
                if (!Regex.IsMatch(value, @"^[0-9]+$"))
                {
                    throw new Exception("Customer phone number can only hold numbers! Please try again.");
                }
                // if (PhoneNumber.Length != 7 && PhoneNumber.Length != 10)
                // {
                //     throw new Exception("Customer phone number must be 7 digits long. 10 if you include an area code.");
                // }
                _phonenum = value;
            } 
        }
        //Correct way to do a list
        public List<Orders> Orders { get; set; }
        
        public override string ToString()
        {
            return $"Customer name: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone Number: {PhoneNumber}";
        }
    }
}
