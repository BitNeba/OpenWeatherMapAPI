using OpenWeatherMap.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Application
{
    public static class Extensions
    {
        public static WeatherDto AsDto(this Domain.Weather weather)
        {
            return new WeatherDto
            {
                name = weather.city.findname,
                MinimimTemprature = weather.main.temp_min,
                MaximumTemprature = weather.main.temp_max,
                CurrentTemprature = weather.main.temp,
                Humidity = weather.main.humidity,
                AirPressure = weather.main.pressure,
                WindSpeed = weather.wind.speed,
                WindDirection = weather.wind.deg,
                WeatherCondition = weather.weather?[0].description,
                WeatherIcon = weather.weather?[0].icon
            };
        }

    }
}
