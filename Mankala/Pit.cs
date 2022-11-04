using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    abstract class Pit
    {
        public Player isOfPlayer = null;
        public List<Stone> stones;

        public Pit(Player player)
        {
            isOfPlayer = player;
        }

        public void AddStone()
        {
            stones.Add(new Stone());
        }
        public void RemoveStone()
        {
            stones.Remove(new Stone());
        }
    }

    class PlayingPit : Pit
    {

        public PlayingPit(Player player) : base(player)
        {
        }

    }


    class CollectingPit : Pit
    {
        public CollectingPit(Player player) : base(player)
        {
        }

        public int GetScore()
        {
            return stones.Count;
        }

    }

}
