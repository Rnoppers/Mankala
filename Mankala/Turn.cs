using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Turn
    {
        private Ruleset gameRules;


        public Turn(Ruleset rules)
        {
            gameRules = rules;
        }


        public PlayingBoard NextMove(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            Console.WriteLine("Making a move at pit " + chosenPit.ToString());
            
            bool legalMove = gameRules.LegalMove(playBoard.pits[chosenPit], turnPlayer);
           
            if (legalMove)
            {
                return gameRules.Move(playBoard, turnPlayer, chosenPit);

            }
            return (new PlayingBoardFactory().illegalBoard());

        }



    }
}
