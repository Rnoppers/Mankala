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

        public int DetermineEndingPit(PlayingBoard playBoard, int chosenPit)
        {
            int endingPit = chosenPit;
            for (int i = 0; i < playBoard.pits[chosenPit].stones.Count; i++)
            {
                if (endingPit++ >= playBoard.pits.Length)
                    endingPit = 0;
                else
                {
                    endingPit++;
                }
            }
            return endingPit;
        }

        public int DetermineOppositePit(PlayingBoard playBoard, int endingPit)
        {
            if (endingPit + (playBoard.pits.Length / 2) >= playBoard.pits.Length)
            {
                return endingPit - (playBoard.pits.Length / 2);
            }
            else
            {
                return endingPit + (playBoard.pits.Length / 2);
            }
        }

        public  PlayingBoard EatStones(PlayingBoard playBoard, int eatPit, Player turnPlayer)
        {
            PlayingBoard returnBoard = playBoard;
            int collectionPit = FindCollectionPit(playBoard, turnPlayer);

            foreach (int stone in returnBoard.pits[eatPit].stones)
            {
                returnBoard.pits[collectionPit].stones.Push(stone);
                returnBoard.pits[eatPit].stones.Pop();
            }
            return returnBoard;
        }

        public int FindCollectionPit(PlayingBoard playBoard, Player turnPlayer)
        {
            for (int i = 0; i <= playBoard.pits.Length; i++)
            {
                if (playBoard.pits[i].GetType().ToString() == "CollectionPit" && playBoard.pits[i].isOfPlayer == turnPlayer)
                    return i;
            }
            throw new ArgumentException("player heeft geen collectionpit.");
        }

    }
}
