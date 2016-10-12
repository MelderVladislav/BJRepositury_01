using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(36, BJMassiv.GetUsualCards().Count);
        }
    }
}
