using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game
{
    public class CardsDeck
    {
        private Stack<Card> deck;

        public CardsDeck()
        {
            deck = new Stack<Card>();
        }

        public void Populate36Cards()
        {
            var suits = Enum.GetValues(typeof(CardSuite));
            var values = Enum.GetValues(typeof(CardValue));

            foreach (CardSuite suite in suits)
            {
                foreach (CardValue value in values)
                {
                    var card = new Card(suite, value);
                    deck.Push(card);
                }
            }
        }

        public Card GetNextCard()
        {
            return deck.Pop();
        }

        public void Shuffle()
        {
            var random = new Random();
            deck = new Stack<Card>(deck.OrderBy(x => random.Next()));
        }

        public void AddCard(Card card)
        {
            this.deck.Push(card);
        }

        public Stack<Card> GetCards()
        {
            return this.deck;
        }
    }
}
