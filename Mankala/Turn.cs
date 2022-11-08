using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Turn
    {
        private Ruleset gameRules;


        public Turn(Ruleset rules)
        {
            gameRules = rules;
        }


        public void NextMove(PlayingBoard playBoard, Player turnPlayer, int chosenPit)
        {
            PlayingBoard afterMoveBoard;
            afterMoveBoard = gameRules.Move(playBoard, turnPlayer, chosenPit);

            //1 illegalboard maken.
            if(afterMoveBoard == illegalBoard)
            {
                //string return van "deze move kan niet"
            }
            //-1, omdat tie de enemies collectingpit overslaat. Voor Mankala is dat 1 namelijk.
            
            int endingPit = (chosenPit % (playBoard.pits.Length - 1));
            if(afterMoveBoard.pits[endingPit].isOfPlayer == turnPlayer)
            {
                if(afterMoveBoard.pits[endingPit].GetType().ToString() == "CollectionPit")
                {
                    //Player mag opnieuw een pit kiezen. User Input welke pit tie nu kiest. Wachten op user input en dan opnieuw nextMove aanroepen.
                    int newChosenPit;
                    NextMove(afterMoveBoard, turnPlayer, newChosenPit); 
                    return;
                }

                if(afterMoveBoard.pits[endingPit].stones.Count > 0)
                {
                    NextMove(afterMoveBoard, turnPlayer, endingPit);
                    //Turn ends. player has to change.
                    return;
                }

                //Takes stones from opposite pit and put it in collectingpit. 
                int oppositePit = (endingPit + (afterMoveBoard.pits.Length)/2);
                if (afterMoveBoard.pits[oppositePit].stones.Count > 0)
                {
                    eatStones(afterMoveBoard, oppositePit, turnPlayer);
                    //Turn ends. Player should change.
                    return;
                }
            }
        }

        private void eatStones(PlayingBoard playBoard, int eatPit, Player turnPlayer)
        {
            int collectionPit = findCollectionPit(playBoard, turnPlayer);

            foreach (int stone in playBoard.pits[eatPit].stones)
            {
                playBoard.pits[collectionPit].stones.Push(stone);
                int lastStone = playBoard.pits[eatPit].stones.Pop();
            }
        }

        private int findCollectionPit(PlayingBoard playBoard, Player turnPlayer)
        {
            for(int i = 0; i <= playBoard.pits.Length; i++)
            {
                if (playBoard.pits[i].GetType().ToString() == "CollectionPit" && playBoard.pits[i].isOfPlayer == turnPlayer)
                    return i;
            }
            throw new ArgumentException("player heeft geen collectionpit.");
        }

    }
}
