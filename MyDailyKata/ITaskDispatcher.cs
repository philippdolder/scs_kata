namespace MyDailyKata
{
    public interface ITaskDispatcher
    {
        string GetTask();
        void FinishedTask(string task);
    }

    public class TaskDispatcher : ITaskDispatcher
    {
        public string GetTask()
        {
            return null;
        }

        public void FinishedTask(string task)
        {
        }
    }
}