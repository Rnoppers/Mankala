using System;
using System.Collections.Generic;
using Xunit;
using Mankala;

namespace MankalaTests
{
    public class PlayingBoardTests
    {
        [Fact]
        public void PlayBoardFactoryPits()
        {
            //Arrange
            PlayingBoardFactory testFactory = new PlayingBoardFactory();
            int playingPits = 14;
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Player[] players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;

            int amountPlayers = 2;
            int totalPits = playingPits + amountPlayers;

            //Act
            PlayingBoard testBoard = testFactory.CreatePlayingBoard(playingPits, stones, players);

            //Assert
            Assert.True(testBoard.pits.Length == totalPits);
        }

        [Fact]
        public void PlayBoardFactoryStones()
        {
            //Arrange
            PlayingBoardFactory testFactory = new PlayingBoardFactory();
            int playingPits = 14;
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Player[] players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;

            int amountOfStones = 1;

            //Act
            PlayingBoard testBoard = testFactory.CreatePlayingBoard(playingPits, stones, players);

            //Assert
            Assert.True(testBoard.pits[4].stones.Count == amountOfStones);
        }

        [Fact]
        public void PlayBoardFactoryPlayers()
        {
            //Arrange
            PlayingBoardFactory testFactory = new PlayingBoardFactory();
            int playingPits = 14;
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Player[] players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;


            //Act
            PlayingBoard testBoard = testFactory.CreatePlayingBoard(playingPits, stones, players);

            //Assert
            Assert.True(testBoard.pits[4].isOfPlayer == player1);
        }

        [Fact]
        public void PlayBoardFactoryNull()
        {
            //Arrange
            PlayingBoardFactory testFactory = new PlayingBoardFactory();
            int playingPits = 14;
            Stack<int> stones = new Stack<int>();
            int stone = 1;
            stones.Push(stone);
            Player[] players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;


            //Act
            PlayingBoard testBoard = testFactory.CreatePlayingBoard(playingPits, stones, players);

            //Assert
            Assert.NotNull(testBoard);
        }
    }
}
