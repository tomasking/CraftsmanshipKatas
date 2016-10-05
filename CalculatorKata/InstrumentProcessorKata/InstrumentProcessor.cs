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
            try { 
                instrument.Error += InstrumentOnError();
                instrument.Finished += InstrumentOnFinished(task);
                instrument.Execute(task);
            }
            finally
            {
                instrument.Error += InstrumentOnError();
                instrument.Finished -= InstrumentOnFinished(task);
            }
        }

        private EventHandler InstrumentOnFinished(string task)
        {
            return (_, __) =>
            {
                taskDispatcher.FinishedTask(task);
            };
        }

        private EventHandler InstrumentOnError()
        {
            return (_, __) =>
            {
                Console.WriteLine("Error occured"); // TODO: to be able to test this, needs to be wrapped in another mockable class
            };
        }
    }
}