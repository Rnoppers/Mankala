using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public abstract class PitFactory
    {
        public abstract Pit CreatePit(Player isOfPlayer, Stack<int> stones);
    }

    public class PlayingPitCreator : PitFactory
    {
        public override Pit CreatePit(Player isOfPlayer, Stack<int> stones)
        {
            PlayingPit newPit = new PlayingPit(isOfPlayer, stones);
            return newPit;
        }
    }

    public class CollectingPitCreator : PitFactory
    {
        public override Pit CreatePit(Player isOfPlayer, Stack<int> stones)
        {
            CollectingPit newPit = new CollectingPit(isOfPlayer, stones);
            return newPit;
        }
    }



}
