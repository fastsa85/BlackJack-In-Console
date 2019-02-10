using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game
{
    public class Game
    {
        private static Dictionary<CardValue, int> cardsPoints= new Dictionary<CardValue, int>
        {
            { CardValue.Six, 6 },
            { CardValue.Seven, 7 },
            { CardValue.Eight, 8 },
            { CardValue.Nine, 9 },
            { CardValue.Ten, 10 },  
            { CardValue.Jack, 2 },
            { CardValue.Queen, 3 },
            { CardValue.King, 4 },
            { CardValue.Ace, 11 },
        };

        private Queue<Player> players;        
        private CardsDeck deck;
        
        public Game()
        {
            players = new Queue<Player>();

            deck = new CardsDeck();
            deck.Populate36Cards();
            deck.Shuffle();
        }

        private int countPoints(Player player)
        {
            int points = 0;

            foreach(Card card in player.GetCards())
            {
                points += cardsPoints[card.GetValue()];
            }

            return points;
        }

        public void AddPlayer(Player player)
        {
            players.Enqueue(player);
        }

        public void DealFirstTwoCards()
        {
            foreach(Player player in players)
            {
                player.TakeCard(deck.GetNextCard());
                player.TakeCard(deck.GetNextCard());
            }
        }

    }
}
