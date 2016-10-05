using System;
using CraftsmanKata.InstrumentProcessorKata;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests.InstrumentProcessorTests
{
    [TestFixture]
    public class InstrumentProcessorShould
    {
       /* [Test]
        public void FireFinishedEvent_WhenProcessCompletesSuccessfully()
        {
            IInstrument instrument = Substitute.For<IInstrument>();
            ITaskDispatcher taskDispatcher = Substitute.For<ITaskDispatcher>();

            instrument
                .WhenForAnyArgs(i => i.Execute(Arg.Any<string>()))
                .Do(_ =>
                {
                    instrument.Finished += Raise.EventWith(this, EventArgs.Empty);
                });
            var finishedEventWasRaised = false;
            instrument.Finished += (sender, args) => finishedEventWasRaised = true;
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher);

            instrumentProcessor.Process();

            finishedEventWasRaised.Should().BeTrue();
        }*/

        [Test]
        public void ThrowArgumentNullException_WhenTheTaskPassedIsNull()
        {
            var taskDispatcher = Substitute.For<ITaskDispatcher>();
            taskDispatcher.GetTask().Returns((string)null);
            IInstrument instrument = Substitute.For<IInstrument>();
            instrument
                .When(i => i.Execute(null))
                .Throw(new ArgumentNullException("task"));
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrument);

            Action invalidProcessing = () => instrumentProcessor.Process();

            invalidProcessing
              .ShouldThrow<ArgumentNullException>()
              .WithMessage("Value cannot be null.\r\nParameter name: task");
        }
    }
}

