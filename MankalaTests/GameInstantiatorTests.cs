﻿using System;
using System.Collections.Generic;
using Xunit;
using Mankala;

namespace MankalaTests
{
    public class GameInstantiatorTests
    {
        [Fact]
        public void CreateMankalaGame()
        {

            string chosenGameRules = "Mankala";
            Ruleset newGameRules = new Mankala.Mankala();
            Game fakeGame = new Game(newGameRules);

            GameInstatiator newInstatiation = new GameInstatiator(chosenGameRules);

            Assert.True(newInstatiation.gameplay.knownRules == fakeGame.knownRules);

        }

    }
}
