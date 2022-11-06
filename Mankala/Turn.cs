using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Turn
    {
        public Turn()
        {

        }


        public void NextMove(PlayingBoard playBoard, Player turn, int chosenPit)
        {
            PlayingBoard afterMoveBoard;
            afterMoveBoard = Ruleset.Move(playBoard, turn, chosenPit);

            //1 illegalboard maken.
            if(afterMoveBoard == illegalBoard)
            {
                //string return van "deze move kan niet"
            }
            //-1, omdat tie de enemies collectingpit overslaat. Voor Mankala is dat 1 namelijk.
            int endingPit = (chosenPit % (playBoard.pits.Length - 1));
            
            if(endingPit.isOfPlayer == turn)
            {
                if(endingPit.kindOfPit == CollectingPit)
                {
                    //User Input welke pit tie nu kiest. Dus gewoon return, zonder turn aan te passen.
                    return;
                }

                if(afterMoveBoard.pits[endingPit].stones.Count > 0)
                {
                    NextMove(afterMoveBoard, turn, endingPit);
                    //Player has to change. We still have to implement this.
                    Player.ChangePlayer();
                    return;
                }

                //Takes stones from opposite pit and put it in collectingpit. 
                int oppositePit = (endingPit + (afterMoveBoard.pits.Length)/2);
                if (afterMoveBoard.pits[oppositePit].stones.Count > 0)
                {
                    foreach (Stone stone in afterMoveBoard.pits[oppositePit].stones)
                    {
                        turn.CollectingPit.stones.add(stone);

                        int lastStone = afterMoveBoard.pits[oppositePit].LastStone();
                        afterMoveBoard.pits[oppositePit].stones.RemoveAt[lastStone];
                    }
                    Player.ChangePlayer();
                    return;
                }
            }


        }
    }
}
