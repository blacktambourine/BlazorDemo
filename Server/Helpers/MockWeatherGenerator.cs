using System;
using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Helpers
{
    public class MockWeatherGenerator
    {
        public static WeatherForecast GenerateWeather ()
        {
            var weather = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = new Random().Next(20, 50),
                Summary = "Update"
            };

            return weather;
        }
    }
}
