using System;
using System.Collections.Generic;

namespace MyDailyKata
{
    public class WorkingTimeCalculator : IWorkingTimeCalculator
    {
        public TimeSpan CalculateWorkingHours(IReadOnlyCollection<Tuple<string, DateTime>> timeEntries)
        {
            return new TimeSpan();
        }
    }
}
