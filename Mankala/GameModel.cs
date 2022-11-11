using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameModel : GameSubject, ControllerObserver
    {
        private Game gameState;     // field where the actual game is stored? Or maybe just a read-property.

        private List<GameObserver> _observers = new List<GameObserver>();

        public GameModel()
        {
        }


        public Game getGameState()
        {
            return gameState;
        }

        public void Update(string input)
        {
            GameInstatiator newGame = new GameInstatiator(input);
            gameState = newGame.gameplay;
        }

        public void Attach(GameObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(GameObserver observer)
        {
            this._observers.Remove(observer);
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


        // TODO: some methods that create the game.


    }
}
