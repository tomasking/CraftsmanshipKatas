namespace CraftsmanKata.TicTacToeKata
{
    internal struct Turn
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
}