namespace CraftsmanKata.MarsRover
{
    public class MarsRover
    {
        private readonly IDirection direction;
        private readonly IMovement movement;

        public MarsRover(IDirection direction, IMovement movement)
        {
            this.direction = direction;
            this.movement = movement;
        }

        public string Explore(string upperRightBoundary, string startingPosition, string movements)
        {
            var currentCoordinates = Coordinates.StartingCoordinates(startingPosition);
            var currentDirection = Direction.StartingDirection(startingPosition);

            foreach (var moves in movements)
            {
                if (moves == Movement.Left)
                {
                    currentDirection = direction.TurnLeft(currentDirection);
                }

                if (moves == Movement.Right)
                {
                    currentDirection = direction.TurnRight(currentDirection);
                }

                if (moves == Movement.Move)
                {
                    movement.MoveForward(currentCoordinates, currentDirection);
                }
            }
            
            return FormatEndingPosition(currentCoordinates.X, currentCoordinates.Y, currentDirection);
        }

        private static string FormatEndingPosition(int x, int y, string finalDirection)
        {
            return $"{x} {y} {finalDirection}";
        }
    }
}
