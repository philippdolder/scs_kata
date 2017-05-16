using System;
using FluentAssertions;
using Xbehave;

namespace MyDailyKata
{
    public class TimeManagementSpecs
    {
        [Scenario]
        public void WorkingHoursOfaWorkingDay(
            ITimeTracker timeTracker, 
            MyTimeProvider timeProvider, 
            TimeSpan workingHours,
            IWorkingTimeStore workingTimeStore,
            IWorkingTimeCalculator workingTimeCalculator)
        {
            "Given a running Systems".x(() =>
            {
                timeProvider = new MyTimeProvider();
                workingTimeCalculator = new WorkingTimeCalculator();
                workingTimeStore = new WorkingTimeStore();
                timeTracker = new TimeTracker(timeProvider, workingTimeStore, workingTimeCalculator);
            });

            "Given a Morning Shift".x(() =>
            {
                timeProvider.Set(6.January(2017).At(7.Hours()));
                timeTracker.CheckIn();
                timeProvider.Set(6.January(2017).At(12.Hours()));
                timeTracker.CheckOut();
            });

            "Given a afternoon Shift".x(() =>
            {
                timeProvider.Set(6.January(2017).At(13.Hours()));
                timeTracker.CheckIn();
                timeProvider.Set(6.January(2017).At(17.Hours()));
                timeTracker.CheckOut();
            });

            "When retrieving working hours".x(() =>
            {
                workingHours = timeTracker.GetWorkingHours();
            });

            "Then total hours are correct".x(() =>
            {
                workingHours.Should().Be(9.Hours());
            });
        }
    }
}