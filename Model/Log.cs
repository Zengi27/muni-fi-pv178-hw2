namespace HW02.Model;

public class Log : EventArgs
{
    public string Timestamp { get; set; }
    public LogType LogType { get; set; }
    public EntityType EntityType { get; set; }
    public OperationResultType OperationResultType { get; set; }
    public int? EntityId { get; set; }
    public string? EntityName { get; set; }
    public int? CategoryId { get; set; }
    public string? Message { get; set; }
    
    public string ToLogString()
    {
        string logString;

        if (OperationResultType == OperationResultType.Success)
        {
            if (LogType == LogType.Get)
            {
                logString = $"[{Timestamp}] {LogType}; {EntityType}; {OperationResultType}";
            }
            else
            {
                logString = $"[{Timestamp}] {LogType}; {EntityType}; {OperationResultType}; {EntityId}; {EntityName} {CategoryId}";
            }
        }
        else
        {
            logString = $"[{Timestamp}] {LogType}; {EntityType}; {OperationResultType}; {Message}";
        }
        
        return logString;
    }
}