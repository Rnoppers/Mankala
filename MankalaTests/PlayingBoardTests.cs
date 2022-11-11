using System;
using System.Collections.Generic;
using System.Text;

namespace MankalaTests
{
    public class PlayingBoardTests
    {
        [Fact]
        public void LegalMoveWrongPlayerTurn()
        {
            Player turnPlayer1 = new Player();
            Player player2 = new Player();

            Pit player2Pit = new PlayingPit();
            List<Stone> stoneList = new List<Stone>();
            Stone stone = new Stone();
            stoneList.Add(stone);
            player2Pit.stones = stoneList;
            player2Pit.isOfPlayer(player2);

            Ruleset testRules = new Mankala.Mankala();
            bool result = testRules.LegalMove(player2Pit, turnPlayer1);

            //cant choose other players pit
            Assert.False(result);
        }

    }
}
