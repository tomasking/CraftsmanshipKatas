using System;

namespace CraftsmanKata.MarsRover
{
    internal struct Coordinates
    {
        public int X { get; }

        public int Y { get; }

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
    }
}