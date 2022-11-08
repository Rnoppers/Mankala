using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class PlayingBoardFactory
    {
        public PlayingBoard CreatePlayingBoard(int pits, Stack<int> stones, Player[] players)
        {
            PlayingBoard newBoard = new PlayingBoard(pits, stones, players);
            return newBoard;
        }
    }
}
