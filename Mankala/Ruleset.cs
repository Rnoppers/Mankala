using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public abstract class Ruleset
    {
        public abstract List<PitRecipe> playerPits
        {
            get;
        }

        public abstract Stack<int> startingStones
        {
            get;
        }

        public abstract bool GameOverChecker(PlayingBoard playBoard, Player turnPlayer);

        public abstract Player ChooseWinner(PlayingBoard playingBoard);

        public abstract PlayingBoard Move(PlayingBoard playBoard, Player turnPlayer, int chosenPit);

        public abstract bool LegalMove(Pit chosenPit, Player turnPlayer);

        public abstract PlayingBoard DoMove(PlayingBoard playBoard, Player turnPlayer, int chosenPit);



    }
}
