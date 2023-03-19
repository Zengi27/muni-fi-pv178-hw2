using HW02.Model;

namespace HW02;

public class IdNotFoundException : Exception
{
    public IdNotFoundException(int id, EntityType entityType) : base($"Id {id} for {entityType} does not exists.") { }
}