using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game
{
    public class Player
    {        
        private CardsDeck hand;
        
        public Player()
        {
            hand = new CardsDeck();
        }

        public void TakeCard(Card card)
        {
            hand.AddCard(card);
        }

        public Stack<Card> GetCards()
        {
            return this.hand.GetCards();
        }
    }
}
