using BlackJackDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{

    /*
     * 
     */
    public class Player
    {
        public Hand Hand { get; set; }
        public bool isFinished { get; set; }
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public bool Winner { get; set; }
        public bool IsDealer { get; set; }
        public bool isBust { get; set; }



        public Player(Hand hand, bool isFinished, bool Winner, bool isDealer) 
        { 
            this.Hand = hand;
            this.isFinished = isFinished;
            this.Winner = Winner;
            IsDealer = isDealer;
        }


        public override string ToString()
        {
            return $"Player Hand: {Hand} Player is Winner: {Winner}";
        }
    }
}
