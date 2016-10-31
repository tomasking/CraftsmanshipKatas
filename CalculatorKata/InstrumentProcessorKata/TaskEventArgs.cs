using System;

namespace CraftsmanKata.InstrumentProcessorKata
{
    public class TaskEventArgs : EventArgs
    {
        public string Task { get; private set; }

        public TaskEventArgs(string task)
        {
            Task = task;
        }
    }
}