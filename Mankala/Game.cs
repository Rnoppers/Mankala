using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class Game
    {
        public Ruleset knownRules;
        public Player[] players;
        public Player turnPlayer;
        public PlayingBoard thePlayBoard;
        public bool gameOver;
        public Player winner;


        public Game(Ruleset rules)
        {
            knownRules = rules;
            players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;
            Player player2 = new Player();
            players[1] = player2;
            //Starting player is player 1.
            turnPlayer = player1;
            PlayingBoardFactory playBoardFactory = new PlayingBoardFactory();
            thePlayBoard = playBoardFactory.CreatePlayingBoard(knownRules.playerPits, knownRules.startingStones, players);
            //The game has begun. Player 1 may start and choose a pit.
        }

        public void NextTurn(int chosenPit)
        {
            Turn newTurn = new Turn(knownRules, thePlayBoard, turnPlayer, chosenPit);
            // alles gebeurt in turn, tot turn voorbij is.

            if (knownRules.GameOverChecker(thePlayBoard, turnPlayer))
            {
                DeclareWinner();
            }
            else
            {
                NextPlayerTurn();
                NextTurn();
            }
        }

        private void NextPlayerTurn()
        {
            if (turnPlayer == players[0])
            {
                turnPlayer = players[1];
            }
            else
            {
                turnPlayer = players[0];
            }
        }

        private void DeclareWinner()
        {
            winner = knownRules.ChooseWinner(thePlayBoard);
            gameOver = true;
        }

    }
}
