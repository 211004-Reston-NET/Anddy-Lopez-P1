using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P0Models;

namespace P0DL
{
    public class RepositoryCloud : IRepository
    {
        //Dependency Injection for variables
        private P0DatabaseContext _context;
        public RepositoryCloud(P0DatabaseContext p_context)
        {
            _context = p_context;
        }


        // Adds customers
        public Customers AddCustomer(Customers p_cust)
        {
            _context.Customers.Add(p_cust);

            _context.SaveChanges();

            return p_cust;
        }
        //Modifies Customer?
        public Customers UpdateCustomer(Customers p_update)
        {
            // var query = 
            //     from cust in _context.Customers
            //     where cust.CustId == p_update.Id
            //     select cust; 
            // foreach (Entity.Customer cust in query)
            // {
            //     cust.CustName = p_update.Name;
            //     cust.CustAddres = p_update.Address;
            //     cust.CustEmail = p_update.Email;
            //     cust.CustPhonenumber = p_update.PhoneNumber;
            // }
            _context.Customers.Update(p_update);
            _context.SaveChanges();
            return p_update;
        }
        // Converts from Entity to Model for Customers
        public List<Customers> GetAllCustomers()
        {
            // Method Syntax
            return _context.Customers.ToList();

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
            //         PhoneNumber = cust.CustPhonenumber,
            //         Id = cust.CustId
            //     });
            // }

            // return listOfCust;
        }
        // Finds customer by Id
        public Customers GetCustomersById(int p_Id)
        {
            // Customers custToFind = _context.Customers
            //                                 .AsNoTracking()
            //                                 .FirstOrDefault(cust => cust.Id == p_Id);

            // return new Model.Customers(){
            //     Id = custToFind.CustId,
            //     Name = custToFind.CustName,
            //     Address = custToFind.CustAddres,
            //     Email = custToFind.CustEmail,
            //     PhoneNumber = custToFind.CustPhonenumber
            // };

            return _context.Customers.Find(p_Id);
        }


        // Converts from Entity to Model for Stores
        public List<StoreFronts> GetAllStoreFronts()
        {
            // Method Syntax
            return _context.StoreFronts.ToList();
        }
        
        //Adds a store
        public StoreFronts AddStore(StoreFronts p_store)
        {
            _context.StoreFronts.Add(p_store);

            _context.SaveChanges();

            return p_store;
        }
        

        //Allows order addition
        public Orders AddOrder(Orders p_ord) //placing an order, hopefully
        {
            // _context.MyOrders.Add
            // (
            //     new Entity.MyOrder()
            //     {
            //         OrderAddress = p_ord.SLocation,
            //         OrderPrice = p_ord.TotalPrice,
            //         StoreId = p_ord.StoreId,
            //         CustId = p_ord.CustId
            //     }
            // );
            _context.Orders.Add(p_ord);

            //This method wil save the changes made to the database
            _context.SaveChanges();
            return p_ord;
        }
        // Will hopefully converts from Entity to Model for Order and matches to customer Id
        public List<Orders> GetAllOrders(Customers p_cust)
        {
            // Method Syntax - looks cleaner
            // return _context.MyOrders
            //     .Where(ord => ord.CustId == p_cust.Id) //we find the orders that match customer ID (entity == model)
            //     .Select(ord => new Model.Orders() //convert to model.order
            //     {
            //         //model = entity
            //         SLocation = ord.OrderAddress,
            //         TotalPrice = ord.OrderPrice,
            //         CustId = ord.CustId,
            //         StoreId = ord.StoreId,
            //         Id = ord.OrderId
            //     }
            // ).ToList();

            return _context.Orders
            .Where(order => order.CustId == p_cust.Id)
            .ToList();
        }
        // Will hopefully converts from Entity to Model for Order and matches to store Id
        public List<Orders> GetAllStoreOrders(StoreFronts p_store)
        {
            // Method Syntax - looks cleaner
            return _context.Orders
            .Where(order => order.StoreId == p_store.Id)
            .ToList();
        }


        // Converts from Entity to Model for products
        public List<Products> GetAllProducts()
        {
            // Method Syntax
            return _context.Products.ToList();
        }


        // Converts from Entity to Model for Line Items
        // Only returns a single Line Item. Poor planning on my part
        public List<LineItems> GetAllLineItems(LineItems p_item)
        {
            // Method Syntax
            return _context.LineItems.ToList();
        }
        //line item update --- adds qunatity to inventory
        void IRepository.UpdateLineItem(int p_itemID, int p_quan)
        {
            var query = _context.LineItems
                .FirstOrDefault<LineItems>(item => item.Id == p_itemID);
            query.Quantity = p_quan;
            _context.SaveChanges();
        }
        LineItems IRepository.UpdateItemQuantity(LineItems p_li)
        {
            _context.LineItems.Update(p_li);
            _context.SaveChanges();
            return p_li;
        }
        public LineItems GetItemsById(int p_itemId)
        {
            // LineItem itemToFind = _context.LineItems
            //                                 .AsNoTracking()
            //                                 .FirstOrDefault(item => item.LiId == p_itemId);

            // return new Model.LineItems(){
            //     Id = itemToFind.LiId,
            //     Product = itemToFind.LiProduct,
            //     OrderId = itemToFind.OrderId,
            //     Quantity = itemToFind.LiQuantity
            // };
            return _context.LineItems.Find(p_itemId);
        }
        // List<Model.LineItems> GetLineItems(int p_Id)
        // {
        //     return _context.LineItems
        //         .Where(item => item.OrderId == p_Id.) 
        //         .Select(ord => new Model.Orders() 
        //         {
        //             //model = entity
        //             SLocation = ord.OrderAddress,
        //             TotalPrice = ord.OrderPrice,
        //             CustId = ord.CustId,
        //             StoreId = ord.StoreId,
        //             Id = ord.OrderId
        //         }
        //     ).ToList();
        // }


        // Converts from Entity to Model for Inventory?
        public List<Inventory> GetAllInventory()
        {
            // Method Syntax
            return _context.Inventory.ToList();
        }

        public Customers DeleteCustomer(Customers p_cust)
        {
            _context.Customers.Remove(p_cust);
            _context.SaveChanges();
            return p_cust;
        }

        public StoreFronts GetStoresById(int p_Id)
        {
            return _context.StoreFronts.Find(p_Id);
        }

        //Gets all the items 
        //I am using this for restock
        public List<LineItems> GetEveryItem()
        {
            return _context.LineItems.ToList();
        }
    }
}