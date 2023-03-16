namespace HW02;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException() : base($"Invalid arguments") { }
}