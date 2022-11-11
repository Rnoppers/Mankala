using System;
using System.Collections.Generic;

namespace Mankala
{
    class Program1
    {
        static void Main()
        {

            string chosenGameRules = "Mankala";
            Ruleset newGameRules = new Mankala();
            Game fakeGame = new Game(newGameRules);

            GameInstatiator newInstatiation = new GameInstatiator(chosenGameRules);

            Console.WriteLine(fakeGame.knownRules.ToString());
            
            /*
            GameRunner runner = new GameRunner();
            runner.Run();

            var controller = new GameController();
            var view = new GameView();
            var game = new GameClient();


            //controller.Attach(game);
            game.Attach(view);
            game.Attach(controller);

            controller.SelectGame();

            //controller.StartGame();

            //when game is won, some logic to exit
            GameClient client = new GameClient();
            */
        }
    }
}
