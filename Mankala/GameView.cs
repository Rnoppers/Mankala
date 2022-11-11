using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameView : Observer
    {
        private Game gameState;

        public void Update(Subject subject)
        {
            // call methods to draw the new state of the playingfield
            
            //this.gameState = subject;
        }

    }

}
