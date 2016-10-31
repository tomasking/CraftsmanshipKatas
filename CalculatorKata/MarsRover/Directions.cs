using System;

namespace CraftsmanKata.MarsRover
{
    public class Directions : IDirections
    {
        public static string North = "N";
        public static string East = "E";
        public static string South = "S";
        public static string West = "W";

        private readonly string[] orderedDirections = { North, East, South, West};

        public string TurnLeft(string currentDirection)
        {
            var currentDirectionIndex = Array.IndexOf(orderedDirections, currentDirection);
            var nextDirection = currentDirectionIndex - 1;
            if (nextDirection == -1)
            {
                nextDirection = 3;
            }
            return orderedDirections[nextDirection];
        }

        public string TurnRight(string currentDirection)
        {
            var currentDirectionIndex = Array.IndexOf(orderedDirections, currentDirection);
            var nextDirection = currentDirectionIndex + 1;
            if (nextDirection == 4)
            {
                nextDirection = 0;
            }
            return orderedDirections[nextDirection];
        }
    }
}