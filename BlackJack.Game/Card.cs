using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game
{
    public class Card
    {
        private CardSuite suite;
        private CardValue value;
        
        public Card(CardSuite suite, CardValue value)
        {
            this.suite = suite;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{suite} {value}";
        }        

        public CardValue GetValue()
        {
            return this.value;
        }

    }
}
