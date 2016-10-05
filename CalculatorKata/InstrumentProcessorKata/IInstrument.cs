using System;

namespace CraftsmanKata.InstrumentProcessorKata
{
    public interface IInstrument
    {
        void Execute(string task);

        event EventHandler Finished;

        event EventHandler Error;
    }
}