using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class GameRunner
    {
        Game game;

        public GameRunner()
        {

        }

        public void Run()
        {
            Console.WriteLine("What gamemode do you want to play? Mankala or Wari");

            string input = Console.ReadLine();
            GameInstatiator newGame = new GameInstatiator(input);
            game = newGame.gameplay;

            while(!game.gameOver)
            {
                Console.WriteLine("THE PLAYINGBOARD" +
                    "" +
                    "Turn: player... choose a pit" +
                    "");
                string chosenPit = Console.ReadLine();
                int chosenPitNumber;
                if(int.TryParse(chosenPit, out chosenPitNumber))
                {
                    game.NextTurn(chosenPitNumber);
                }
                Console.WriteLine("Ongeldige invoer");
            }

            Console.WriteLine("The game is over. The winner is " + game.winner.ToString());
        }

    }
}
