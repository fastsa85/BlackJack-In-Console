using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.UnitTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToString_Test()
        {
            Card card = new Card(CardSuite.Clubs, CardValue.Jack);
            Assert.AreEqual(card.ToString(), "Clubs Jack");
        }
    }
}
