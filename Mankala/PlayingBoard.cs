using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class PlayingBoard
    {
        
        public Pit[] pits;

        public PlayingBoard()
        {

        }
        
        public PlayingBoard(int pits, Stack<int> initialAmountOfStones, Player[] players)
        {
            CreatePits(pits, initialAmountOfStones, players);
        }
        
        private void CreatePits(int amountOfPits, Stack<int> stones, Player[] players)
        {
            PitFactory collectPitFactory = new CollectingPitCreator();
            PitFactory playPitFactory = new PlayingPitCreator();

            int amountOfPlayers = players.Length;
            pits = new Pit[amountOfPits + amountOfPlayers];
            int pitsPerPlayer = amountOfPits / amountOfPlayers;

            // Puts every pit at the correct index of the array
            for (int i = 0; i < amountOfPlayers; i++)
            {
                int startAtIndex = i * pitsPerPlayer + i;
                pits[startAtIndex] = collectPitFactory.CreatePit(players[i], stones);
                for (int j = startAtIndex + 1; j <= startAtIndex + pitsPerPlayer; j++)
                {
                    pits[j] = playPitFactory.CreatePit(players[i], stones);
                }
            }

        }

    }
}
