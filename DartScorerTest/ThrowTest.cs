using NUnit.Framework;
using System;
using DartScorer;

namespace DartScorerTests
{
    [TestFixture()]
    public class ThrowTest
    {
        [Test()]
        public void TestScore()
        {
            Throw t = new Throw(180);
            Assert.AreEqual(180, t.Score);
        }

        [Test()]
        public void TestThrow181IsNotScore()
        {
            Throw t = new Throw(181);
            Assert.IsFalse(t.IsValid());
        }

        [Test()]
        public void TestThrow163IsNotValidScore()
        {
            Throw t = new Throw(163);
            Assert.IsFalse(t.IsValid());
        }

        [Test()]
        public void TestThrow164IsValidScore()
        {
            Throw t = new Throw(164);
            Assert.IsTrue(t.IsValid());
        }

        [Test()]
        public void TestThrow100IsValid()
        {
            Throw t = new Throw(100);
            Assert.IsTrue(t.IsValid());
        }

        [Test()]
        public void TestThrowZeroIsValid()
        {
            Throw t = new Throw(0);
            Assert.IsTrue(t.IsValid());
        }

        [Test()]
        public void TestThrowNegativeValusIsNotValid()
        {
            Throw t = new Throw(-10);
            Assert.IsFalse(t.IsValid());
        }
    }
}
