using System.Collections.Generic;

namespace OpenWeatherMap.Domain
{
    public class Weather
    {
        public City city { get; set; }

        public int time { get; set; } //datetime value

        public Main main { get; set; }

        public Wind wind { get; set; }
        
        public Clouds clouds { get; set; }

        public List<Condition> weather { get; set; }
    }
}

 