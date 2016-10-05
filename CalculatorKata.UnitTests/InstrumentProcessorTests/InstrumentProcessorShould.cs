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
        private ITaskDispatcher taskDispatcher;

        private IInstrument instrument;

        private InstrumentProcessor instrumentProcessor;

        [SetUp]
        public void Setup()
        {
            taskDispatcher = Substitute.For<ITaskDispatcher>();
            instrument = Substitute.For<IInstrument>();
            instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrument);
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheTaskPassedIsNull()
        {
            taskDispatcher.GetTask().Returns((string)null);
            instrument
                .When(i => i.Execute(null))
                .Throw(new ArgumentNullException("task"));
         
            Action invalidProcessing = () => instrumentProcessor.Process();

            invalidProcessing
              .ShouldThrow<ArgumentNullException>()
              .WithMessage("Value cannot be null.\r\nParameter name: task");
        }

        [Test]
        public void FireFinishedEvent_WhenProcessCompletesSuccessfully()
        {
            instrument.WhenForAnyArgs(i => i.Execute(Arg.Any<string>())).Do(
                _ =>
                    {
                        instrument.Finished += Raise.EventWith(this, EventArgs.Empty);
                    });
            var finishedEventWasRaised = false;
            instrument.Finished += (sender, args) => finishedEventWasRaised = true;

            instrumentProcessor.Process();

            finishedEventWasRaised.Should().BeTrue();
        }

        [Test]
        public void CallTaskDispatchersFinishedTask_WhenProcessCompletesSuccessfully()
        {
            instrument.WhenForAnyArgs(i => i.Execute(Arg.Any<string>())).Do(
                _ =>
                {
                    instrument.Finished += Raise.EventWith(this, EventArgs.Empty);
                });
            taskDispatcher.GetTask().Returns("task1");

            instrumentProcessor.Process();

            taskDispatcher.Received().FinishedTask("task1");
        }

        [Test]
        public void ThrowAnError_WhenInstrumentFailsToExecute()
        {
            instrument
                .WhenForAnyArgs(i => i.Execute(string.Empty))
                .Throw(new Exception("BOOM"));

            Action invalidProcessing = () => instrumentProcessor.Process();

            invalidProcessing
              .ShouldThrow<Exception>()
              .WithMessage("BOOM");
        }
    }
}

