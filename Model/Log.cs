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
    
    
    public Log(LogType logType, EntityType entityType, OperationResultType operationResultType, Category? entity, string message)
    {
        Timestamp = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss");
        LogType = logType;
        EntityType = entityType;
        OperationResultType = operationResultType;
        Message = message;

        if (entity != null)
        {
            EntityId = entity.Id;
            EntityName = entity.Name;

            if (entity is Product product)
            {
                CategoryId = product.CategoryId;
            }
        }
    }

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
                if (EntityType == EntityType.Product)
                {
                    logString = $"[{Timestamp}] {LogType}; {EntityType}; {OperationResultType}; {EntityId}; {EntityName}; {CategoryId}";
                }
                else
                {
                    logString = $"[{Timestamp}] {LogType}; {EntityType}; {OperationResultType}; {EntityId}; {EntityName}";
                }
            }
        }
        else
        {
            if (LogType == LogType.Other)
            {
                logString = $"[{Timestamp}] {LogType}; {OperationResultType}; {Message}";
            }
            else
            {
                logString = $"[{Timestamp}] {LogType}; {EntityType}; {OperationResultType}; {Message}";
            }
        }
        
        return logString;
    }
}