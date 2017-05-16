using System;

namespace MyDailyKata
{
    public interface IProvideTime
    {
        DateTime Now { get; }
    }
}