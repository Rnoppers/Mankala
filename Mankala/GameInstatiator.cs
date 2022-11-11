using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameInstatiator
    {

        public GameInstatiator()
        {
        }
        
        public Game CreateGame(string input)
        {
            Ruleset chosenRules = ChooseRules(input);
            return (new Game(chosenRules));
        }

        private Ruleset ChooseRules(string gameRulesInput)
        {
            string mankalaRules = "1"; //"Mankala"
            string wariRules = "2"; //"Wari"

            if(gameRulesInput == mankalaRules)
            {
                return (new Mankala());
            }
            else if(gameRulesInput == wariRules)
            {
                return (new Wari());
            }
            //No valid rules
            throw new ArgumentException("inputrules do not exist");
        }

    }
}
