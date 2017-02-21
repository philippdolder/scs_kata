using System;
using System.Threading;

namespace MyDailyKata
{
    public class WebTime
    {
        private readonly IProvideTime _timeProvider;

        private DateTime _checkIn;
        private DateTime? _checkOut;

        public WebTime(IProvideTime timeProvider)
        {
            this._timeProvider = timeProvider;

        }

        public bool IsWorking => this._checkOut == null;

        public TimeSpan GetWorkingHours()
        {
            if (IsWorking)
            {
                return this._timeProvider.Now - this._checkIn;
            }
            return this._checkOut.Value - this._checkIn;
        }

        public void ClockOut()
        {
            this._checkOut = this._timeProvider.Now;
        }

        public void ClockIn()
        {
            this._checkIn = this._timeProvider.Now;
            this._checkOut = null;
        }
    }
}