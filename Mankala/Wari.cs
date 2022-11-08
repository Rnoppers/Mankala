using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class Wari : Ruleset
    {
        public override int playerCollectionPits => throw new NotImplementedException();

        public override int playerPlayingPits => throw new NotImplementedException();

        public override List<int> startingStones => throw new NotImplementedException();

        public override string ChooseWinner()
        {
            throw new NotImplementedException();
        }

        public override PlayingBoard DoMove(PlayingBoard playBoard, int chosenPit)
        {
            throw new NotImplementedException();
        }

        public override void GameOverChecker()
        {
            throw new NotImplementedException();
        }

        public override bool LegalMove(Pit chosenPit, Player turn)
        {
            throw new NotImplementedException();
        }

        public override PlayingBoard Move(PlayingBoard playBoard, Player turn, int chosenPit)
        {
            throw new NotImplementedException();
        }
    }
}
