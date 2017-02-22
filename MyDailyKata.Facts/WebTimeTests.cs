using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace MyDailyKata
{
    public class WebTimeTests
    {
        private IProvideTime timeProvider;
        private WebTime _testee;
        private DateTime _today;

        public WebTimeTests()
        {
            this._today = 5.January(2017);
            this.timeProvider = Mock.Of<IProvideTime>();
            this._testee = new WebTime(this.timeProvider);
        }

        [Fact]
        public void NormalWorkingDay_CheckInAndOut_ExpectActualAmountOfTime()
        {
            this.When(_ => _.ClockIn(), 8.Hours());
            this.When(_ => _.ClockOut(), 12.Hours());

            var workingHours = this._testee.GetWorkingHours();

            workingHours.Should().Be(4.Hours());
        }
        
        [Fact]
        public void NeverClockInAndNeverClockOut_ExpectZeroWorkingHours()
        {
            //Act
            var workingHours = this._testee.GetWorkingHours();

            //Assert
            workingHours.Should().Be(0.Hours());
        }

        [Fact]
        public void WhenClockIn_ButNotClockOut_ThenExpectElapsedTimeTillNow()
        {
            this.When(_ => _.ClockIn(), 9.Hours());
            this.When(_ => {}, 12.Hours());

            var workingHours = this._testee.GetWorkingHours();

            workingHours.Should().Be(3.Hours());
        }

        [Fact]
        public void WhenClockInBefore12am_AndClockOutAfter12am_ElapsedTimeExpected()
        {
            this.When(_ => _.ClockIn(), 23.Hours());
            this.When(_ => _.ClockOut(), 1.Hours().Tomorrow());

            var workingHours = this._testee.GetWorkingHours();

            workingHours.Should().Be(2.Hours());
        }

        private void When(Action<WebTime> action, TimeSpan time)
        {
            When(action, _today.Add(time));
        }

        private void When(Action<WebTime> action, DateTime datetime)
        {
            SetTime(datetime);
            action(this._testee);
        }

        private void SetTime(DateTime datetime)
        {
            Mock.Get(this.timeProvider).Setup(t => t.Now).Returns(datetime);
        }
    }
}