using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MyDailyKata
{
    public class RomanCalculatorTest
    {
        private readonly RomanCalculator _testee;
        // 1-3000
        // TODO: 10-99
        public RomanCalculatorTest()
        {
            this._testee = new RomanCalculator();
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        public void ConvertsSingleDigitArabicToRomanNumbers(int arabic, string romanExpected)
        {
            var roman = this._testee.Convert(arabic);

            roman.Should().Be(romanExpected);
        }

        [Theory]
        [InlineData(10, "X")]
        public void ConvertsDoubleDigitArabicToRomanNumbers(int arabic, string romanExpected)
        {
            var roman = this._testee.Convert(arabic);

            roman.Should().Be(romanExpected);
        }
    }

    public class RomanCalculator
    {
        private static readonly Dictionary<int, string> SingleDigitRomanNumbersLookup = new Dictionary<int, string>
        {
            [0] = "",
            [1] = "I",
            [2] = "II",
            [3] = "III",
            [4] = "IV",
            [5] = "V",
            [6] = "VI",
            [7] = "VII",
            [8] = "VIII",
            [9] = "IX",
        };

        private static readonly Dictionary<int, string> DoubleDigitRomanNumbersLookup = new Dictionary<int, string>
        {
            [1] = "X"
        };

        private static readonly Dictionary<int, Func<int, string>> Map = new Dictionary<int, Func<int, string>>
        {
            [0] = x => SingleDigitRomanNumbersLookup[x],
            [1] = x => DoubleDigitRomanNumbersLookup[x]
        };

        public string Convert(int arabic)
        {
            var digits = SplitIntoDigits(arabic);

            string roman = "";
            for (int position = 0; position < digits.Count; position++)
            {
                roman = GetPartialResult(position, digits[position]) + roman;
            }

            return roman;
        }

        private static string GetPartialResult(int digitPosition, int arabicDigit)
        {
            return Map[digitPosition](arabicDigit);
        }

        private static List<int> SplitIntoDigits(int arabic)
        {
            int i = arabic;
            List<int> digits = new List<int>();
            while (i > 0)
            {
                var x = i % 10;
                digits.Add(x);
                i /= 10;
            }
            return digits;
        }
    }
}