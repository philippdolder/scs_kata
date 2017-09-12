using FluentAssertions;
using NUnit.Framework;

namespace MyDailyKata
{
    public class CalculatorFact
    {
        private Calculator _testee;
        private ITokenizationFactory _tokenizationFactory;

        [NUnit.Framework.SetUp]
        public void SetUp()
        {
            this._tokenizationFactory = new TokenizationFactory();
            this._testee = new Calculator(this._tokenizationFactory);
        }


        [NUnit.Framework.Test]
        public void InputIsEmpty_ReturnsZero()
        {
            const string EmptyInput = "";

            var result = this._testee.Calculate(EmptyInput);

            result.Should().Be(0);
        }

        [NUnit.Framework.Test]
        public void InputIsNull_ReturnsZero()
        {
            const string InputNull = null;

            var result = this._testee.Calculate(InputNull);

            result.Should().Be(0);
        }

        [NUnit.Framework.Test]
        public void InputIsSingleNumber_ReturnsSameSingleNumber()
        {
            const string SingleNumber = "42";
            const int ExpectedResult = 42;

            var result = this._testee.Calculate(SingleNumber);

            result.Should().Be(ExpectedResult);
        }
 
        [NUnit.Framework.Test]
        public void InputIsAdditionOfTwoNumbers_ReturnsSumOfTheseNumbers()
        {
            const string Input = "42+23";
            const int ExpectedResult = 65;

            var result = this._testee.Calculate(Input);

            result.Should().Be(ExpectedResult);
        }
 
        [NUnit.Framework.Test]
        public void InputIsAdditionOfMoreThanTwoNumbers_ReturnsSumOfTheseNumbers()
        {
            const string Input = "42+23+11+10";
            const int ExpectedResult = 86;

            var result = this._testee.Calculate(Input);

            result.Should().Be(ExpectedResult);
        }

        [Test]
        public void SubtractionOfTwoNumbers_ReturnsSubtractionResult()
        {
            const string Input = "2-1";
            const int ExpectedResult = 1;

            var result = this._testee.Calculate(Input);

            result.Should().Be(ExpectedResult);
        }
    }
}