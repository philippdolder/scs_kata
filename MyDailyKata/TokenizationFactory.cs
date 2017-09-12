using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDailyKata
{
    public class TokenizationFactory : ITokenizationFactory
    {
        public List<Token> SeperateCalculation(string input)
        {
            var result = new List<Token>();

            var numbers = input.Split('+');

            foreach (var  number in numbers)
            {
                result.Add(new Operator('+'));
                result.Add(new Number(Convert.ToInt32(number)));
            }
            result.RemoveAt(result.Count - 1);

            return result;
        }
    }
}