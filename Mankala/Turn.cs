using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Turn
    {
        private Ruleset gameRules;


        public Turn(Ruleset rules, PlayingBoard thePlayBoard, Player turnPlayer, int chosenPit)
        {
            gameRules = rules;
            NextMove(thePlayBoard, turnPlayer, chosenPit);
        }


        public void NextMove(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            gameRules.Move(playBoard, turnPlayer, chosenPit);

           // PlayingBoardFactory illegalFactory = new PlayingBoardFactory(); Dit nog gebruiken als illegale zet, dan opnieuw nextMove.

        }


    }
}
