using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{
    /*
     * Entity for the Cards Table
     */
    public class CardEntity
    {
        [Key]
        public int CardID { get; set; }
        [Required]
        public Suit Suit { get; set; }
        [Required]
        public Value Value { get; set; }
        [Required]
        public string Image { get; set; }

        /*
         *  Navigation property that represents the relationship between Cards and GameCards 
         *  A Card can be part of multiple GameCards.
         */
        public List<GameCardEntity> GameCards { get; set; }

    }
}
