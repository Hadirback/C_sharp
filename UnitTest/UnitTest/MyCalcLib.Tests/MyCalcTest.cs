using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class MyCalcTest
    {
        [TestMethod]
        public void Sum_10and20_30returned()
        {
            //arrange
            int x = 10;
            int y = 20;
            int expected = 30;

            //act
            MyCalc c = new MyCalc();
            int actual = c.Sum(x, y);


            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
