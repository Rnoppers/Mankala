using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    public class PitRecipe
    {
        public string kindOfPit;
        public int amountOfPits;

        public PitRecipe(string pitKind, int pitAmount)
        {
            kindOfPit = pitKind;
            amountOfPits = pitAmount;
        }
    }
}
