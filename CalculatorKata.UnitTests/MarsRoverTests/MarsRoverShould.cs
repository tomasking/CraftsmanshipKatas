using CraftsmanKata.MarsRover;
using FluentAssertions;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests.MarsRoverTests
{
    [TestFixture]
    public class MarsRoverShould
    {
        private MarsRover.MarsRover _marsRover;

        [SetUp]
        public void Setup()
        {
            _marsRover = new MarsRover.MarsRover(new Directions());
        }

        [TestCase("0 0 N")]
        [TestCase("1 1 N")]
        public void ReturnSameStartingPositionAndDirection_GivenNoMovement(string startingPosition)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, "");

            finalPosition.Should().Be(startingPosition);
        }

        [TestCase("M", "0 1 N")]
        [TestCase("MM", "0 2 N")]
        [TestCase("MMM", "0 3 N")]
        public void NewPosition_WhenMoving_GivenFacingNorthAndStartingAtTheLowerLeft(string movements, string expectedEndpoint)
        {
            var finalPosition = _marsRover.Explore("4 4", "0 0 N", movements);

            finalPosition.Should().Be(expectedEndpoint);
        }

        [Test]
        public void NewPostion_WhenMoving_GivenFacingEast()
        {
            var finalPosition = _marsRover.Explore("4 4", "0 0 E", "M");

            finalPosition.Should().Be("1 0 E");
        }

        [TestCase("M", "1 1 N", "1 2 N")]
        [TestCase("M", "2 2 N", "2 3 N")]
        [TestCase("MM", "1 1 N", "1 3 N")]
        public void MoveToNewPosition_WhenMoving_GivenFacingNorthAndStartingInTheMiddle(string movements, string startingPosition, string expectedFinalPosition)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, movements);

            finalPosition.Should().Be(expectedFinalPosition);
        }

        [TestCase("M", "1 1 E", "2 1 E")]
        [TestCase("M", "2 2 E", "3 2 E")]
        [TestCase("MM", "1 1 E", "3 1 E")]
        public void MoveToNewPosition_WhenMoving_GivenFacingEastAndStartingInTheMiddle(string movements, string startingPosition, string expectedFinalPosition)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, movements);

            finalPosition.Should().Be(expectedFinalPosition);
        }

        [TestCase("M", "3 3 S", "3 2 S")]
        [TestCase("M", "2 2 S", "2 1 S")]
        [TestCase("MM", "3 3 S", "3 1 S")]
        public void MoveToNewPosition_WhenMoving_GivenFacingSouthAndStartingInTheMiddle(string movements, string startingPosition, string expectedFinalPosition)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, movements);

            finalPosition.Should().Be(expectedFinalPosition);
        }

        [TestCase("M", "3 3 W", "2 3 W")]
        [TestCase("M", "2 2 W", "1 2 W")]
        [TestCase("MM", "3 3 W", "1 3 W")]
        public void MoveToNewPosition_WhenMoving_GivenFacingWestAndStartingInTheMiddle(string movements, string startingPosition, string expectedFinalPosition)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, movements);

            finalPosition.Should().Be(expectedFinalPosition);
        }

        [TestCase("R", "1 1 N", "1 1 E")]
        [TestCase("RR", "1 1 N", "1 1 S")]
        [TestCase("RRR", "1 1 N", "1 1 W")]
        [TestCase("RRRR", "1 1 N", "1 1 N")]
        [TestCase("L", "1 1 N", "1 1 W")]
        [TestCase("LL", "1 1 N", "1 1 S")]
        [TestCase("LLL", "1 1 N", "1 1 E")]
        [TestCase("LLLL", "1 1 N", "1 1 N")]
        public void ChangeDirection_WhenMovementsContainDirectionChange(string movements, string startingPosition, string expectedFinalPosition)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, movements);

            finalPosition.Should().Be(expectedFinalPosition);
        }

        [TestCase("0 0 N", "RM", "1 0 E")]
        [TestCase("1 1 N", "RM", "2 1 E")]
        [TestCase("2 2 N", "RM", "3 2 E")]
        [TestCase("1 1 E", "RM", "1 0 S")]
        [TestCase("1 1 S", "RM", "0 1 W")]
        [TestCase("1 1 W", "RM", "1 2 N")]
        [TestCase("1 1 W", "RMM", "1 3 N")]
        [TestCase("1 1 W", "RMMM", "1 4 N")]
        [TestCase("1 1 N", "MRMRMRMR", "1 1 N")]
        public void ChangeDirectionAndMove_WhenMovementsContainDirectionChangeAndMove(string startingPosition, string movements, string expected)
        {
            var finalPosition = _marsRover.Explore("4 4", startingPosition, movements);

            finalPosition.Should().Be(expected);
        }
    }
}
