using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCode.Feature;

namespace CalculatorCode.Tests
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [DataRow(2,1,3)]
        [DataRow(11,1,12)]
        public void Add_Parameterized(int a,int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Add(a, b);
            Assert.AreEqual(expected, result);
        }
    }


}
