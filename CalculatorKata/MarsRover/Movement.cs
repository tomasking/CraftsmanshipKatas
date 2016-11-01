namespace CraftsmanKata.MarsRover
{
    public class Movement : IMovement
    {
        public static char Left = 'L';
        public static char Right = 'R';
        public static char Move = 'M';

        public Coordinates MoveForward(Coordinates currentCoordinates, string currentDirection)
        {
            int x = currentCoordinates.X;
            int y = currentCoordinates.Y;
            if (currentDirection == Direction.North)
            {
                currentCoordinates.MoveNorth();
            }

            if (currentDirection == Direction.South)
            {
                currentCoordinates.MoveSouth();
            }

            if (currentDirection == Direction.East)
            {
                currentCoordinates.MoveEast();
            }

            if (currentDirection == Direction.West)
            {
                currentCoordinates.MoveWest();
            }

            return new Coordinates(x, y);
        }
    }
}