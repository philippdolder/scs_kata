using System;
using System.Collections.Generic;

namespace MyDailyKata
{
    public interface IWorkingTimeStore
    {
        void ClockIn(DateTime clockInTime);
        void ClockOut(DateTime cloutOutTime);
        IReadOnlyCollection<Tuple<string, DateTime>> TimeElements { get; }
    }
}