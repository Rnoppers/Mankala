using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameController : Observer//, Subject
    {
        private int state;
        private int selectedGame;


        private List<Observer> _observers = new List<Observer>();

        public void Update(Subject subject) 
        { 
            // receives update from Model, usually when input was incorrect.
        }

        /*
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
        */          // commented section while we ignore Controller as a subject

        public void SelectGame()
        {
            Console.WriteLine("What gamemode do you want to play?");
            Console.WriteLine("1.) Mankala   2.) Wari");

            string input = Console.ReadLine();
            int option;
            bool success = int.TryParse(input, out option);

            if (!success || option <= 0 || option > 2)
            {
                Console.WriteLine("Invalid input, try again.");
                SelectGame();
            }
            else
            {
                Console.WriteLine("Game selected. Launching now..");
                selectedGame = option;
                //Notify();
            }
        }

    }

    // TODO: more classes below that handle the actual input


}
