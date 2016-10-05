using System;

namespace CraftsmanKata.InstrumentProcessorKata
{
    public class InstrumentProcessor 
    {
        private readonly ITaskDispatcher taskDispatcher;
        private readonly IInstrument instrument;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            this.taskDispatcher = taskDispatcher;
            this.instrument = instrument;
        }

        public void Process()
        {
            string task = taskDispatcher.GetTask();

            Console.WriteLine(task);
            
            try
            {
                //instrument.Finished += InstrumentOnFinished(task);
                instrument.Execute(task);
            }
            finally
            {
                //instrument.Finished -= InstrumentOnFinished(task);
            }
        }

        private EventHandler InstrumentOnFinished(string task)
        {
            return (_, __) =>
            {
                taskDispatcher.FinishedTask(task);
            };
        }
    }
}