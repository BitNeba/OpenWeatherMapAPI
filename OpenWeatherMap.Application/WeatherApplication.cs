using OpenWeatherMap.Application.Contract;
using OpenWeatherMap.Application.Contracts;
using OpenWeatherMap.Domain;
using OpenWeatherMap.Repository;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMap.Application
{
    public class WeatherApplication : IWeatherApplication
    {
        private readonly IRepositoryAsync<Weather> _repository;

        public WeatherApplication(IRepositoryAsync<Weather> repository)
        {
            this._repository = repository;
        }

       
        public async Task<WeatherDto> GetWeatherByCityName(string cityName)
        {
            var result = await this._repository.FirstOrDefaultAsync(i => i.city.findname.Equals(cityName.ToUpper()));

            if(result != null)
                return result.AsDto();

            return null;
        }

        public async Task<WeatherDto> GetWeatherByCoordinate(decimal lon, decimal lat)
        {
            var result = await this._repository.FirstOrDefaultAsync(i => i.city.coord.lon == lon && i.city.coord.lat == lat);

            if (result != null)
                return result.AsDto();

            return null;
        }

    }
}
