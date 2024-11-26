using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterLevels.Models;

namespace WaterLevels.Repo
{
    public interface IWaterLevelRepo
    {
        void Create(WaterLevelRecord entity);
        IQueryable<WaterLevelRecord> GetAll();
    }
}
