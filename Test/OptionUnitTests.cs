using System;
using NUnit.Framework;
using OptionType;

namespace Test
{
    [TestFixture]
    internal class OptionUnitTests
    {
        [TestCase]
        public void WhenMatchesSome()
        {
            var touched = false;
            Option<int>.For(5).When(x => x > 3).Do(x => touched = true).Execute();
            Assert.IsTrue(touched);
        }

        [TestCase]
        public void WhenDoesntMatchSome()
        {
            Option<int>.For(5).When(x => x > 6).Do(x => Assert.Fail()).Execute();
        }

        [TestCase]
        public void WhenDoesntFallThroughAfterFirstMatch()
        {
            Option<int>.For(5).When(x => x > 3).Do(x => { }).WhenValue().Do(x => Assert.Fail())
                .Execute();
        }

        [TestCase]
        public void WhenSomeMatched()
        {
            var touched = false;
            Option<int>.For(5).WhenValue().Do(x => touched = true).When(x => x > 3).Do(x => Assert.Fail()).Execute();
            Assert.IsTrue(touched);
        }

        [TestCase]
        public void NoneOfWhenMatchesSome()
        {
            const bool touched = false;
            Option<int>.For(5).When(x => x > 6).Do(x => Assert.Fail()).When(x => x > 7).Do(x => Assert.Fail())
                .Execute();
            Assert.IsFalse(touched);
        }

        [TestCase]
        public void WhenMatchesAndServesInputValueToLambda()
        {
            var value = 0;
            Option<int>.For(5).When(x => x > 6).Do(x => Assert.Fail()).When(x => x > 3).Do(x => value = x).Execute();
            Assert.AreEqual(5, value);
        }

        [TestCase]
        public void WhenSomeMatchesAndServesInputValueToLambda()
        {
            var value = 0;
            Option<int>.For(5).When(x => x > 6).Do(x => Assert.Fail()).WhenValue().Do(x => value = x).Execute();
            Assert.AreEqual(5, value);
        }

        [TestCase]
        public void WhenNotMatchingNone()
        {
            Option<int>.None().When(x => true).Do(x => Assert.Fail()).Execute();
        }

        [TestCase]
        public void WhenNoneMatchesNone()
        {
            var touched = false;
            Option<int>.None().When(x => true).Do(x => Assert.Fail()).WhenNone().Do(() => touched = true).Execute();
            Assert.IsTrue(touched);
        }

        [TestCase]
        public void WhenNoneDosntFallThrough()
        {
            Option<int>.None().WhenNone().Do(() => { }).WhenNone().Do(Assert.Fail).Execute();
        }

        [TestCase]
        public void MapToExecutedOnSome()
        {
            var result = Option<int>.For(5).When(x => x > 3).MapTo(x => $"{x} > 3").WhenValue().MapTo(x => "error")
                .Map();
            Assert.AreEqual("5 > 3", result);
        }

        [TestCase]
        public void MapToExecutedAfterWhenSome()
        {
            var result = Option<int>.For(5).WhenValue().MapTo(x => $"{x} > 3").WhenValue().MapTo(x => "error").Map();
            Assert.AreEqual("5 > 3", result);
        }

        [TestCase]
        public void MapToDoesntFallThrough()
        {
            var result = Option<int>.For(5).When(x => x > 3).MapTo(x => $"{x} > 3").When(x => x > 2)
                .MapTo(x => "error").Map();
            Assert.AreEqual("5 > 3", result);
        }

        [TestCase]
        public void MapToMatchedOnNone()
        {
            var result = Option<int>.None().When(x => true).MapTo(x => "error").WhenNone().MapTo(() => "success")
                .Map();
            Assert.AreEqual("success", result);
        }

        [TestCase]
        public void UnmatchedMapToFailsOnSome()
        {
            Assert.Catch<InvalidOperationException>(() => Option<int>.For(5).When(x => x > 6)
                .MapTo(x => "error").WhenNone().MapTo(() => "error").Map());
        }

        [TestCase]
        public void UnmatchedMapToFailOnNone()
        {
            Assert.Catch<InvalidOperationException>(() => Option<int>.None().WhenValue().MapTo(x => "error")
                .Map());
        }
    }
}