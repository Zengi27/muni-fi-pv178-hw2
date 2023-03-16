using HW02.LoggerContext.DB;
using HW02.Model;

namespace HW02
{
    public class LoggerListener
    {
        private LoggerDBContext _loggerDbContext;
        
        public LoggerListener(LoggerDBContext loggerDbContext)
        {
            _loggerDbContext = loggerDbContext;
        }

        public void OnOperationCompleted(object sender, Log log)
        {
            _loggerDbContext.WriteLog(log);
        }
    }
}
