using System;

namespace CraftsmanKata.MarsRover
{
    public class Coordinates
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static Coordinates StartingCoordinates(string startingPosition)
        {
            var startingPositionParts = startingPosition.Split(' ');
            var startingCoordinatesX = Int32.Parse(startingPositionParts[0]);
            var startingCoordinatesY = Int32.Parse(startingPositionParts[1]);

            return new Coordinates(startingCoordinatesX, startingCoordinatesY);
        }

        public void MoveNorth()
        {
            Y = Y + 1;
        }

        public void MoveSouth()
        {
            Y = Y - 1;
        }

        public void MoveEast()
        {
            X = X + 1;
        }

        public void MoveWest()
        {
            X = X - 1;
        }
    }
}