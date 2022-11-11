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
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Pit player2Pit = new PlayingPit(player2, stones);
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

            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Pit player1Pit = new CollectingPit(turnPlayer1, stones);

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

            Stack<int> stones = new Stack<int>();
            Pit player1Pit = new PlayingPit(turnPlayer1, stones);

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

            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Pit player1Pit = new PlayingPit(turnPlayer1, stones);

            Ruleset testRules = new Mankala.Wari();
            bool result = testRules.LegalMove(player1Pit, turnPlayer1);

            Assert.True(result);
        }

        [Fact]
        public void ChooseWinnerCorrect()
        {
            int playingPits = 14;
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Player[] players = new Player[2];
            Player player1 = new Player();
            Player player2 = new Player();
            players[0] = player1;
            players[1] = player2;
            PlayingBoard board = new PlayingBoard(playingPits, stones, players);
            board.pits[0].stones.Push(stone);
            board.pits[0].stones.Push(stone);

            Ruleset testRules = new Mankala.Mankala();
            Player winner = testRules.ChooseWinner(board);

            Assert.True(winner == player1);
        }

        [Fact]
        public void ChooseWinnerEdge()
        {
            int playingPits = 14;
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Player[] players = new Player[2];
            Player player1 = new Player();
            Player player2 = new Player();
            players[0] = player1;
            players[1] = player2;
            PlayingBoard board = new PlayingBoard(playingPits, stones, players);
            board.pits[0].stones.Push(stone);
            board.pits[8].stones.Push(stone);
            board.pits[8].stones.Push(stone);

            Ruleset testRules = new Mankala.Mankala();
            Player winner = testRules.ChooseWinner(board);

            Assert.True(winner == player1);
        }
    }
}
