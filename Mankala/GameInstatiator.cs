using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameInstatiator
    {
        private Ruleset rules;
        public Game gameplay; 

        public GameInstatiator(string gameRulesInput)
        {
            Ruleset chosenRules = ChooseRules(gameRulesInput);
            CreateGame(chosenRules);
        }
        
        private void CreateGame(Ruleset rules)
        {
            gameplay = new Game(rules);
        }

        private Ruleset ChooseRules(string gameRulesInput)
        {
            string mankalaRules = "Mankala";
            string wariRules = "Wari";

            if(gameRulesInput == mankalaRules)
            {
                rules = new Mankala();
            }
            else if(gameRulesInput == wariRules)
            {
                rules = new Wari();
            }
            //No valid rules
            throw new ArgumentException("inputrules do not exist");
        }

    }
}
