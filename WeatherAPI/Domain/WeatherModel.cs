using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Domain
{
    public class WeatherModel
    {
        public string Weather { get; set; }
        public float Temperature { get; set; }
        public int Pressure { get; set; }
        public float Humidity { get; set; }
        public Clouds CloudLevel { get; set; }
        public int WindSpeed { get; set; }
    }
}
