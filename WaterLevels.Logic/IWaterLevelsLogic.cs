using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterLevels.Models;

namespace WaterLevels.Logic
{
    public interface IWaterLevelsLogic
    {
        List<WaterLevelRecordMonth> GetMonth();
        List<WaterLevelRecord> GetWaterLevelsPath(string path);
        List<WaterLevelRecord> GetWaterLevelsData(string json);
        void CreateWaterLevelsData(List<WaterLevelRecord> data);
        void CreateWaterLevelsData(WaterLevelRecord data);
    }
}
