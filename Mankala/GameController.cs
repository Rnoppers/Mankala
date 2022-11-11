using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameController : GameObserver//, Subject
    {
        private string input = "no input yet";


        private List<ControllerObserver> _observers = new List<ControllerObserver>();

        public void Attach(ControllerObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Detach(ControllerObserver observer)
        {
            this._observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(input);
            }
        }

        public void Update(Game subject) 
        { 
            // receives update from Model, usually when input was incorrect.

            //When not yet finished with the Game:
            if (!subject.gameOver)
            {
                AwaitInput();
            }
            else
            {
                // restart game? Close game?
            }
        }

        

        public void SelectGame()
        {
            Console.WriteLine("What gamemode do you want to play?");
            Console.WriteLine("1.) Mankala   2.) Wari");

            string newInput = Console.ReadLine();
            int option;
            bool success = int.TryParse(newInput, out option);

            if (!success || option <= 0 || option > 2)
            {
                Console.WriteLine("Invalid input, try again.");
                SelectGame();
            }
            else
            {
                Console.WriteLine("Game selected. Launching now..");
                input = newInput;
                Notify();
            }
        }

        public void AwaitInput()
        {
            Console.WriteLine("Make a move.");
            input = Console.ReadLine();
            Notify();
        }

    }

    // TODO: more classes below that handle the actual input


}
