using System;
using System.Linq;

namespace CraftsmanKata.MarsRover
{
    public class Direction : IDirection
    {
        public static string North = "N";
        public static string East = "E";
        public static string South = "S";
        public static string West = "W";

        private readonly string[] orderedDirections = { North, East, South, West};

        public string TurnLeft(string currentDirection)
        {
            var nextDirectionIndex = IndexOfCurrentDirection(currentDirection);
            nextDirectionIndex --;
            if (nextDirectionIndex == -1)
            {
                nextDirectionIndex = 3;
            }
            return orderedDirections[nextDirectionIndex];
        }

        public string TurnRight(string currentDirection)
        {
            var nextDirectionIndex = IndexOfCurrentDirection(currentDirection);
            nextDirectionIndex ++;
            if (nextDirectionIndex == 4)
            {
                nextDirectionIndex = 0;
            }
            return orderedDirections[nextDirectionIndex];
        }

        public static string StartingDirection(string startingPosition)
        {
            return startingPosition.Split(' ').Last();
        }

        private int IndexOfCurrentDirection(string currentDirection)
        {
            return Array.IndexOf(orderedDirections, currentDirection);
        }
    }
}