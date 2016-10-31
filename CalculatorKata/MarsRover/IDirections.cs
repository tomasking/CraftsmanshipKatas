namespace CraftsmanKata.MarsRover
{
    public interface IDirections
    {
        string TurnLeft(string currentDirection);
        string TurnRight(string currentDirection);
    }
}