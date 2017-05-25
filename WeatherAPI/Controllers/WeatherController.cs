using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Domain;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private Weathers weathersData;

        public WeatherController()
        {
            weathersData = new Weathers();
        }

        [HttpGet("{location}")]
        public IActionResult Get(string location)
        {
            var result = weathersData.GetWeather(location);

            if (result == null)
            {
                return NotFound(location);
            }

            return Ok(result);
        }
    }
}
