using System;
using P0Models;
using Xunit;

namespace P0Test
{
    public class UnitTest1
    {
        [Fact]
        public void NameShouldSetValidData()
        {
            //Arrange
            Customers _custTest = new Customers();
            string name = "Stephen";

            //Act
            _custTest.Name = name;

            //Assert
            Assert.NotNull(_custTest.Name);
            Assert.Equal(_custTest.Name, name);
        }

        [Theory]
        [InlineData("Emiliano20")]
        [InlineData("Hunter17")]
        [InlineData("Colby25")]
        public void NameShouldFailIfSetWithInvaildData(string p_input)
        {
            //Arrange
            Customers _custTest = new Customers();

            //Act and Assert
            Assert.Throws<Exception>(() => _custTest.Name = p_input);
        }
    }
}
