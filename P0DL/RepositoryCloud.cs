using System.Collections.Generic;
using System.Linq;
using P0Models;
using Entity = P0DL.Entities; //comment out for database refresh
using Model = P0Models;

namespace P0DL
{
    public class RepositoryCloud : IRepository
    {
        // public Customers AddCustomer(Customers p_cust)
        // {
        //     throw new System.NotImplementedException();
        // }

        //comment out for database refresh
        private Entity.P0DatabaseContext _context;
        public RepositoryCloud(Entity.P0DatabaseContext p_context)
        {
            _context = p_context;
        }
        public Model.Customers AddCustomer(Model.Customers p_cust)
        {
            _context.Customers.Add
            (
                new Entity.Customer()
                {
                    CustName = p_cust.Name,
                    CustAddres = p_cust.Address,
                    CustEmail = p_cust.Email,
                    CustPhonenumber = p_cust.PhoneNumber
                }
            );

            //This method wil save the changes made to the database
            _context.SaveChanges();
            return p_cust;
        }

        public List<Model.Customers> GetAllCustomers()
        {
            // throw new System.NotImplementedException();
            // Method Syntax
            return _context.Customers.Select(cust =>
            new Model.Customers()
            {
                Name = cust.CustName,
                Address = cust.CustAddres,
                Email = cust.CustEmail,
                PhoneNumber = cust.CustPhonenumber,
                Id = cust.CustId
            }
            ).ToList();

            //Query Syntax for Inner Joins
            // var result = (from cust in _context.Customers
            //             select cust);
            
            // List<Model.Customers> listOfCust = new List<Model.Customers>();
            // foreach (var cust in result)
            // {
            //     listOfCust.Add(new Model.Customers(){
            //         Name = cust.CustName,
            //         Address = cust.CustAddres,
            //         Email = cust.CustEmail,
            //         //PhoneNumber = cust.CustPhonenumber,
            //         Id = cust.CustId
            //     });
            // }

            // return listOfCust;
        }

        public List<Model.Products> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.StoreFronts> GetAllStoreFronts()
        {
            throw new System.NotImplementedException();
        }
    }
}