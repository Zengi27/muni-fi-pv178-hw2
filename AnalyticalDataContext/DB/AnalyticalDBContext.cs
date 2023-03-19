using HW02.Helpers;
using System.Text.Json;
using HW02.Model;

namespace HW02.AnalyticalDataContext.DB
{
    public class AnalyticalDBContext
    {
        private readonly string[] _paths = { "..", "..", "..", "AnalyticalDataContext", "DB", "Storage", "AnalyticalData.json" };
        private readonly string _filePath;

        public AnalyticalDBContext()
        {
            _filePath = Path.Combine(_paths);
            FileHelper.CreateFile(_filePath);
        }

        // TODO: replace type List<object> in functions headers to the appropriate data model -> List<YourDataModel>
        public void SaveAnalyticalData(List<AnalyticalModel> log)
        {
            string jsonString = JsonSerializer.Serialize(log);
            using StreamWriter outputFile = new StreamWriter(_filePath);
            outputFile.WriteLine(jsonString);
        }

        public List<AnalyticalModel> ReadAnalyticalData()
        {
            string? line;
            using (StreamReader inputFile = new StreamReader(_filePath))
            {
                line = inputFile.ReadLine();
            }

            if (line == null)
            {
                return new List<AnalyticalModel>();
            }

            var model = JsonSerializer.Deserialize<List<AnalyticalModel>>(line);
            return model;
        }
    }
}
