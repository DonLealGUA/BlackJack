using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{

    /*
     * Entity for the Player Table
     */
    public class PlayerEntity
    {
        [Key]
        public int PlayerID { get; set; }
        [Required]
        public string PlayerName { get; set; }
        [Required]
        public bool Winner { get; set; }
        [Required]
        public bool IsDealer { get; set; }

        /*
         *  Navigation property that represents the relationship between Player and GameCards 
         *  A player can be associated with multiple GameCards.
         */
        public List<GameCardEntity> GameCards { get; set; }

    }
}
