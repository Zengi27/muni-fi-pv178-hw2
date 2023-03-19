using HW02.Model;

namespace HW02;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException(Command command) : base($"Invalid arguments for command {command}.") { }
}