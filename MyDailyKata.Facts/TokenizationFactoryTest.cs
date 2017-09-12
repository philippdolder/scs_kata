using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MyDailyKata
{
    public class TokenizationFactoryTest
    {
        private TokenizationFactory _testee;

        [SetUp]
        public void SetUp()
        {
            this._testee = new TokenizationFactory();
        }

        [Test]
        public void SimpleValueReturnsNumberToken()
        {
            const string Input = "42";
            var expectedResult = new List<Token>() { new Number(42) };

            var result = this._testee.SeperateCalculation(Input);

            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Test]
        public void AddExpression_ReturnsExpressionTokens()
        {
            const string Input = "42+1+2";
            var expectedResult = new List<Token>()
            {
                new Number(42),
                new Operator('+'),
                new Number(1),
                new Operator('+'),
                new Number(2)
            };

            var result = this._testee.SeperateCalculation(Input);

            result.ShouldBeEquivalentTo(expectedResult);
        }

    }
}