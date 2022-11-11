using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameModel : GameSubject, ControllerObserver
    {
        private Game gameState;     // field where the actual game is stored? Or maybe just a read-property.

        private List<GameObserver> _observers = new List<GameObserver>();

        private bool launchingGame = true;
        private bool runningGame = false;





        public GameModel()
        {
        }

        public Game getGameState()
        {
            return gameState;
        }
        public void Attach(GameObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Detach(GameObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Update(string input)
        {
            if(launchingGame && !runningGame)
            {
                GameInstatiator newGame = new GameInstatiator();
                gameState = newGame.CreateGame(input);
                ChangeState();
                Notify();
            }
            else if (runningGame && !launchingGame)
            {
                //update according to input for the current turn.

                if (gameState.gameOver)
                {
                    // end the game, otherwise..
                    Console.WriteLine("Game ended.");
                }
                else
                {   // making a move
                    Console.WriteLine("Making a new move..");
                    gameState.NextTurn(input);
                    Notify();
                }
            }

        }


        public void Notify()
        {
            // This will only be the controller to indicate that the given input was incorrect
            // this will also be the GameView to show the new state of the playingfield
            foreach (var observer in _observers)
            {
                observer.Update(gameState);
            }
        }

        private void ChangeState()
        {
            runningGame = !runningGame;
            launchingGame = !launchingGame;
        }


        // TODO: some methods that create the game.


    }
}
