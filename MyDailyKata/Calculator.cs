using System;
using System.Linq;

namespace MyDailyKata
{
    public class Calculator : ICalculator
    {
        private ITokenizationFactory _tokenizationFactory;

        public Calculator(ITokenizationFactory tokenizationFactory)
        {
            this._tokenizationFactory = tokenizationFactory;
        }

        public int Calculate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var tokens = this._tokenizationFactory.SeperateCalculation(input);

            if (tokens.Count == 1)
            {
                return (tokens[0] as Number).Value;
            }

            var result = 0;

            foreach (var token in tokens)
            {
                
            }

            return result;
//            return input.Split('+').Sum(number => Convert.ToInt32(number));
        }
    }
}