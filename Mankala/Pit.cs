using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public abstract class Pit
    {
        public abstract Player isOfPlayer
        {
            get;
        }

        public abstract Stack<int> stones
        {
            get;
        }
    }

    public class PlayingPit : Pit
    {
        public PlayingPit(Player isOfPlayerConstruct, Stack<int> stonesConstruct)
        {
            isOfPlayer = isOfPlayerConstruct;
            stones = stonesConstruct;
        }
        public override Player isOfPlayer
        {
            get;
        }

        public override Stack<int> stones
        {
            get;
        }

    }


    public class CollectingPit : Pit
    {
        public CollectingPit(Player isOfPlayerConstruct, Stack<int> stonesConstruct)
        {
            isOfPlayer = isOfPlayerConstruct;
            stones = stonesConstruct;
        }
        public override Player isOfPlayer
        {
            get;
        }

        public override Stack<int> stones
        {
            get;
        }
    }

}
