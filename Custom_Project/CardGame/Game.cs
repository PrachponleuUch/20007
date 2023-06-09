using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public interface Game
    {
        
        void Play();

        bool check_winner(Hand player_hand, Hand dealer_hand, bool gameover = false);


        bool Quit();

    }
}
