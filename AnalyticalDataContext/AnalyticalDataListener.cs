using HW02.AnalyticalDataContext.DB;
using HW02.Model;

namespace HW02.AnalyticalDataContext
{
    public class AnalyticalDataListener
    {

        private AnalyticalDBContext _analyticalDbContext;
        
        public AnalyticalDataListener(AnalyticalDBContext analyticalDbContext)
        {
            _analyticalDbContext = analyticalDbContext;
        }

        public void OnOperationCompleted(object sender, Log log)
        {
            if ((log.OperationResultType == OperationResultType.Success) && (log.LogType != LogType.Get))
            {
                var analyticalModels = _analyticalDbContext.ReadAnalyticalData();

                if (log.EntityType == EntityType.Category)
                {
                    if (log.LogType == LogType.Add)
                    {
                        analyticalModels.Add(new AnalyticalModel()
                        {
                            CategoryId = (int)log.EntityId, 
                            CategoryName = log.EntityName,
                            ProductCount = 0
                        });
                    
                        _analyticalDbContext.SaveAnalyticalData(analyticalModels);    
                    }

                    if (log.LogType == LogType.Delete)
                    {
                        var analyticalModel = analyticalModels.Find(m => m.CategoryId == log.EntityId);

                        analyticalModels.Remove(analyticalModel);
                        _analyticalDbContext.SaveAnalyticalData(analyticalModels);
                    }
                }

                if (log.EntityType == EntityType.Product)
                {
                    if (log.LogType == LogType.Add)
                    {
                        analyticalModels.Find(m => m.CategoryId == log.CategoryId).ProductCount++;

                        _analyticalDbContext.SaveAnalyticalData(analyticalModels);
                    }
                    
                    if (log.LogType == LogType.Delete)
                    {
                        analyticalModels.Find(m => m.CategoryId == log.CategoryId).ProductCount--;

                        _analyticalDbContext.SaveAnalyticalData(analyticalModels);
                    }
                }
            }
        }
    }
}
