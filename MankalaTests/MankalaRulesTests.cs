using System;
using System.Collections.Generic;
using Xunit;
using Mankala;

namespace MankalaTests
{
    public class MankalaRulesTests
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

        [Fact]
        public void LegalMoveCollectionPit()
        {
            Player turnPlayer1 = new Player();
            Player player2 = new Player();

            Pit player1Pit = new CollectingPit();
            List<Stone> stoneList = new List<Stone>();
            Stone stone = new Stone();
            stoneList.Add(stone);
            player1Pit.stones = stoneList;
            player1Pit.isOfPlayer(turnPlayer1);

            Ruleset testRules = new Mankala.Mankala();
            bool result = testRules.LegalMove(player1Pit, turnPlayer1);

            //cant choose the collectionpit.
            Assert.False(result);
        }

        [Fact]
        public void LegalMoveEmptyPit()
        {
            Player turnPlayer1 = new Player();
            Player player2 = new Player();

            Pit player1Pit = new PlayingPit();
            List<Stone> stoneList = new List<Stone>();
            player1Pit.stones = stoneList;
            player1Pit.isOfPlayer(turnPlayer1);

            Ruleset testRules = new Mankala.Mankala();
            bool result = testRules.LegalMove(player1Pit, turnPlayer1);

            //no stones in pit, so illegal.
            Assert.False(result);
        }

        [Fact]
        public void LegalMoveCorrectPit()
        {
            Player turnPlayer1 = new Player();
            Player player2 = new Player();

            Pit player1Pit = new PlayingPit();
            List<Stone> stoneList = new List<Stone>();
            Stone stone = new Stone();
            stoneList.Add(stone);
            player1Pit.stones = stoneList;
            player1Pit.isOfPlayer(turnPlayer1);

            Ruleset testRules = new Mankala.Mankala();
            bool result = testRules.LegalMove(player1Pit, turnPlayer1);

            //no stones in pit, so illegal.
            Assert.False(result);
        }
    }
}
