using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class PlayingBoard
    {
        //Tijdelijke constructor
        public PlayingBoard()
        {
            List<Pit> pits = new List<Pit>();
            Pit TempPlayingPit = new PlayingPit();
            Pit TempHomePit = new HomePit();
            int AmountOfPits = 14;
            int AmountOfPlayingPits = 12;
            int HomePits = 2;
            int AmountOfStartingstones = 6;

            for(int i = 0; i < AmountOfPlayingPits; i++)
            {
                pits.Add(TempPlayingPit);
            }
            pits.Add(TempHomePit);
            pits.Add(TempHomePit);

        }


        public PlayingBoard(List<Pit> pits, int AmountOfPits, int AmountOfStartingstones)
        {

        }

    }

}
