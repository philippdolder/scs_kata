using System;
using FluentAssertions;
using Moq;
using Xbehave;

namespace MyDailyKata
{
    public class WebTimeSpec
    {
        [Scenario()]
        public void NineToFiveWeekDay(WebTime webTime, IProvideTime timeProvider)
        {
            "Given a time management".x(() =>
                {
                    timeProvider = Mock.Of<IProvideTime>();
                    webTime = new WebTime(timeProvider);
                }
            );
            "Given a person comes at 9".x(() =>
                {
                    Mock.Get(timeProvider).Setup(a => a.Now).Returns(9.January(2017).At(9.Hours()));
                    webTime.ClockIn();

                }
            );

            "Given a person leaves 5".x(() =>
                {
                    Mock.Get(timeProvider).Setup(a => a.Now).Returns(9.January(2017).At(17.Hours()));
                    webTime.ClockOut();
                }
            );

            "Then the peson has worked 8 hours".x(() =>
                {
                    var timeWorked = webTime.GetWorkingHours();
                    timeWorked.Should().Be(8.Hours());
                }
            );

        }
    }
}