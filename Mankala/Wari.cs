using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class Wari : Ruleset
    {
        public override List<PitRecipe> playerPits
        {
            get
            {
                List<PitRecipe> returnList = new List<PitRecipe>();
                PitRecipe CollectionPit = new PitRecipe("CollectionPit", 1);
                PitRecipe PlayingPit = new PitRecipe("PlayingPit", 6);
                returnList.Add(CollectionPit);
                returnList.Add(PlayingPit);
                return returnList;
            }
        }

        public override Stack<int> startingStones
        {
            get
            {
                Stack<int> returnStack = new Stack<int>();
                int stone = 1;
                returnStack.Push(stone);
                returnStack.Push(stone);
                returnStack.Push(stone);
                returnStack.Push(stone);
                return returnStack;
            }
        }

        public override Player ChooseWinner(PlayingBoard playingBoard)
        {
            int mostPoints = -1;
            Player winner = new Player();
            foreach (CollectingPit collection in playingBoard.pits)
            {
                if (collection.stones.Count > mostPoints)
                {
                    mostPoints = collection.stones.Count;
                    winner = collection.isOfPlayer;
                }
            }
            return winner;
        }

        public override PlayingBoard DoMove(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            PlayingBoard newBoard = playBoard;
            int pitCount = chosenPit;

            while (newBoard.pits[chosenPit].stones.Count > 0)
            {
                if (pitCount++ >= newBoard.pits.Length)
                    pitCount = 0;
                else
                {
                    pitCount++;
                }
                string collectionPit = "CollectionPit";
                if (newBoard.pits[pitCount].GetType().ToString() == collectionPit)
                {
                    continue;
                }
                newBoard.pits[pitCount].stones.Push(newBoard.pits[chosenPit].stones.Peek());
                newBoard.pits[chosenPit].stones.Pop();
            }
            return newBoard;
        }

        public override bool GameOverChecker(PlayingBoard playBoard, Player turnPlayer)
        {
            for (int i = 0; i < playBoard.pits.Length; i++)
            {
                if (playBoard.pits[i].isOfPlayer != turnPlayer)
                {
                    continue;
                }
                else
                {
                    if (playBoard.pits[i].stones.Count != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool LegalMove(Pit chosenPit, Player turnPlayer)
        {
            if (chosenPit.isOfPlayer != turnPlayer)
                return false;

            if (chosenPit.stones.Count == 0)
                return false;

            if (chosenPit.GetType().ToString() == "CollectionPit")
                return false;

            return true;
        }

        public override PlayingBoard Move(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            if (LegalMove(playBoard.pits[chosenPit], turnPlayer))
            {
                PlayingBoard afterMoveBoard = DoMove(playBoard, turnPlayer, chosenPit);

                int endingPit = DetermineEndingPit(playBoard, chosenPit);
                if (afterMoveBoard.pits[endingPit].isOfPlayer != turnPlayer)
                {
                    int eatStonesMin = 2;
                    int eatStonesMax = 3;
                    if (afterMoveBoard.pits[endingPit].stones.Count == eatStonesMin || afterMoveBoard.pits[endingPit].stones.Count == eatStonesMax)
                    {
                        return EatStones(playBoard, endingPit, turnPlayer);
                    }
                }
                return afterMoveBoard;
            }
            else
            {
                Console.WriteLine("illegal move. Try again.");
                PlayingBoardFactory factory = new PlayingBoardFactory();
                return factory.illegalBoard();
            }
            
        }
    }
}
