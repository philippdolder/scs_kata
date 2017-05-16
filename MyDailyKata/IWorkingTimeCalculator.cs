using System;
using System.Collections.Generic;

namespace MyDailyKata
{
    public interface IWorkingTimeCalculator
    {
        TimeSpan CalculateWorkingHours(IReadOnlyCollection<Tuple<string, DateTime>> timeEntries);
    }
}