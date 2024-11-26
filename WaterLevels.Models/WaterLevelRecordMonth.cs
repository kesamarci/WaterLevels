using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WaterLevels.Models
{
    public class WaterLevelRecordMonth
    {
        
        public string Month { get; set; }

       
        public double AverageValue { get; set; }

        
        public int MinimalValue { get; set; }

       
        public int MaximalValue { get; set; }


        public override string ToString()
        {
            return $"Month: {Month}" +
                $"\nAverage value: {AverageValue}" +
                $"\nMinimal value: {MinimalValue}" +
                $"\nMaximal value: {MaximalValue}";
            ;
        }
    }
}
