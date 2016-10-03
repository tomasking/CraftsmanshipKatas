using CraftsmanKata.BowlingGameKata;
using FluentAssertions;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests.BowlingGameTests
{
    [TestFixture]
    public class BowlingGameShould
    {
        [Test]
        public void OutputZero_GivenPersonMissesEveryGo()
        {
            string input = "--|--|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(0);
        }

        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|1-|1-||", 10)]
        [TestCase("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90)]
        public void OutputSumOfFirstShot_GivenPersonScoresOnlyOnTheirFirstBall(string input, int expectedOutput)
        {
            int result = new BowlingGame().Calculate(input);

            result.Should().Be(expectedOutput);
        }

        [Test]
        public void Output1_GivenPersonHits1WithTheirSecondBallOfFirstFrame()
        {
            string input = "-1|--|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(1);
        }

        [Test]
        public void Outputs10_GivenPersonOnlyHitsSpareOnTheirFirstFrame()
        {
            string input = "-/|--|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(10);
        }

        [TestCase("-/|1-|--|--|--|--|--|--|--|--||", 12)]
        [TestCase("1/|1-|--|--|--|--|--|--|--|--||", 12)]
        [TestCase("1/|11|--|--|--|--|--|--|--|--||", 13)]
        [TestCase("1/|1-|--|1/|1-|--|--|--|--|--||", 24)]
        public void OutputsMutlipleForVeryNextBall_GivenPersonHasHitASpareInPreviousFrame(string input, int expectedOutput)
        {
            int result = new BowlingGame().Calculate(input);

            result.Should().Be(expectedOutput);
        }

        [Test]
        public void Outputs10ForStrike_GivenOneStrikeInFirstFrame()
        {
            string input = "X|--|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(10);
        }

        [Test]
        public void OutputsDoubleForBowl_GivenStrikeWithPreviousTurn()
        {
            string input = "X|1-|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(12);
        }

        [Test]
        public void OutputsDoubleForBowl_GivenStrike2TurnsAgo()
        {
            string input = "X|-1|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(12);
        }

        [Test]
        public void OutputsCorrectScore_Given2StrikesInARow()
        {
            string input = "X|X|--|--|--|--|--|--|--|--||";

            int result = new BowlingGame().Calculate(input);

            result.Should().Be(30);
        }
    }
}
