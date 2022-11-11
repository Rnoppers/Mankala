using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameController : GameObserver//, Subject
    {
        private string input;
        private int selectedGame;


        private List<ControllerObserver> _observers = new List<ControllerObserver>();

        public void Update(Game subject) 
        { 
            // receives update from Model, usually when input was incorrect.

            //When not yet finished with the Game:
            //RunGame();
        }

        
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
                Notify();
            }
        }

        public void RunGame()
        {
            input = Console.ReadLine();
            Notify();
        }

    }

    // TODO: more classes below that handle the actual input


}
