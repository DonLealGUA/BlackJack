using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{

     /*
      * Entity for the GameCards Table
      */
    public class GameCardEntity
    {
        //Has 3 keys
        [Key]
        public int GameID { get; set; }
        [Key]
        public int PlayerID { get; set; }
        [Key]
        public int CardID { get; set; }


       //The PlayerID is a foreginkey from the Player Table
        [ForeignKey("PlayerID")]
        public PlayerEntity Player { get; set; }

        //The CardID is a foreginkey from the Card Table
        [ForeignKey("CardID")]
        public CardEntity Card { get; set; }

    }
}
