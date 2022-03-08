using Microsoft.AspNetCore.Mvc;
using OpenWeatherMap.Application.Contract;
using OpenWeatherMap.Application.Contracts;
using System.Threading.Tasks;

namespace OpenWeatherMap.Host.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherApplication _weatherApplication;

        public WeatherController(IWeatherApplication weatherApplication)
        {
            this._weatherApplication = weatherApplication;
        }


        //GET /weather/{city name}
        [HttpGet("{cityName}")]
        public async Task<ActionResult<WeatherDto>> GetWeather(string cityName)
        {
           var cityWeather = await this._weatherApplication.GetWeatherByCityName(cityName);

            if (cityWeather == null)
                return NotFound();

            return Ok(cityWeather);
        }

        //GET /weather/{lon}/{lat}
        [HttpGet("{lon}/{lat}")]
        public async Task<ActionResult<WeatherDto>> GetWeather(decimal lon, decimal lat)
        {
            var cityWeather = await this._weatherApplication.GetWeatherByCoordinate(lon, lat);

            if (cityWeather == null)
                return NotFound();

            return Ok(cityWeather);
        }
    }
}