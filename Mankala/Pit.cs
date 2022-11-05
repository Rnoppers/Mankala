using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public abstract class Pit
    {
        public abstract Player isOfPlayer { get; }
        public abstract List<Stone> Stones { get; }
    }

    public class PlayingPit : Pit
    {
        public PlayingPit()
        {

        }
        public override Player isOfPlayer => throw new NotImplementedException();

        public override List<Stone> Stones => throw new NotImplementedException();
    }

    public class CollectingPit : Pit
    {
        public override Player isOfPlayer => throw new NotImplementedException();

        public override List<Stone> Stones => throw new NotImplementedException();
    }

}
