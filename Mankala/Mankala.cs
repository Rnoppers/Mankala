using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Mankala : Ruleset
    {
        public override int playerCollectionPits => 1;

        public override int playerPlayingPits => 6;

        public override List<int> startingStones
        {
            get
            {
                int stone = 1;
                startingStones.Add(stone);
                startingStones.Add(stone);
                startingStones.Add(stone);
                startingStones.Add(stone);
                return new List<int>();
            }
        }

        private int amountOfStartingStones = 4;


        public Mankala()
        {
        }

        public List<int> startStones(int stones)
        {
            List<int> startStonesList = new List<int>();
            int stone = 1;
            for(int i=0; i<stones; i++)
            {
                startStonesList.Add(stone);
            }
            return startStonesList;
        }

        public override string ChooseWinner()
        {
            throw new NotImplementedException();
        }

        public override void GameOverChecker()
        {
            throw new NotImplementedException();
        }

        //Als dit true is voert tie hem uit. Anders feedback geven dat deze zet niet kan.
        public override PlayingBoard Move(PlayingBoard playBoard, Player turn, int chosenPit)
        {
            if (LegalMove(playBoard.pits[chosenPit], turn))
            {
                //de instatie van playingboard = DoMove;
                return DoMove(playBoard, chosenPit);
            }
            else
            {
                //specifiek playingboard aanmaken die staat voor een illegale move.
                PlayingBoard illegalMove = new PlayingBoard();
                return illegalMove;
            }
        }

        public override bool LegalMove(Pit chosenPit, Player turn)
        {
            if (chosenPit.isOfPlayer != turn)
                return false;

            if (chosenPit.stones.Count == 0)
                return false;

            return true;
        }

        //Still drops a stone in the enemies collectinghole.
        public override PlayingBoard DoMove(PlayingBoard playBoard, int chosenPit)
        {
            PlayingBoard newBoard = playBoard;
            int stonesIndex = playBoard.pits[chosenPit].stones.Count - 1;
            int pitCount = chosenPit;

            while(newBoard.pits[chosenPit].stones.Count > 0)
            {
                if (pitCount++ >= newBoard.pits.Length)
                    pitCount = 0;
                else
                {
                    pitCount++;
                }
                newBoard.pits[pitCount].stones.Add(newBoard.pits[chosenPit].stones[stonesIndex]);
                newBoard.pits[chosenPit].stones.RemoveAt(stonesIndex);
            }
            return newBoard;
        }
    }
}
