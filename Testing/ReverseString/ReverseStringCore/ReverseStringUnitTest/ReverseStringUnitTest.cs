using System;
using System.Collections.Generic;
using System.Text;
using ReverseStrings.Feature;

namespace ReverseStringUnitTest
{
    [TestClass]
    public class ReverseStringUnitTest
    {
        [TestMethod]
        public void ReverseString_GettigStringInput_retunReversedString()
        {
            var rev = new ReverseString();
            var result = rev.reverseStr("abcd");
            Assert.AreEqual(result, "dcba");
        }
       

    }
}
