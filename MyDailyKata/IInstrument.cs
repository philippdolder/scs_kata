using System;

namespace MyDailyKata
{
    public interface IInstrument
    {
        void Execute(string task);

        event EventHandler Finished;
        event EventHandler Error;
    }

    public class Instrument : IInstrument
    {
        public void Execute(string task)
        {
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}