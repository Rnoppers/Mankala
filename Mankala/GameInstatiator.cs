using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameInstatiator
    {
       //Create ruleset


        public void CreateGame(GameRules Ruleset)
        {
            Game SpelVerloop = new Game(Ruleset);
        }

        public void CreateTestGame(GameRules Testset)
        {

        }

    }
}
