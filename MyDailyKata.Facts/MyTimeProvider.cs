using System;

namespace MyDailyKata
{
    public class MyTimeProvider : IProvideTime
    {
        public DateTime Now { get; private set; }

        public void Set(DateTime dateTime)
        {
            this.Now = dateTime;
        }
    }
}