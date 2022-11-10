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
        
        public PlayingBoard(List<PitRecipe> pits, Stack<int> initialAmountOfStones, Player[] players)
        {
            CreatePits(pits, initialAmountOfStones, players);
        }
        
        private void CreatePits(List<PitRecipe> amountOfPits, Stack<int> stones, Player[] players)
        {
            PitFactory collectPitFactory = new CollectingPitCreator();
            PitFactory playPitFactory = new PlayingPitCreator();

            int totalPits = 0;
            foreach(PitRecipe pit in amountOfPits)
            {
                totalPits += pit.amountOfPits;
            }

            pits = new Pit[totalPits];
            int counter = 0;

            int amountOfPlayers = players.Length;
            for (int i = 0; i < amountOfPlayers; i++)
            {
                string collection = "CollectionPit";
                string playing = "PlayingPit";
                foreach (PitRecipe pit in amountOfPits)
                {
                    for (int j = 0; j < pit.amountOfPits; j++)
                    {
                        if (pit.kindOfPit == collection)
                        {
                           pits[counter] = collectPitFactory.CreatePit(players[i], stones);
                            counter++;
                        }
                        if (pit.kindOfPit == playing)
                        {
                            pits[counter] = playPitFactory.CreatePit(players[i], stones);
                            counter++;
                        }
                        else
                        {
                            throw new ArgumentException("New kind of pit");
                        }
                    }
                }
            }
        }

    }

}
