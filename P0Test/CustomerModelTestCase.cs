using System;
using P0Models;
using Xunit;

namespace P0Test
{
    public class UnitTest1
    {
        //                  NAMES
        /// <summary>
        /// I am testing actual Names that should work
        /// </summary>
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

        /// <summary>
        /// I am testing Names that shouldn't work and will throw an exception
        /// </summary>
        /// <param name="p_input">Put in a name that has numbers or not just letter</param>
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

        //                  PHONE NUMBERS
        /// <summary>
        /// I am testing Phone Numbers that should work
        /// </summary>
        [Fact]
        public void PhoneNumberShouldSetValidData()
        {
            //Arrange
            Customers _custTest = new Customers();
            string phonenum = "5550001";

            //Act
            _custTest.PhoneNumber = phonenum;

            //Assert
            Assert.NotNull(_custTest.PhoneNumber);
            Assert.Equal(_custTest.PhoneNumber, phonenum);
        }

        /// <summary>
        /// I am testing Phone Numbers that shouldn't work and will throw an exception
        /// </summary>
        /// <param name="p_input">Phone numbers that don't contain just numbers or not the right length</param>
        [Theory]
        [InlineData("555Test")] //shouldn't work cuz letters
        [InlineData("555.bad")] //shouldn't work cuz letters and "."
        [InlineData("555#@bs")] //shouldn't work cuz letters and symbols
        // [InlineData("55544")] //shouldn't work cuz too short
        // [InlineData("55544332")] //shouldn't work cuz too long
        public void PhoneNumberShouldFailIfSetWithInvaildData(string p_input)
        {
            //Arrange
            Customers _custTest = new Customers();

            //Act and Assert
            Assert.Throws<Exception>(() => _custTest.PhoneNumber = p_input);
        }
    }
}
