using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.UnitTests
{
    [TestClass]
    public class Game_Tests
    {
        private Game game;       
        Player playerOne;
        Player playerTwo;

        [TestInitialize]
        public void SetUpTest()
        {
            game = new Game();
            playerOne = new Player();
            playerTwo = new Player();
            game.AddPlayer(playerOne);
            game.AddPlayer(playerTwo);
        }

        [TestMethod]
        public void DealFirstTwoCards_Test()
        {
            game.DealFirstTwoCards();

            PrivateObject playerOneTarget = new PrivateObject(playerOne);
            PrivateObject playerTwoTarget = new PrivateObject(playerTwo);

            var playerOneHand = playerOneTarget.GetField("hand");
            PrivateObject playerOneHandTarget = new PrivateObject(playerOneHand);
            var playerOneCards = (Stack<Card>)playerOneHandTarget.GetField("deck");

            var playerTwoHand = playerTwoTarget.GetField("hand");
            PrivateObject playerTwoHandTarget = new PrivateObject(playerTwoHand);
            var playerTwoCards = (Stack<Card>)playerTwoHandTarget.GetField("deck");

            Assert.IsTrue(playerOneCards.Count == 2, "Two firs cards were not dealed to first player");
            Assert.IsTrue(playerTwoCards.Count == 2, "Two firs cards were not dealed to second player");
        }

        [TestMethod]
        public void countPoints_Test()
        {
            Card card1 = new Card(CardSuite.Clubs, CardValue.Ace);
            Card card2 = new Card(CardSuite.Diamonds, CardValue.Six);
            Card card3 = new Card(CardSuite.Hearts, CardValue.Jack);
            int expectedPoints = 11 + 6 + 2;

            playerOne.TakeCard(card1);
            playerOne.TakeCard(card2);
            playerOne.TakeCard(card3);

            PrivateObject gameTarget = new PrivateObject(game);
            int actualPoints = (int)gameTarget.Invoke("countPoints", playerOne);

            Assert.AreEqual(actualPoints, expectedPoints);
        }
    }
}
