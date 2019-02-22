using eCommerce.DAL;
using NUnit.Framework;

namespace Tests
{
    public class CaclulatorTests
    {
        Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add()
        {
            // arrange
            int x = 4, y = 20,expected=24;
            
            // 
            var actualSum = calculator.Add(x,y);
            Assert.AreEqual(expected,actualSum);
        }
        [Test]
        public void AddWithZeroParameters()
        {
            // arrange
            int x = 0, y = 20, expected = -1;

            // 
            var actualSum = calculator.Add(x, y);
            Assert.AreEqual(expected, actualSum);
        }
    }
}