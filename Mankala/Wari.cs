using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class Wari : Ruleset
    {
        public override List<PitRecipe> playerPits => throw new NotImplementedException();

        public override Stack<int> startingStones => throw new NotImplementedException();

        public override Player ChooseWinner(PlayingBoard playingBoard)
        {
            throw new NotImplementedException();
        }

        public override PlayingBoard DoMove(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            throw new NotImplementedException();
        }

        public override bool GameOverChecker(PlayingBoard playBoard, Player turnPlayer)
        {
            throw new NotImplementedException();
        }

        public override bool LegalMove(Pit chosenPit, Player turnPlayer)
        {
            throw new NotImplementedException();
        }

        public override PlayingBoard Move(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            throw new NotImplementedException();
        }
    }
}
