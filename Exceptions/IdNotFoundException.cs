namespace HW02;

public class IdNotFoundException : Exception
{
    public IdNotFoundException(int id) : base($"Id {id} not found") { }
}