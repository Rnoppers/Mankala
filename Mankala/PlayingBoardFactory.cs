using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class PlayingBoardFactory
    {
        public PlayingBoard CreatePlayingBoard(int pits, int stones, Player[] players)
        {
            PlayingBoard newBoard = new PlayingBoard(pits, stones, players);
            return newBoard;
        }
    }
}
