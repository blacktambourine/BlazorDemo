using System;
using System.Collections.Generic;
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

            var weatherData = new WeatherData
            {
                WeatherDataWind = GenerateWind(),
                WeatherDataTide = GenerateTide(),
                WeatherDataWave = GenerateWave(),
                WeatherDataAir = GenerateAir()
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

        private static string HeightText (double height)
        {
            return $"{height}m";
        }

        private static int RandomHeight (int min = 0)
        {
            return new Random().Next(min, 120);
        }

        private static string Height (double heightNumber = 0)
        {
            if (heightNumber != 0) return HeightText(heightNumber);

            return HeightText(RandomHeight() / 100);
        }

        private static readonly string[] TideStatuses = new[]
        {
            "Rising", "Dropping", "Resting"
        };

        private static string TideString()
        {
            return string.Empty;
        }

        private static string TideETA()
        {
            return string.Empty;
        }

        private static WeatherDataTide GenerateTide()
        {
            var tideStatusIndex = new Random().Next(0, TideStatuses.Length - 1);

            var tide = new WeatherDataTide
            {
                TideStatus = TideStatuses[tideStatusIndex],
                TideNextHigh = TideString(),
                TideNextHighETA = TideETA(),
                TideNextLow = TideString(),
                TideNextLowETA = TideETA()
            };

            return tide;
        }

        private static List<DetailItem> GenerateWave()
        {
            var intWaveHeight = RandomHeight();
            var intWaveTotalHeight = RandomHeight(intWaveHeight);

            var wave = new List<DetailItem>()
            {
                new DetailItem() {
                    IconType = "Wave",
                    Label = "Swell Height",
                    Data = Height(intWaveHeight / 100)
                },
                new DetailItem() {
                    IconType = "Wave",
                    Label = "Total Height",
                    Data = Height(intWaveTotalHeight / 100)
                },
                new DetailItem() {
                    IconType = "Clock",
                    Label = "Swell Period",
                    Data = "15sec"
                },
                new DetailItem() {
                    IconType = "Clock",
                    Label = "Total Period",
                    Data = "4.5sec"
                },
                new DetailItem() {
                    IconType = "Direction",
                    Label = "Wave Direction",
                    Data = "N/A"
                },
                new DetailItem() {
                    IconType = "Temperature",
                    Label = "Water Temp",
                    Data = "N/A"
                }
            };

            return wave;
        }

        private static WeatherDataAir GenerateAir()
        {
            var air = new WeatherDataAir
            {
                Temperature = new Random().NextDouble() * new Random().Next()
            };

            return air;
        }
    }
}
