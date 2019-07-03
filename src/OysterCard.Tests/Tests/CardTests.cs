using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OysterCard.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        [ExpectedException(typeof(FareException), "You don't have enough balance!")]
        public void TestValidateExeption()
        {
            Card card = new Card(30f);
            card.Validate(31);
        }

        [TestMethod]
        [ExpectedException(typeof(FareException), "You don't have enough balance!")]
        public void TestOutException()
        {
            Card card = new Card(30f);
            card.Out(31);
        }
    }
}
