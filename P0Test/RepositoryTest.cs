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
                         PhoneNumber = "9098087766"
                     },
                     new Customers
                     {
                         Name = "Danny",
                         Address = "Disney",
                         Email = "danny@email.com",
                         PhoneNumber = "8089097766"
                     }
                 );

                context.SaveChanges();
            }
        }
    }
}