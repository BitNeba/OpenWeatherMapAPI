namespace OpenWeatherMap.Domain
{
    public  class City
    {
        public int id { get; set; }

        public string name { get; set; }

        public string findname { get; set; }

        public string country { get; set; }

        public Coord coord { get; set; }

        public decimal zoom { get; set; }
    }
}