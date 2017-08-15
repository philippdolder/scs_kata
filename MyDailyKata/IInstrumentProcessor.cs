using System;

namespace MyDailyKata
{
    public interface IInstrumentProcessor
    {
        void Process();
    }

    public class InstrumentProcessor : IInstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;
        private readonly IInstrument _instrument;
        private string _task;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            this._taskDispatcher = taskDispatcher;
            this._instrument = instrument;
        }

        public void Process()
        {
            this._task = this._taskDispatcher.GetTask();

            this._instrument.Finished += this.FinishedHandler;

            this._instrument.Execute(this._task);
        }

        private void FinishedHandler(object sender, EventArgs e)
        {
            this._taskDispatcher.FinishedTask(this._task);
            this._instrument.Finished -= this.FinishedHandler;
        }
    }
}