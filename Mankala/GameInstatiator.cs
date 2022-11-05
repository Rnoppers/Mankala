using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameInstatiator
    {
        private GameRules rules;

        public GameInstatiator()
        {
            GameRules chosenRules = ChooseRules();
            CreateGame(chosenRules);
        }

        
        private void CreateGame(GameRules rules)
        {
            Game gameplay = new Game(rules);
        }

        private GameRules ChooseRules()
        {
            string rulesInput = "Mankala";
            string mankalaRules = "Mankala";
            string wariRules = "Wari";

            if(rulesInput == mankalaRules)
            {
            }
            else
            {

            }
            return rules;
        }

    }
}
