using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{
    /*
     * Card Class for ussage
     */
    public class Card
    {
        public Suit Suit { get; set; }
        public Value Value { get; set; }
        public string Image { get; set; }

        public Card(Suit suit, Value value, string image)
        {
            Suit = suit;
            Value = value;
            Image = image;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
