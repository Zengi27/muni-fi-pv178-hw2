namespace HW02.Helpers;

public class IdGenerator
{
    private int _lastId = 0;

    public int GetNextId()
    {
        return Interlocked.Increment(ref _lastId);
    }
}