﻿using System;
using System.Collections.Generic;
using System.Linq;
using P0DL;
using P0Models;

namespace P0BL
{
    public class CustomersBL : ICustomersBL //Will inherit ICustBL
    {
        // dotnet add reference ..\P0DL\P0DL.csproj 
        private IRepository _repo; //Will change to IRepo

        // This is how we do dependency injection; how not to overload
        public CustomersBL(IRepository p_repo) //Will change to IRepo
        {
            _repo = p_repo;
        }
        
        // Prevents user from leaving variable spaces empty, stopping a null error from occuring
        public Customers AddCustomer(Customers p_cust)
        {
            if (p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
            {
                // Will only be seen by coder
                throw new Exception("Must have value in all properties");
            }
            return _repo.AddCustomer(p_cust);
        }
        
        // cd .\P0BL\ ----> dotnet add reference ..\P0Models\P0Models.csproj
        // used to connect to project folder
        public List<Customers> GetAllCustomers()
        {
            //This section of code can be used to change how customers will be displayed
            //Such as All Caps or Lowercase 
            return _repo.GetAllCustomers();
        }

        public List<Customers> GetCustomers(string p_name)
        {
            List<Customers> listOfCustomers = _repo.GetAllCustomers();

            return listOfCustomers.Where(cust => cust.Name.Contains(p_name)).ToList();
        }

        public Customers GetCustomersById(int p_Id)
        {
            throw new NotImplementedException();
            // Customers custFound = _repo.GetCustomerByID(p_Id);
            // if (custFound == null)
            // {
            //     throw new Exception("Customer was not found!");
            // }
        }

        public List<Orders> GetAllOrders(Customers p_cust)
        {
            throw new NotImplementedException();
            // return _repo.GetAllOrders(p_cust);
        }
    }
}
