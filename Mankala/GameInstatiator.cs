using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameInstatiator
    {
        private Ruleset gameRules;

        public GameInstatiator()
        {
        }
        
        public Game CreateGame(string input)
        {
            Ruleset chosenRules = ChooseRules(input);
            gameRules = chosenRules;
            return (new Game(chosenRules));
        }

        private Ruleset ChooseRules(string gameRulesInput)
        {
            string mankalaRules = "1"; //"Mankala"
            string wariRules = "2"; //"Wari"

            if (gameRulesInput == mankalaRules)
            {
                return (new Mankala());
            }
            else if (gameRulesInput == wariRules)
            {
                return (new Wari());
            }
            else
            {
                throw new ArgumentException("inputrules do not exist");
            }
        }

    }
}
