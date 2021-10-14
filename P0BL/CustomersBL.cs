using System;
using System.Collections.Generic;
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
        
        // Try catch to prevent null input
        public Customers AddCustomer(Customers p_cust)
        {
            if (p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
            {
                throw new Exception("Must have value in all properties");
            }
            return _repo.AddCustomer(p_cust);
        }
        
        // cd .\P0BL\ ----> dotnet add reference ..\P0Models\P0Models.csproj
        public List<Customers> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
