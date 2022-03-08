using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenWeatherMap.Application;
using OpenWeatherMap.Application.Contract;
using OpenWeatherMap.Domain;
using OpenWeatherMap.Host.Controllers;
using OpenWeatherMap.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherMap.Test
{
    public class WeatherControllerTest
    {
        /* naming convention UnittoTest_UnderwhichCondition_ExpectedResult */
        private List<Weather> _availableWeatherData;
        private WeatherApplication _application; 
        private readonly RepositoryAsync<Weather> _weatherRepository;
        private readonly Mock<IContext<Weather>> _context;
        
        public WeatherControllerTest()
        {
            InitData();

            //arrange
            _context = new Mock<IContext<Weather>>();
            _context.Setup(x => x.Weather)
                .Returns(_availableWeatherData);

            _weatherRepository = new RepositoryAsync<Weather>(_context.Object);
            _application = new WeatherApplication(_weatherRepository);
           
        }

        private void InitData()
        {
            _availableWeatherData = new List<Weather>() {
            new Weather
            {
                  city = new City {
                 id =342884,
                 name ="Bahir Dar",
                 findname="BAHIR DAR",
                 country ="ET",
                     coord = new Coord
                     {
                         lon = 37.39077m,
                         lat = 11.59364m
                     },
                     zoom = 6
                 },
                  main = new Main
                  {
                      temp =299.914m,
                      temp_min = 299.914m,
                      temp_max = 299.914m,
                      pressure = 805.41m,
                      sea_level= 1016.34m,
                      grnd_level= 805.41m,
                      humidity=42
                 },
                  clouds = new Clouds
                  {
                     all = 42
                  },
                  time = 1489491862,
                  weather = new List<Condition>(){
                  new Condition {
                        id= 802,
                        main = "Clouds",
                        description= "scattered clouds",
                        icon = "03d"
                      }
                     },
                  wind = new Wind
                      {
                        speed = 1.66m,
                        deg  = 351.501m
                      }
            },
            new Weather
            {
                  city = new City {
                 id =2950159,
                 name ="Berlin",
                 findname="BERLIN",
                 country ="DE",
                 coord = new Coord
                     {
                         lon = 13.41053m,
                         lat = 52.524368m
                     },
                  zoom = 4
                 },
                  main = new Main
                  {
                      temp =279.15m,
                      temp_min = 279.15m,
                      temp_max =279.15m,
                      pressure = 1029m,
                      humidity=81
                 },
                  clouds = new Clouds
                  {
                     all = 75
                  },
                  time = 1489489383,
                  weather = new List<Condition>(){
                  new Condition {
                        id = 803,
                        main = "Clouds",
                        description= "broken clouds",
                        icon = "04d"
                      }
                     },
                  wind = new Wind
                      {
                         speed = 4.1m,
                         deg = 250,
                         var_beg = 220,
                         var_end = 280
                      }
            },
            };
        }
        [Fact]
        public async Task GetCityWeatherByName_WithUnExistingCity_ReturnsNull()
        {

            //Act
            var result = await _application.GetWeatherByCityName("doha");

            //Assert
            Assert.Null(result);
        }

        [Fact]

        public async Task GetCityWeatherByName_WithExistingCity_ReturnsExpectedResult()
        {
            //Act
            var result = await _application.GetWeatherByCityName("Bahir dar");

            //Assert
            result.Should().BeEquivalentTo(
                _availableWeatherData[0].AsDto(),
                options => options.ComparingByMembers<WeatherDto>());
        }

        [Theory]
        [InlineData(13.41053, 32.39077)]
        public async Task GetCityWeatherByCoordinate_WithUnExistingCity_ReturnsNull(decimal lat, decimal lon)
        {

            //Act
            var result = await _application.GetWeatherByCoordinate(lon, lat);

            //Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(52.524368, 13.41053)]
        public async Task GetCityWeatherByCoordinate_WithExistingCity_ReturnsExpectedResult(decimal lat, decimal lon)
        {
            //Act
            var result = await _application.GetWeatherByCoordinate(lon, lat);

            //Assert
            result.Should().BeEquivalentTo(
                _availableWeatherData[1].AsDto(),
                options => options.ComparingByMembers<WeatherDto>());
        }
    }
}
