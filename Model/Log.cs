namespace HW02.Model;

public class Log : EventArgs
{
    public string Timestamp { get; set; }
    

    public string ToLogString()
    {
        return Timestamp;
    }
}