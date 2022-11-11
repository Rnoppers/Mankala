using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameClient : Subject, Observer
    {
        private Game gameState;     // field where the actual game is stored? Or maybe just a read-property.

        private List<Observer> _observers = new List<Observer>();

        public Game getState()
        {
            return gameState;
        }

        public void Update(Subject subject)
        {
            // receives update from Controller, most often when input is given.
        }

        public void Attach(Observer observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            // This will only be the controller to indicate that the given input was incorrect
            // this will also be the GameView to show the new state of the playingfield
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }


        // TODO: some methods that create the game.


    }
}
