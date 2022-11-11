using System;
using System.Collections.Generic;

namespace Mankala
{
    class Program1
    {
        static void Main()
        {
            GameController controller = new GameController();
            GameView view = new GameView();
            GameModel game = new GameModel();


            controller.Attach(game);
            game.Attach(view);
            game.Attach(controller);

            controller.SelectGame();
            //controller.AwaitInput();

            //when game is won, some logic to exit
            GameModel client = new GameModel();
        }
    }
}
