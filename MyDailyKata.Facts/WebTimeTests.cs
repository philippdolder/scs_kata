using System;
using System.Threading;
using FluentAssertions;
using Moq;
using Xunit;

namespace MyDailyKata
{
    public class WebTimeTests
    {
        private IProvideTime timeProvider;
        private WebTime _testee;

        public WebTimeTests()
        {
            this.timeProvider = Mock.Of<IProvideTime>();
            this._testee = new WebTime(this.timeProvider);
        }


        [Fact]
        public void NormalWorkingDay_CheckInAndOut_ExpectActualAmountOfTime()
        {
            // Act
            this.SetTime(8.Hours());
            this._testee.ClockIn();
            this.SetTime(12.Hours());
            this._testee.ClockOut();
            var returnedTime = this._testee.GetWorkingHours();

            // Assert
            returnedTime.Should().Be(4.Hours());
        }

        private void SetTime(TimeSpan time, int x = 5)
        {
            Mock.Get(this.timeProvider).Setup(t => t.Now).Returns(x.January(2017).At(time));
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
            this.SetTime(9.Hours());
            this._testee.ClockIn();
            this.SetTime(12.Hours());

            var workingHours = this._testee.GetWorkingHours();

            workingHours.Should().Be(3.Hours());
        }

        [Fact]
        public void WhenClockInBefore12am_AndClockOutAfter12am_ElapsedTimeExpected()
        {
            this.SetTime(23.Hours(),5);
            this._testee.ClockIn();
            this.SetTime(1.Hours(), 6);

            var workingHours = this._testee.GetWorkingHours();

            workingHours.Should().Be(2.Hours());
        }
    }
}