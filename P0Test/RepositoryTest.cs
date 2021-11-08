using Microsoft.EntityFrameworkCore;
using P0DL;
using P0Models;
using Xunit;

namespace P0Test
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<P0DatabaseContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<P0DatabaseContext>()
                            .UseSqlite("Filename = Test.db").Options; //UseSqlite() method will create an inmemory database for use named Test.db
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
                Assert.Equal(1, test.Count);
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
                Customers addedCust = new Customers
                {
                    Name = "Colby",
                    Address = "LA",
                    Email = "cq@email.com",
                    PhoneNumber = "9998887766"
                };

                 //Act
                repo.AddCustomer(addedCust);
            }

             //Assert
            using (var contexts = new P0DatabaseContext(_options))//var can be P0DatabaseContext
            {
                var result = contexts.Customers.Find(2);//var can be customers

                Assert.NotNull(result);
                Assert.Equal("Colby", result.Name);
                Assert.Equal("LA", result.Address);
            }
        }

        private void Seed()
        {
            //using block to automatically close the resource that is used to connect to this db after seeding data to it
            using (var context = new P0DatabaseContext(_options))
            {
                //We want to make sure that our inmemory db gets deleted and recreated to not have any data from previous test
                //We want a pristine db to ensure that every tests will have the exasct same db being used to execute the test
                 context.Database.EnsureDeleted();
                 context.Database.EnsureCreated();

                context.Customers.AddRange
                (
                    new Customers
                    {
                        Name = "Stephen",
                        Address = "virginia",
                        Email = "steph@emai.com",
                        PhoneNumber = "1112223344"
                    }
                );
                context.SaveChanges(); 
            }
        }
    }
}