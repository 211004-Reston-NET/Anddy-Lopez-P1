using Microsoft.EntityFrameworkCore;
using P0DL;
using P0Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace P0Test
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<P0DatabaseContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<P0DatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options;
            Seed(); 
        }

        [Fact]
        public void GetAllCustomerShouldReturnAllCustomer()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);

                //Act
                var test = repo.GetAllCustomers();

                //Assert
                Assert.Equal(2, test.Count);
                Assert.Equal("Stephen", test[0].Name);
            }
        }

        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);
                Customers addedcust = new Customers
                {
                    Name = "Colin",
                    Address = "Dallas",
                    Email = "colin@email.com",
                    PhoneNumber = "9098081122"
                };

                //Act
                repo.AddCustomer(addedcust);
            }

            //Assert
            using (P0DatabaseContext contexts = new P0DatabaseContext(_options))
            {
                Customers result = contexts.Customers.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Colin", result.Name);
                Assert.Equal("Dallas", result.Address);
            }
        }

        [Fact]
        public void DeleteCustomerShouldDeleteCustomer()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);
                Customers cust = new Customers
                {
                    Id = 1,
                    Name = "Stephen",
                    Address = "Houston",
                    Email = "steph@email.com",
                    PhoneNumber = "9098087766"
                };

                //Act
                repo.DeleteCustomer(cust);
            }

            using (var context = new P0DatabaseContext(_options))
            {
                //Arrange
                List<Customers> listOfCust = context.Customers.ToList();

                Assert.Single(listOfCust);
                Assert.Null(context.Customers.Find(1));
            }
        }

        [Fact]
        public void GetCustomersByIdShouldWork()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                 //Arrange
                 IRepository repo = new RepositoryCloud(context);

                 //Act
                 Customers foundCust = repo.GetCustomersById(1);
                 
                 //Assert
                 Assert.Equal("Stephen", foundCust.Name);
            }
        }

        [Fact]
        public void GetStoresByIdShouldWork()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                 //Arrange
                 IRepository repo = new RepositoryCloud(context);

                 //Act
                 StoreFronts foundStore = repo.GetStoresById(1);
                 
                 //Assert
                 Assert.Equal("Tony's", foundStore.SName);
            }
        }

        [Fact]
        public void GetNewestOrderShouldGetNewestOrder()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                 //Arange
                 IRepository repo = new RepositoryCloud(context);

                 //Act
                 Orders foundOrder = repo.GetNewestOrder();

                 //Assert
                 Assert.NotNull(foundOrder);
                 Assert.Equal(3, foundOrder.Id);

            }
        }

        private void Seed()
        {
            using (var context = new P0DatabaseContext(_options))
            {
                 context.Database.EnsureDeleted();
                 context.Database.EnsureCreated();

                 context.Customers.AddRange
                 (
                     new Customers
                     {
                         Name = "Stephen",
                         Address = "Houston",
                         Email = "steph@email.com",
                         PhoneNumber = "9098087766",
                     },
                     new Customers
                     {
                         Name = "Danny",
                         Address = "Disney",
                         Email = "danny@email.com",
                         PhoneNumber = "8089097766",
                     }
                 );

                 context.StoreFronts.AddRange
                 (
                     new StoreFronts
                     {
                         SName = "Tony's",
                         SAddress = "Miami",
                     },
                     new StoreFronts
                     {
                         SName = "Test",
                         SAddress = "Chicago",
                     }
                 );

                context.SaveChanges();

                context.Orders.AddRange
                (
                    new Orders
                    {
                        SLocation = "Miami",
                        TotalPrice = 25,
                        CustId = 1,
                        StoreId = 1,
                    },
                    new Orders
                    {
                        SLocation = "Chicago",
                        TotalPrice = 31,
                        CustId = 1,
                        StoreId = 2,
                    },
                    new Orders
                    {
                        SLocation = "Miami",
                        TotalPrice = 47,
                        CustId = 2,
                        StoreId = 1,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}