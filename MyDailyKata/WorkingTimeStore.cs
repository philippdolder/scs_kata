using System;
using System.Collections.Generic;

namespace MyDailyKata
{
    public class WorkingTimeStore : IWorkingTimeStore
    {
        private List<Tuple<string, DateTime>> timeElements;

        public WorkingTimeStore()
        {
            this.timeElements = new List<Tuple<string, DateTime>>();
        }

        public void ClockIn(DateTime clockInTime)
        {

        }

        public void ClockOut(DateTime clockOutTime)
        {

        }

        public IReadOnlyCollection<Tuple<string, DateTime>> TimeElements => this.timeElements;
    }
}
