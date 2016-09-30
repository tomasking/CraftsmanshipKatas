using CraftsmanKata.TicTacToeKata;
using FluentAssertions;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests.TicTacToeKataTests
{
    [TestFixture]
    public class TicTacToeShould
    {
        [Test]
        public void ResultsInTheSameGame_GivenNeitherGameHasStarted()
        {
            var firstGame = new TicTacToeGame();
            var secondGame = new TicTacToeGame();

            var areEqual = firstGame.Equals(secondGame);

            areEqual.Should().BeTrue();
        }

        [Test]
        public void ResultInDifferentGames_GivenPlayerHasTakenTurnInOneGameAndNotTheOther()
        {
            var unplayed = new TicTacToeGame();
            var played = new TicTacToeGame();
            played.TakeTurn(Column.Left, Row.Top);

            var areEqual = played.Equals(unplayed);

            areEqual.Should().BeFalse();
        }

        [Test]
        public void ResultInDifferentGames_GivenTheFirstGameHasHadOneGoAndTheSecondGameHasHAdTwoGoes()
        {
            var firstGame = new TicTacToeGame();
            var secondGame = new TicTacToeGame();
            firstGame.TakeTurn(Column.Left, Row.Top);
            secondGame.TakeTurn(Column.Left, Row.Top);
            secondGame.TakeTurn(Column.Left, Row.Top);

            var areEqual = firstGame.Equals(secondGame);

            areEqual.Should().BeFalse();
        }

        [Test]
        public void ResultsInDifferentGames_GivenADifferentFirstMoveOnBothGames()
        {
            var firstGame = new TicTacToeGame();
            var secondGame = new TicTacToeGame();
            firstGame.TakeTurn(Column.Left, Row.Top);
            secondGame.TakeTurn(Column.Middle, Row.Top);

            var areEqual = firstGame.Equals(secondGame);

            areEqual.Should().BeFalse();
        }

        [Test]
        public void
            ResultsInDiffentGames_GivenInBothGamesBothPlayersHaveGoneInTheSamePositionsButAnAlternatePlayerInEachGame()
        {
            var firstGame = new TicTacToeGame();
            firstGame.TakeTurn(Column.Left, Row.Top);
            firstGame.TakeTurn(Column.Middle, Row.Top);

            var secondGame = new TicTacToeGame();
            secondGame.TakeTurn(Column.Middle, Row.Top);
            secondGame.TakeTurn(Column.Left, Row.Top);

            var areEqual = firstGame.Equals(secondGame);

            areEqual.Should().BeFalse();
        }

        [Test]
        public void ResultsInTheSameGame_GivenTwoGamesWhereThePlayersHavePlayedTheSameMoves()
        {
            var firstGame = PlayCompleteGame();
            var secondGame = PlayCompleteGame();

            var areEqual = firstGame.Equals(secondGame);

            areEqual.Should().BeTrue();
        }

        private static TicTacToeGame PlayCompleteGame()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Left, Row.Top);
            game.TakeTurn(Column.Middle, Row.Top);
            game.TakeTurn(Column.Right, Row.Top);
            game.TakeTurn(Column.Left, Row.Center);
            game.TakeTurn(Column.Middle, Row.Center);
            game.TakeTurn(Column.Right, Row.Center);
            game.TakeTurn(Column.Left, Row.Bottom);
            game.TakeTurn(Column.Middle, Row.Bottom);
            game.TakeTurn(Column.Right, Row.Bottom);
            return game;
        }
    }
}
