using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Mankala : Ruleset
    {
        public override int playerCollectionPits => throw new NotImplementedException();

        public override int playerPlayingPits => throw new NotImplementedException();

        public override List<int> startingStones => throw new NotImplementedException();

        public override string ChooseWinner()
        {
            throw new NotImplementedException();
        }

        public override void GameOverChecker()
        {
            throw new NotImplementedException();
        }

        //Als dit true is voert tie hem uit. Anders feedback geven dat deze zet niet kan.
        public override bool Move(PlayingBoard playBoard, Player turn, int chosenPit)
        {
            if(LegalMove(playBoard.pits[chosenPit], turn))
            {
                DoMove(playBoard, chosenPit);
                return true;
            }
            return false;
        }

        public override bool LegalMove(Pit chosenPit, Player turn)
        {
            if (chosenPit.isOfPlayer != turn)
                return false;

            if (chosenPit.Stones.Count == 0)
                return false;

            return true;
        }

        //Nog implementeren.
        public override PlayingBoard DoMove(PlayingBoard playBoard, int chosenPit)
        {
            throw new NotImplementedException();
        }
    }
}
