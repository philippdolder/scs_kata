using System;

namespace MyDailyKata
{
    public interface ITimeTracker
    {
        void CheckIn();
        void CheckOut();
        TimeSpan GetWorkingHours();
    }
}