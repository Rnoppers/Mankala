using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    abstract class RulesetTemplate
    {
        public int PlayerHomePits;
        public int PlayerPlayingPits;
        public int PlayerCollectingPit;

        //Hier is een list van, zodat we per playingpit kunnen bepalen hoeeveel stenen erin liggen en wat voor een soort stenen. Voor nu beginnen we overal met een gelijk aantal stenen en waardes.
        public List<int> StartingStones;




        //Mogelijk een bool maken die voor elke playingpit bepaald of een zet legaal is. Mogelijk een List van maken met alle legale zetten.
        public List<Move> LegalMoves(PlayingBoard PlayBoard, int TurnNumber)
        {
            List<Move> Temp = new List<Move>();
            return Temp;
        }

        public bool GameOverChecker()
        {
            return false;
        }

        public Player ChooseWinner()
        {
            Player Winner = new Player();

            return Winner;
        }


    }
}
