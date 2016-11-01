namespace CraftsmanKata.MarsRover
{
    public interface IDirection
    {
        string TurnLeft(string currentDirection);
        string TurnRight(string currentDirection);
    }
}