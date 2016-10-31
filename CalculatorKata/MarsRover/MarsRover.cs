using System.Linq;

namespace CraftsmanKata.MarsRover
{
    public class MarsRover
    {
        private readonly IDirections directions;

        public MarsRover(IDirections directions)
        {
            this.directions = directions;
        }

        public string Explore(string upperRightBoundary, string startingPosition, string movements)
        {
            var currentCoordinates = Coordinates.StartingCoordinates(startingPosition);
            var currentDirection = StartingDirection(startingPosition);

            foreach (var movement in movements)
            {
                if (movement == 'L')
                {
                    currentDirection = directions.TurnLeft(currentDirection);
                }

                if (movement == 'R')
                {
                    currentDirection = directions.TurnRight(currentDirection);
                }

                if (movement == 'M')
                {
                    currentCoordinates = Move(currentCoordinates, currentDirection);
                }
            }
            
            return EndingPosition(currentCoordinates.X, currentCoordinates.Y, currentDirection);
        }

        private Coordinates Move(Coordinates currentCoordinates, string currentDirection)
        {
            int x = currentCoordinates.X;
            int y = currentCoordinates.Y;
            if (currentDirection == Directions.North)
            {
                y = y + 1;
            }

            if (currentDirection == Directions.South)
            {
                y = y - 1;
            }

            if (currentDirection == Directions.East)
            {
                x = x + 1;
            }

            if (currentDirection == Directions.West)
            {
                x = x - 1;
            }

            return new Coordinates(x, y);
        }

        private static string EndingPosition(int x, int y, string finalDirection)
        {
            return $"{x} {y} {finalDirection}";
        }
        
        private static string StartingDirection(string startingPosition)
        {
            return startingPosition.Split(' ').Last();
        }
    }
}
