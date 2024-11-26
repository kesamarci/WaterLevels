using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WaterLevels.Models;
using WaterLevels.Repo;

namespace WaterLevels.Logic
{
    public class WaterlLevelsLogic : IWaterLevelsLogic
    {
        private readonly IWaterLevelRepo _repo;
        public WaterlLevelsLogic(IWaterLevelRepo repo)
        {
            _repo = repo;
        }
        public void CreateWaterLevelsData(List<WaterLevelRecord> data)
        {
           
            foreach (var item in data)
            {
                CreateWaterLevelsData(item);
            }
        }

        public void CreateWaterLevelsData(WaterLevelRecord data)
        {
            
            _repo.Create(data);
        }

        public List<WaterLevelRecord> GetWaterLevelsData(string json)
        {
            
            return JsonSerializer.Deserialize<List<WaterLevelRecord>>(json) ?? [];
        }

        public List<WaterLevelRecord> GetWaterLevelsPath(string path)
        {
            
            var extractedData = File.ReadAllText(path);
            return GetWaterLevelsData(extractedData);
        }

        public List<WaterLevelRecordMonth> GetMonth()
        {
            var data = _repo.GetAll().ToList();

            return data
                .GroupBy(w => new { w.Date.Year, w.Date.Month })
                .Select(g => new WaterLevelRecordMonth
                {
                    Month = $"{g.Key.Year}-{g.Key.Month:D2}",
                    AverageValue = Math.Round(g.Average(w => w.Value)),
                    MinimalValue = g.Min(w => w.Value),
                    MaximalValue = g.Max(w => w.Value)
                })
                .OrderBy(m => m.Month)
                .ToList();

           

        }
    }
}
