using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public abstract class Pit
    {
        public Player isOfPlayer = null;
        public List<Stone> stones;

    }

    public class PlayingPit : Pit
    {
        public PlayingPit()
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

        public override List<Stone> Stones => throw new NotImplementedException();
    }

}
