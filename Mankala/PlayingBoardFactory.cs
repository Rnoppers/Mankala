using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class PlayingBoardFactory
    {

        public PlayingBoard CreatePlayingBoard(List<PitRecipe> pits, Stack<int> stones, Player[] players)
        {
            PlayingBoard newBoard = new PlayingBoard(pits, stones, players);
            return newBoard;
        }

        public PlayingBoard illegalBoard()
        {
            List<PitRecipe> pits = new List<PitRecipe>();
            PitRecipe pitRecipe = new PitRecipe("illegal", -1);
            pits.Add(pitRecipe);
            Stack<int> stones = new Stack<int>();
            Player[] players = new Player[1];
            PlayingBoard newBoard = new PlayingBoard(pits, stones, players);
            return newBoard;
        }
    }
}
