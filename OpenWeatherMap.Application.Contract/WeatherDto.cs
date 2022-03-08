using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Application.Contract
{
    public class WeatherDto
    {
        public string name { get; set; }
        public decimal CurrentTemprature { get; set; }

        public decimal MaximumTemprature { get; set; }

        public decimal MinimimTemprature { get; set; }

        public decimal AirPressure { get; set; }

        public decimal Humidity { get; set; }

        public decimal WindSpeed { get; set; }

        public decimal WindDirection { get; set; }

        public string WeatherCondition { get; set; }

        public string WeatherIcon { get; set; }

    }
}

