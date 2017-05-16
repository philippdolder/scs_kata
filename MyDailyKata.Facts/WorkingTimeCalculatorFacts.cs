using FluentAssertions;
using Xunit;

namespace MyDailyKata
{
    public class WorkingTimeCalculatorFacts
    {
        private readonly WorkingTimeCalculator _testee;

        public WorkingTimeCalculatorFacts()
        {
            this._testee = new WorkingTimeCalculator();
        }

        // TODO with checkin and checkout => time span
        // TODO with only checkin => duration till now
        // TODO with two blocks => time span
    }
}