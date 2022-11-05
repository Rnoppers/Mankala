using System;
using Xunit;
using Mankala;

namespace MankalaTests
{
    public class MankalaRulesTests
    {
        [Fact]
        public void TestLegalMove1()
        {
            Pit emptyPit = new PlayingPit();
            Player turnPlayer = new Player();
            Mankala.Mankala.LegalMove(emptyPit, turnPlayer);
        }
    }
}
