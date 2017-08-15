using System;
using FluentAssertions;
using Xunit;

namespace MyDailyKata
{
    //todo:
    //give null expect passing exception to caller
    //give task expect fnished event
    // 




    public class InstrumentProcessorFact
    {
        private readonly InstrumentProcessor _testee;
        private readonly InstrumentStub _instrument;
        private readonly TaskDispatcherStub _dispatcher;

        public InstrumentProcessorFact()
        {
            this._instrument = new InstrumentStub();
            this._dispatcher = new TaskDispatcherStub();
            this._testee = new InstrumentProcessor(this._dispatcher, this._instrument);
        }

        [Fact]
        public void ExecutesNextTaskOnInstrument()
        {
            const string Task = "Task";
            this._dispatcher.Add(Task);

            this._testee.Process();

            this._instrument.ExecutedTask.Should().Be(Task);
        }

        [Fact]
        public void TaskExecutedSuccessfully_FinishedEventOccurred()
        {
            //arrange
            const string Task = "Task";
            this._dispatcher.Add(Task);

            this._testee.Process();
            this._instrument.RaiseFinished();

            this._dispatcher.LastFinishedTask.Should().Be(Task);
        }

        private class InstrumentStub : IInstrument
        {
            public string ExecutedTask { get; private set; }

            public void Execute(string task)
            {
                this.ExecutedTask = task;
            }

            public event EventHandler Finished = delegate { };
            public event EventHandler Error = delegate { };

            public void RaiseFinished()
            {
                this.Finished(null, EventArgs.Empty);
            }
        }

        private class TaskDispatcherStub : ITaskDispatcher
        {
            private string task;
            public string LastFinishedTask { get; set; }

            public string GetTask()
            {
                return this.task;
            }

            public void FinishedTask(string task)
            {
                this.LastFinishedTask = task;
            }

            public void Add(string task)
            {
                this.task = task;
            }
        }
    }
}