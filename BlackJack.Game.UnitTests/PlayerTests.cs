using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.UnitTests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;

        [TestInitialize]
        public void SetUpTest()
        {
            player = new Player();
        }

        [TestMethod]
        public void TakeCard_Test()
        {
            PrivateObject playerTarget = new PrivateObject(player);                      
            var card = new Card(CardSuite.Diamonds, CardValue.Ace);
            player.TakeCard(card);

            var handAfterTakeCard = (CardsDeck)playerTarget.GetField("hand");
            var handAfterTakeCardTraget = new PrivateObject(handAfterTakeCard);
            var handDeckAfterTakeCard = (Stack<Card>)handAfterTakeCardTraget.GetField("deck");

            Assert.IsTrue(handDeckAfterTakeCard.Contains(card), "Card not added to hand");
        }

    }
}
