using System;
using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Helpers
{
    public class MockWeatherGenerator
    {
        public static WeatherForecast GenerateWeather()
        {
            var weather = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = new Random().Next(20, 50),
                Summary = "Update"
            };

            return weather;
        }

        private static readonly char[] Directions = new[]
        {
            'N', 'E', 'S', 'W'
        };

        private static WeatherDataWind GenerateWind()
        {
            var windDirectionIndex = new Random().Next(0, Directions.Length - 1);

            var wind = new WeatherDataWind
            {
                WindSpeed = new Random().Next(5, 50),
                WindGust = new Random().Next(5, 50),
                WindDirection = Directions[windDirectionIndex]
            };

            return wind;
        }
    }
}
