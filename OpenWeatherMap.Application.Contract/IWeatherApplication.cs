using OpenWeatherMap.Application.Contract;
using System.Threading.Tasks;

namespace OpenWeatherMap.Application.Contracts
{
    public interface IWeatherApplication
    {
        Task<WeatherDto> GetWeatherByCityName(string cityName);

        Task<WeatherDto> GetWeatherByCoordinate(decimal lon, decimal lat);
    }
}
