using Microsoft.AspNetCore.Mvc;
using WaterLevels.Logic;
using WaterLevels.Models;

namespace WaterLevels.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class DataController : ControllerBase
        {
        private readonly IWaterLevelsLogic _logic;

        public DataController(IWaterLevelsLogic logic)
        {
            _logic = logic;
        }
        [HttpPost("Add")]
        public void AddWaterLevel([FromBody] WaterLevelRecord entry)
        {
            _logic.CreateWaterLevelsData(entry);
        }

        [HttpPost]
        public void AddWaterLevelList([FromBody] List<WaterLevelRecord> entries)
        {
            _logic.CreateWaterLevelsData(entries);
        }
        [HttpGet]
        public IEnumerable<WaterLevelRecordMonth> GetMonth()
        {
            return _logic.GetMonth();
        }
    }
    
}
