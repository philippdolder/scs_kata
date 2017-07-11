using FluentAssertions;
using Xunit;

namespace MyDailyKata
{
    public class StringCalculatorTest
    {
        private readonly StringCalculator _testee;

        // TODO: On Single number input -> return this number
        // TODO: Multiple numbers -> returns sum of them

        public StringCalculatorTest()
        {
            this._testee = new StringCalculator();
        }

        [Fact]
        public void EmptyString_ReturnsZero()
        {
            // Arrange
            const string Input = "";

            // Act
            var result = this._testee.Add(Input);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void InputIsANumber_ReturnNumber(string input, int exptectedResult)
        {
            var result = this._testee.Add(input);

            result.Should().Be(exptectedResult);
        }

        [Theory]
        [InlineData("2;3", 5)]
        [InlineData("2;3;5", 10)]
        public void HasMultipleNumbers_ReturnsSum(string input, int expectedResult)
        {
            // Act
            var result = this._testee.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(".\r\n2.3.5", 10)]
        [InlineData("---\r\n2---3---5", 10)]
        [InlineData("2\r\n232425", 12)]
        public void MultipleNumbers_WithSeparatorInFirstLine_SumsAllNumbers(string input, int expected)
        {
            // Act
            var result = this._testee.Add(input);

            // Assert
            result.Should().Be(expected);
        }
    }
}
