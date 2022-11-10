using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Mankala : Ruleset
    {
        
        private int playerCollectionPits => 1;

        private int playerPlayingPits => 6;
        

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
        public Mankala()
        {
        }
        public override Player ChooseWinner(PlayingBoard playingBoard)
        {
            int mostPoints = -1;
            Player winner = new Player();
            foreach(CollectingPit collection in playingBoard.pits)
            {
                if (collection.stones.Count > mostPoints)
                {
                    mostPoints = collection.stones.Count;
                    winner = collection.isOfPlayer;
                }
            }
            return winner;
        }

        public override bool GameOverChecker(PlayingBoard playBoard, Player turnPlayer)
        {
            for (int i = 0; i < playBoard.pits.Length; i++)
            {
                if(playBoard.pits[i].isOfPlayer != turnPlayer)
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

    public override PlayingBoard Move(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            if (LegalMove(playBoard.pits[chosenPit], turnPlayer))
            {
                PlayingBoard afterMoveBoard = DoMove(playBoard, turnPlayer, chosenPit);

                int endingPit = DetermineEndingPit(playBoard, chosenPit);
                if (afterMoveBoard.pits[endingPit].isOfPlayer == turnPlayer)
                {
                    if (afterMoveBoard.pits[endingPit].GetType().ToString() == "CollectionPit")
                    {
                        //Player mag opnieuw een pit kiezen. User Input welke pit tie nu kiest. Wachten op user input en dan opnieuw Move aanroepen.
                        int newChosenPit = -1;
                        return Move(afterMoveBoard, turnPlayer, newChosenPit);
                    }

                    if (afterMoveBoard.pits[endingPit].stones.Count > 0)
                    {
                       return Move(afterMoveBoard, turnPlayer, endingPit);
                    }

                    //Takes stones from opposite pit and put it in collectingpit. 
                    int oppositePit = DetermineOppositePit(playBoard, endingPit);
                    if (afterMoveBoard.pits[oppositePit].stones.Count > 0)
                    {
                        return EatStones(afterMoveBoard, oppositePit, turnPlayer);
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

        private int DetermineEndingPit(PlayingBoard playBoard, int chosenPit)
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

        private int DetermineOppositePit(PlayingBoard playBoard, int endingPit)
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

        private PlayingBoard EatStones(PlayingBoard playBoard, int eatPit, Player turnPlayer)
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

        private int FindCollectionPit(PlayingBoard playBoard, Player turnPlayer)
        {
            for (int i = 0; i <= playBoard.pits.Length; i++)
            {
                if (playBoard.pits[i].GetType().ToString() == "CollectionPit" && playBoard.pits[i].isOfPlayer == turnPlayer)
                    return i;
            }
            throw new ArgumentException("player heeft geen collectionpit.");
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
                if (newBoard.pits[pitCount].isOfPlayer == turnPlayer && newBoard.pits[pitCount].GetType().ToString() == collectionPit)
                {
                    continue;
                }
                newBoard.pits[pitCount].stones.Push(newBoard.pits[chosenPit].stones.Peek());
                newBoard.pits[chosenPit].stones.Pop();
            }
            return newBoard;
        }
    }
}
