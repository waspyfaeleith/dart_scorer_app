using NUnit.Framework;
using System;
using DartScorer;
using System.Collections.Generic;

namespace DartScorerTests
{
    [TestFixture()]
    public class GameTest
    {
        Game game;
        Player player1;
        Player player2;

        [SetUp]
        public void Init()
        {
            player1 = new Player("Jack", 501);
            player2 = new Player("Victor", 501);
            //List<Player> players = new List<Player>();
            //players.Add(player1);
            //players.Add(player2);
            game = new Game(501, player1, player2, 3, 5);
        }

        [Test()]
        public void TestGameStartScoreIsSet()
        {
            Assert.AreEqual(501, game.StartScore);
        }

        [Test()]
        public void TestGameThrowerPlayer1()
        {
            Assert.AreEqual(player1, game.Thrower);
        }

        [Test()]
        public void TestGameCanSwitchThrowerToPlayer2()
        {
            game.ChangeThrower();
            Assert.AreEqual(player2.Name, game.Thrower.Name);
        }

        [Test()]
        public void TestGameCanSwitchThrowerBackToPlayer1()
        {
            game.ChangeThrower();
            game.ChangeThrower();
            Assert.AreEqual(player1, game.Thrower);
        }

        [Test()]
        public void TestGameWonIsFalse()
        {
            Assert.IsFalse(game.IsWon());
        }

        [Test()]
        public void TestGameWonIsTrue()
        {
            player1.CurrentScore = 0;
            Assert.IsTrue(game.IsWon());
        }

        [Test()]
        public void TestGameWonGameWinnerSet()
        {
            player1.CurrentScore = 0;
            Assert.AreEqual(player1, game.Winner());
        }

        public void TestGamePlayersSet()
        {
            Assert.AreEqual(501, game.StartScore);
            Assert.AreEqual(game.StartScore, game.Player1.CurrentScore);
            Assert.AreEqual(game.StartScore, game.Player2.CurrentScore);
        }
    }
}
