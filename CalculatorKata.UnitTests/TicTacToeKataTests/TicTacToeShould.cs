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
        public void ResultInDifferentGames_GivenTheFirstGameHasHadOneGoAndTheSecondGameHasHadTwoGoes()
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

        [Test]
        public void ReturnInProgress_GivenAGameHasntStarted()
        {
            var game = new TicTacToeGame();

            var status = game.GetGameStatus();

            status.Should().Be(GameStatus.InProgress);
        }

        [Test]
        public void ResultInPlayerOneWinning_GivenTheirSymbolInEveryPositionInTheTopRow()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Left, Row.Top);
            game.TakeTurn(Column.Left, Row.Center);
            game.TakeTurn(Column.Middle, Row.Top);
            game.TakeTurn(Column.Middle, Row.Bottom);
            game.TakeTurn(Column.Right, Row.Top);

            var winner = game.GetGameStatus();

            winner.Should().Be(GameStatus.XWins);
        }

        [Test]
        public void ResultInPlayerTwoWinning_GivenTheirSymbolInEveryPositionInTheTopRow()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Middle, Row.Bottom);
            game.TakeTurn(Column.Left, Row.Top);
            game.TakeTurn(Column.Left, Row.Center);
            game.TakeTurn(Column.Middle, Row.Top);
            game.TakeTurn(Column.Right, Row.Center);
            game.TakeTurn(Column.Right, Row.Top);

            var winner = game.GetGameStatus();

            winner.Should().Be(GameStatus.PlayerTwoWinner);
        }

        [Test]
        public void ResultInPlayerOneWinning_GivenTheirSymbolInEveryPositionInTheMiddleRow()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Left, Row.Center);
            game.TakeTurn(Column.Left, Row.Bottom);
            game.TakeTurn(Column.Middle, Row.Center);
            game.TakeTurn(Column.Middle, Row.Bottom);
            game.TakeTurn(Column.Right, Row.Center);

            var winner = game.GetGameStatus();

            winner.Should().Be(GameStatus.XWins);
        }

        [Test]
        public void ResultInPlayerOneWinning_GivenTheirSymbolInEveryPositionInTheLeftColumn()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Left, Row.Center);
            game.TakeTurn(Column.Middle, Row.Center);
            game.TakeTurn(Column.Left, Row.Bottom);
            game.TakeTurn(Column.Middle, Row.Bottom);
            game.TakeTurn(Column.Left, Row.Top);

            var winner = game.GetGameStatus();

            winner.Should().Be(GameStatus.XWins);
        }

        [Test]
        public void ResultInPlayerOneWinning_GivenTheirSymbolInEveryPositionOnTheDiagonal()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Left, Row.Top);
            game.TakeTurn(Column.Left, Row.Bottom);
            game.TakeTurn(Column.Middle, Row.Center);
            game.TakeTurn(Column.Middle, Row.Bottom);
            game.TakeTurn(Column.Right, Row.Bottom);

            var winner = game.GetGameStatus();

            winner.Should().Be(GameStatus.XWins);
        }

        [Test]
        public void ResultInDraw_GivenNoWinningMoves()
        {
            var game = PlayCompleteGame();

            var winner = game.GetGameStatus();

            winner.Should().Be(GameStatus.Draw);
        }

        /// <summary>
        /// XOX
        /// OOX
        /// XXO
        /// </summary>
        private static TicTacToeGame PlayCompleteGame()
        {
            var game = new TicTacToeGame();
            game.TakeTurn(Column.Left, Row.Top);
            game.TakeTurn(Column.Middle, Row.Top);
            game.TakeTurn(Column.Right, Row.Top);
            game.TakeTurn(Column.Left, Row.Center);
            game.TakeTurn(Column.Right, Row.Center);
            game.TakeTurn(Column.Middle, Row.Center);
            game.TakeTurn(Column.Left, Row.Bottom);
            game.TakeTurn(Column.Right, Row.Bottom);
            game.TakeTurn(Column.Middle, Row.Bottom);
            return game;
        }
    }
}
