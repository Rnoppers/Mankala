using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameController : Subject, Observer
    {
        private int state;

        private List<Observer> _observers = new List<Observer>();

        public int getState() 
        {
            return state;
        }

        public void Update(Subject subject) 
        { 
            // receives update from Model, usually when input was incorrect.
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
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }

    // TODO: more classes below that handle the actualt input

}
