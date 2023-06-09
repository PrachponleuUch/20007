using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class GameFactory
    {
        
        public static Game GetGame(int gamechoice)
        {
            Game game = null;
            switch(gamechoice)
            {
                case 1:

                    game = new BlackJackGame();
                    
                    break;
                case 2:

                    game = new BaccaratGame();
                    
                    break;
            }
            return game;
        }
       
    }
}
