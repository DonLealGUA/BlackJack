using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{
    /*
    * Deck Class
    */
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public Random RandomArranger { get; set; }
        public bool GameIsDone { get; set; }

        public List<Card> drawnCards;

        public Deck(List<Card> Cards) 
        {
            this.Cards = Cards;
            RandomArranger = new Random();
            GameIsDone = false;
            drawnCards = new List<Card>();
        }


        /*
         * Draws the "top" card from the deck.
         * En sures that same card is not drawn twice.
         * IF all cards have benn drawn it clears the darwnCards list and shuffels all the cards to begin again
         */
        public Card DrawCard()
        {
            if (drawnCards.Count == Cards.Count)
            {
                drawnCards.Clear();
                Shuffle();
            }

            Card drawnCard = Cards[drawnCards.Count]; //Draws top card
            drawnCards.Add(drawnCard);
            return drawnCard;
        }

        /*
        * Shuffles the card deck into random positions
        */
        public void Shuffle()
        {
            int x = Cards.Count;
            while (x > 1)
            {
                x--;
                int k = RandomArranger.Next(x + 1);
                (Cards[k], Cards[x]) = (Cards[x], Cards[k]);
            }
        }

    }
}
