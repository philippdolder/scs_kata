using System;

namespace MyDailyKata
{
    public class TimeTracker : ITimeTracker
    {
        private readonly IProvideTime _timeProvider;
        private readonly IWorkingTimeStore _workingTimeStore;
        private readonly IWorkingTimeCalculator _workingTimeCalculator;

        public TimeTracker(
            IProvideTime timeProvider, 
            IWorkingTimeStore workingTimeStore, 
            IWorkingTimeCalculator workingTimeCalculator)
        {
            this._timeProvider = timeProvider;
            this._workingTimeStore = workingTimeStore;
            this._workingTimeCalculator = workingTimeCalculator;
        }

        public void CheckIn()
        {
            this._workingTimeStore.ClockIn(this._timeProvider.Now);
        }

        public void CheckOut()
        {
            this._workingTimeStore.ClockOut(this._timeProvider.Now);
        }

        public TimeSpan GetWorkingHours()
        {
            return this._workingTimeCalculator.CalculateWorkingHours(this._workingTimeStore.TimeElements);
        }
    }
}