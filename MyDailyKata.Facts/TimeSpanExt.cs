using System;
using FluentAssertions;

namespace MyDailyKata
{
    public static class TimeSpanExt
    {
        public static TimeSpan Tomorrow(this TimeSpan timeSpan)
        {
            return timeSpan.Add(1.Days());
        }

        public static TimeSpan Yesterday(this TimeSpan timeSpan)
        {
            return timeSpan.Add(-1.Days());
        }
    }
}