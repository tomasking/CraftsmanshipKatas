namespace CraftsmanKata.InstrumentProcessorKata
{
    public interface ITaskDispatcher
    {
        string GetTask();

        void FinishedTask(string tast);
    }
}