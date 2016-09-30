using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CraftsmanKata.TicTacToeKata
{
    public class TicTacToeGame
    {
        private int numberOfTurns = 0;

        readonly IList<Turn> turnsTaken = new List<Turn>();

        public void TakeTurn(Column column, Row row)
        {
            var currentSymbol = Symbol.X;
            if (numberOfTurns %2 == 1)
            {
                currentSymbol = Symbol.O;
            }

            var turn = new Turn(column, row, currentSymbol);
            turnsTaken.Add(turn);
            numberOfTurns++;
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

        private struct Turn
        {
            private readonly Column column;
            private readonly Row row;
            private readonly Symbol symbol;

            public Turn(Column column, Row row, Symbol symbol)
            {
                this.column = column;
                this.row = row;
                this.symbol = symbol;
            }
        }

        public enum Symbol
        {
            X,
            O
        }
    }
}