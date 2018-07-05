using NUnit.Framework;
using System;
using DartScorer;

namespace DartScorerTests
{
    [TestFixture()]
    public class MatchTest
    {
        Match match;

        [SetUp]
        public void Init()
        {
            match = new Match("Tam", "Winston", 7, 5, 301);
        }

        [Test()]
        public void TestSetsNeededToWin()
        {
            Assert.AreEqual(4, match.SetsNeededToWinMatch());
        }

        [Test()]
        public void TestLegsNeededToWinSet()
        {
            Assert.AreEqual(3, match.LegsNeededToWinSet());
        }

        [Test()]
        public void TestSetWon()
        {
            match.Game.Player1.LegsWon = 3;
            match.Game.Player2.SetsWon = 0;
            match.Game.Player2.CurrentScore = 0;

            Assert.IsTrue(match.SetWon());
        }
    }
}
