using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WaterLevels.Models
{
    public class WaterLevelRecord
    {

        [Key]

        public DateOnly Date { get; set; } 
        public int Value { get; set; }

        
    }
}
