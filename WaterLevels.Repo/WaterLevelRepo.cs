using System.Security.Principal;
using WaterLevels.Database;
using WaterLevels.Models;
using WaterLevels.Repo;

namespace WaterLevels.Data
{
    public class WaterLevelRepo:IWaterLevelRepo
    {
        private readonly WaterLevelContext ctx;

        public WaterLevelRepo(WaterLevelContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(WaterLevelRecord entity)
        {
            ctx.Set<WaterLevelRecord>().Add(entity);
            ctx.SaveChanges();
        }
        public IQueryable<WaterLevelRecord> GetAll()
        {
            return ctx.Set<WaterLevelRecord>();
           
        }
    }
}
