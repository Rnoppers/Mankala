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

        private bool playerStillMoving;

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
            thePlayBoard = playBoardFactory.CreatePlayingBoard(knownRules.playingPits, knownRules.startingStones, players);

            playerStillMoving = true;
            //The game has begun. Player 1 may start and choose a pit.
        }

        public void NextTurn(string input)
        {
            int chosenPit = int.Parse(input);
            
            GameIsOver();

            if (gameOver)
            {
                DeclareWinner();
            }
            else
            {   
                if (playerStillMoving)
                {
                    //perform turn
                    Console.WriteLine("Initiating turn");
                    Turn newTurn = new Turn(knownRules);
                    PlayingBoard newBoard = newTurn.NextMove(thePlayBoard, turnPlayer, chosenPit);

                    if (knownRules.CanMoveAgain(thePlayBoard, knownRules.DetermineEndingPit(thePlayBoard,chosenPit)))
                    {
                        // Player can move again
                        Console.WriteLine("Player " + turnPlayer.ToString() + ", you can make another move!");
                        playerStillMoving = true;
                    }
                    else
                    {
                        Console.WriteLine("Player " + turnPlayer.ToString() + "'s turn is over.");
                        // Play can not move anymore
                        playerStillMoving = false;
                    }

                    // make sure to update the board to the new, updated version, after every move.
                    thePlayBoard = newBoard;
                }
                else
                {
                    Console.WriteLine("Next player's move.");
                    NextPlayerTurn();
                    playerStillMoving = true;
                }
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

        private void GameIsOver()
        {
            gameOver = knownRules.GameOverChecker(thePlayBoard, turnPlayer);
        }

        private void DeclareWinner()
        {
            winner = knownRules.ChooseWinner(thePlayBoard);
            gameOver = true;
        }

    }
}
