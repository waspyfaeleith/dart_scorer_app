using NUnit.Framework;
using System;
using DartScorer;


namespace DartScorerTests
{
    [TestFixture()]
    public class PlayerTest
    {
        [Test()]
        public void TestCasePlayerNameSet()
        {
            Player p = new Player("Fred", 501);
            Assert.AreEqual("Fred", p.Name);
        }


        [Test()]
        public void TestCasePlayerCurrentScoreSet()
        {
            Player p = new Player("Fred", 501);
            Assert.AreEqual(501, p.CurrentScore);
        }

        [Test()]
        public void TestPlayerSetLegsScoreIsZero()
        {
            Player p = new Player("Fred", 501);
            Assert.AreEqual(0, p.LegsWon);
        }

        [Test()]
        public void TestPlayerSetSetScoreIsZero()
        {
            Player p = new Player("Fred", 501);
            Assert.AreEqual(0, p.SetsWon);
        }

        [Test()]
        public void TestPlayerThrowGetsNewCurrentScore()
        {
            Player p = new Player("Fred", 140);
            Throw t = new Throw(100);
            p.ThrowDarts(t);
            Assert.AreEqual(40, p.CurrentScore);
        }

        [Test()]
        public void TestPlayerThrowsBustScoreGreaterThanCurrentScore()
        {
            Player p = new Player("Fred", 40);
            Throw t = new Throw(41);
            Assert.IsTrue(p.IsBust(t));
        }

        [Test()]
        public void TestPlayerThrowsBustScoreLeavesOne()
        {
            Player p = new Player("Fred", 100);
            Throw t = new Throw(99);
            Assert.IsTrue(p.IsBust(t));
        }

        [Test()]
        public void TestPlayerThrowsWinningScore()
        {
            Player p = new Player("Phil", 100);
            Throw t = new Throw(100);
            Assert.IsTrue(p.IsWinningScore(t));
            Assert.AreEqual(0, p.CurrentScore);
        }

        [Test()]
        public void TestPlayerDoesNotThrowWinningScore()
        {
            Player p = new Player("Phil", 100);
            Throw t = new Throw(45);
            Assert.IsFalse(p.IsWinningScore(t));
        }

        [Test()]
        public void TestPlayerThrowsBustScoreDoesNotChange()
        {
            Player p = new Player("Fred", 40);
            Throw t = new Throw(65);
            p.ThrowDarts(t);
            Assert.AreEqual(40, p.CurrentScore);
        }

        [Test()]
        public void Test164IsAFinish()
        {
            Player p = new Player("Fred", 164);
            Assert.IsTrue(p.IsOnAFinish());
        }

        [Test()]
        public void Test158IsAFinish()
        {
            Player p = new Player("Fred", 158);
            Assert.IsTrue(p.IsOnAFinish());
        }

        [Test()]
        public void Test138IsAFinish()
        {
            Player p = new Player("Fred", 138);
            Assert.IsTrue(p.IsOnAFinish());
        }

        [Test()]
        public void Test159IsNotAFinish()
        {
            Player p = new Player("Fred", 159);
            Assert.IsFalse(p.IsOnAFinish());
        }

        [Test()]
        public void Test162IsNotAFinish()
        {
            Player p = new Player("Fred", 162);
            Assert.IsFalse(p.IsOnAFinish());
        }

    }
}
