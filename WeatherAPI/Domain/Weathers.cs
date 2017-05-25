using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Domain
{
    public class Weathers
    {
        private string[] weathers = new[] { "cloudy", "frosty", "snowing", "rainy", "sunny", "windy" };
        private string alphabet = "abcdefgijklmnopqrstuvwxyz";

        public WeatherModel GetWeather(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return null;
            }

            WeatherModel result = null;

            var lowered = location.ToLower();
            var firstLetter = lowered[0];

            if (alphabet.Contains(firstLetter))
            {
                var r = new Random((int)DateTime.Now.Ticks);

                result = new WeatherModel();

                //var slice = alphabet.Length / weathers.Length;
                var index = alphabet.IndexOf(firstLetter);

                var weatherTitle = weathers[index % weathers.Length];
                result.Weather = weatherTitle;

                result.Pressure = r.Next(950, 1050);
                Clouds[] possibleClouds;
                switch (result.Weather)
                {
                    case "cloudy":
                        possibleClouds = new[] { Clouds.Full, Clouds.Dominance, Clouds.Average };
                        result.CloudLevel = possibleClouds[r.Next(0, possibleClouds.Length)];
                        result.WindSpeed = r.Next(5, 15);
                        result.Humidity = r.Next(50, 90);
                        result.Temperature = r.Next(10, 25);
                        break;
                    case "frosty":
                        possibleClouds = new[] { Clouds.ClearSky, Clouds.Dominance, Clouds.Average, Clouds.Few, Clouds.Full };
                        result.CloudLevel = possibleClouds[r.Next(0, possibleClouds.Length)];
                        result.WindSpeed = r.Next(3, 15);
                        result.Humidity = r.Next(10, 30);
                        result.Temperature = r.Next(-20, -5);
                        break;
                    case "snowing":
                        possibleClouds = new[] { Clouds.Dominance, Clouds.Average, Clouds.Few, Clouds.Full };
                        result.CloudLevel = possibleClouds[r.Next(0, possibleClouds.Length)];
                        result.WindSpeed = r.Next(8, 20);
                        result.Humidity = r.Next(50, 90);
                        result.Temperature = r.Next(-10, -5);
                        break;
                    case "rainy":
                        possibleClouds = new[] { Clouds.Dominance, Clouds.Average, Clouds.Full };
                        result.CloudLevel = possibleClouds[r.Next(0, possibleClouds.Length)];
                        result.WindSpeed = r.Next(2, 25);
                        result.Humidity = r.Next(80, 99);
                        result.Temperature = r.Next(1, 25);
                        break;
                    case "sunny":
                        possibleClouds = new[] { Clouds.ClearSky, Clouds.Few };
                        result.CloudLevel = possibleClouds[r.Next(0, possibleClouds.Length)];
                        result.WindSpeed = r.Next(2, 5);
                        result.Humidity = r.Next(0, 20);
                        result.Temperature = r.Next(20, 35);
                        break;
                    case "windy":
                        possibleClouds = new[] { Clouds.ClearSky, Clouds.Dominance, Clouds.Average, Clouds.Few, Clouds.Full };
                        result.CloudLevel = possibleClouds[r.Next(0, possibleClouds.Length)];
                        result.WindSpeed = r.Next(20, 50);
                        result.Humidity = r.Next(20, 80);
                        result.Temperature = r.Next(20, 35);
                        break;
                }
            }

            return result;
        }
    }
}
