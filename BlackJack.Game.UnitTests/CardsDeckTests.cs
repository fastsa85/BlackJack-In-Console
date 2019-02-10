using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack.Game.UnitTests
{
    [TestClass]
    public class CardsDeckTests
    {
        private CardsDeck cardsDeck;

        [TestInitialize]
        public void SetupTest()
        {
            cardsDeck = new CardsDeck();
        }

        [TestMethod]
        public void Populate36Cards_Test()
        {
            cardsDeck.Populate36Cards();
            PrivateObject cardsDeckTarget = new PrivateObject(cardsDeck);
            var actualDeck = (Stack<Card>)cardsDeckTarget.GetField("deck");
            Assert.AreEqual(actualDeck.Count, 36, $"Unexpected deck count: {actualDeck.Count}");
        }

        [TestMethod]
        public void Shuffle_Test()
        {
            cardsDeck.Populate36Cards();
            PrivateObject cardsDeckTarget = new PrivateObject(cardsDeck);
            var deckBeforeShuffle = (Stack<Card>)cardsDeckTarget.GetField("deck");

            cardsDeck.Shuffle();
            var deckAfterShuffle = (Stack<Card>)cardsDeckTarget.GetField("deck");

            Assert.AreNotEqual(deckAfterShuffle, deckBeforeShuffle, "Deck was not shuffled");
            Assert.AreEqual(deckAfterShuffle.Count, 36, $"Unexpected deck count: {deckAfterShuffle.Count}");
            foreach(Card card in deckBeforeShuffle)
            {
                Assert.IsTrue(deckAfterShuffle.Contains(card), $"Card is missed after shuffle: {card}");
            }
        }

        [TestMethod]
        public void AddCard_Test()
        {
            var cardsToAdd = new List<Card>();
            cardsToAdd.Add(new Card(CardSuite.Clubs, CardValue.Ace));
            cardsToAdd.Add(new Card(CardSuite.Diamonds, CardValue.Six));
            cardsToAdd.Add(new Card(CardSuite.Hearts, CardValue.King));
            cardsToAdd.Add(new Card(CardSuite.Spades, CardValue.Ten));

            foreach(Card card in cardsToAdd)
            {
                cardsDeck.AddCard(card);
            }

            PrivateObject cardsDeckTarget = new PrivateObject(cardsDeck);
            var actualCardsDeck = (Stack<Card>)cardsDeckTarget.GetField("deck");

            foreach (Card card in cardsToAdd)
            {
                Assert.IsTrue(actualCardsDeck.Contains(card), $"Card not added: {card}");
            }
        }

        [TestMethod]
        public void GetCards_Test()
        {
            var cardsToAdd = new Stack<Card>();
            cardsToAdd.Push(new Card(CardSuite.Hearts, CardValue.Jack));
            cardsToAdd.Push(new Card(CardSuite.Diamonds, CardValue.Ace));
            cardsToAdd.Push(new Card(CardSuite.Hearts, CardValue.King));
            cardsToAdd.Push(new Card(CardSuite.Spades, CardValue.Six));

            PrivateObject cardsDeckTarget = new PrivateObject(cardsDeck);
            cardsDeckTarget.SetField("deck", cardsToAdd);

            Assert.AreEqual(cardsToAdd, cardsDeck.GetCards(), "GetCards() failed");
        }
    }
}
