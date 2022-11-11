using System;

namespace Mankala
{
    class Program1
    {
        static void Main()
        {
            /*
            GameRunner runner = new GameRunner();
            runner.Run();
            */

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
        }
    }
}
