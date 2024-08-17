using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEL
{
    /* 
     * Delegate for handling card related events.
     * In this instanse for the BlackJack game.
     */
    public class BlackJackEventManager
    {
        public delegate void CardEventHandler(Card card);

    }
}
