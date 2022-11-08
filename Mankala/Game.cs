using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Game
    {
        public Ruleset knownRules;
        public List<Turn> turns;
        public Player[] players;
        public PlayingBoard thePlayBoard;


        public Game(Ruleset rules)
        {
            knownRules = rules;
            turns = new List<Turn>();
            players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;
            Player player2 = new Player();
            players[1] = player2;
            PlayingBoardFactory playBoardFactory = new PlayingBoardFactory();
            thePlayBoard = playBoardFactory.CreatePlayingBoard(knownRules.totalPits, knownRules.startingStones, players);
        }


        //Verder implementeren
        private void NextTurn(Ruleset gameRules)
        {
            Turn newTurn = new Turn(knownRules);
        }

        private void DeclareWinner()
        {

        }

    }
}
