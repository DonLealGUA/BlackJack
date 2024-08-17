using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJackEL.BlackJackEventManager;

namespace BlackJackEL
{
    public class Hand
    {
       public Deck Deck;
       public Card LastCard { get; set; }
       public List<Card> Cards { get; set; }

        //Events
        public event CardEventHandler CardDrawn;
        public event EventHandler Standing;
        public event EventHandler Bust;

        public Hand(Deck Deck) 
        { 
            this.Deck = Deck;
            Cards = new List<Card>();
        }

        /*
        * Method that adds card into hand
        * Also checks if user busts and then invokes event for player bust
        */
        public void AddCard(Card card)
        {
            Cards.Add(card);
            LastCard = card;
            CardDrawn?.Invoke(card);

            //När korted är över 21 så görs private void PlayerHand_Bust(object sender, EventArgs e) i Form 1
            if (CalculateScore() > 21)
            {
                Bust?.Invoke(this, EventArgs.Empty);
            }
        }

        /*
        * Invokes a event when Player chooses stand
        */
        public void Stand() 
        {
            Standing?.Invoke(this, EventArgs.Empty);
        }

        /*
        * Method that clears all the cards from the hand
        */
        public void Clear() 
        { 
            Cards.Clear();
        }

        /*
         * Method that calculets the score of the hand
         * Also takes in account the Ace cards behaviour
         */
        public int CalculateScore()
        {
            int score = Cards.Sum(card => GetCardValue(card)); // Lambda

            // Check for aces and adjust the score if necessary
            foreach (var card in Cards)
            {
                if (card.Value == Value.Ace && score > 21)
                {
                    score -= 10; // Changes the value of the Ace from 11 to 1
                }
            }

            return score;
        }


        /*
         * Checks the cards value if its Jack, Queen, King or Ace to then return the correct value
         */
        private int GetCardValue(Card card)
        {
            if (card.Value >= Value.Jack && card.Value <= Value.King)
            {
                return 10; // Jack, Queen, King are worth 10
            }
            else if(card.Value == Value.Ace)
            {
                return 11; // Ace is worth 11 in the begining 
            }
            else
            {
                return (int)card.Value; // Numeric values remain the same
            }
        }

    }
}
