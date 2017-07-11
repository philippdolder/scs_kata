using System;
using System.Linq;

namespace MyDailyKata
{
    public class StringCalculator
    {
        private static readonly string[] DefaultSeperator = {";"};
        private readonly string[] CustomSeperator = { "\r\n" };


        public int Add(string input)
        {
            var separator = DefaultSeperator;

            if (input.Contains(this.CustomSeperator.First()))
            {
                var inputLines = input.Split(CustomSeperator, StringSplitOptions.None);
                separator = new [] {inputLines[0]};
                input = inputLines[1];
            }

            return input
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Sum(Convert.ToInt32);
        }
    }
}
