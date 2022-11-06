using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public abstract class Ruleset
    {
        public abstract int playerCollectionPits
        {
            get;
        }

        public abstract int playerPlayingPits
        {
            get;
        }


        public abstract List<int> startingStones
        {
            get;
        }

        public abstract void GameOverChecker();

        public abstract string ChooseWinner();

        public abstract PlayingBoard Move(PlayingBoard playBoard, Player turn, int chosenPit);

        public abstract bool LegalMove(Pit chosenPit, Player turn);

        public abstract PlayingBoard DoMove(PlayingBoard playBoard, int chosenPit);



    }
}
