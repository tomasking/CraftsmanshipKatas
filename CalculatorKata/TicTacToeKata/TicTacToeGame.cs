using System;
using System.Collections.Generic;
using System.Linq;

namespace CraftsmanKata.TicTacToeKata
{
    public class TicTacToeGame
    {
        private int numberOfTurns;

        readonly IList<Turn> turnsTaken = new List<Turn>();

        public void TakeTurn(Column column, Row row)
        {
            var currentSymbol = SelectCurrentSymbol();
            var turn = new Turn(column, row, currentSymbol);
            turnsTaken.Add(turn);
            numberOfTurns++;
        }

        public GameStatus GetGameStatus()
        {
            if (numberOfTurns == 9)
            {
                return GameStatus.Draw;
            }
            
            if (IsWinningPlayer(Symbol.X))
            {
                return GameStatus.PlayerOneWinner;
            }

            if (IsWinningPlayer(Symbol.O))
            {
                return GameStatus.PlayerTwoWinner;
            }

            return GameStatus.InProgress;
        }

        private Symbol SelectCurrentSymbol()
        {
            var currentSymbol = Symbol.X;
            if (numberOfTurns%2 == 1)
            {
                currentSymbol = Symbol.O;
            }

            return currentSymbol;
        }

        private bool IsWinningPlayer(Symbol symbol)
        {
            if (HasAWinningRow(symbol) || HasAWinningColumn(symbol) || IsWinningDiagonal(symbol))
            {
                return true;
            }

            return false;
        }

        private bool HasAWinningRow(Symbol symbol)
        {
            foreach (var row in Enum.GetValues(typeof(Row)))
            {
                if (IsWinningRow(symbol, row)) return true;
            }

            return false;
        }

        private bool IsWinningRow(Symbol symbol, object row)
        {
            if (turnsTaken.Contains(new Turn(Column.Left, (Row) row, symbol))
                && turnsTaken.Contains(new Turn(Column.Middle, (Row) row, symbol))
                && turnsTaken.Contains(new Turn(Column.Right, (Row) row, symbol)))
            {
                return true;
            }

            return false;
        }

        private bool HasAWinningColumn(Symbol symbol)
        {
            foreach (var column in Enum.GetValues(typeof(Column)))
            {
                if (IsWinningColumn(symbol, column)) return true;
            }

            return false;
        }

        private bool IsWinningColumn(Symbol symbol, object column)
        {
            if (turnsTaken.Contains(new Turn((Column) column, Row.Top, symbol))
                && turnsTaken.Contains(new Turn((Column) column, Row.Center, symbol))
                && turnsTaken.Contains(new Turn((Column) column, Row.Bottom, symbol)))
            {
                return true;
            }

            return false;
        }

        private bool IsWinningDiagonal(Symbol symbol)
        {
            if (!turnsTaken.Contains(new Turn(Column.Middle, Row.Center, symbol)))
            {
                return false;
            }

            if ((turnsTaken.Contains(new Turn(Column.Left, Row.Top, symbol))
                && turnsTaken.Contains(new Turn(Column.Right, Row.Bottom, symbol))) ||
                (turnsTaken.Contains(new Turn(Column.Right, Row.Top, symbol))
                && turnsTaken.Contains(new Turn(Column.Left, Row.Bottom, symbol))))
            {
                return true;
            }

            return false;
        }

        protected bool Equals(TicTacToeGame other)
        {
            if (turnsTaken.Count != other.turnsTaken.Count)
            {
                return false;
            }

            return turnsTaken.All(turn => other.turnsTaken.Contains(turn));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TicTacToeGame) obj);
        }

        public override int GetHashCode()
        {
            return (turnsTaken != null ? turnsTaken.GetHashCode() : 0);
        }
    }
}