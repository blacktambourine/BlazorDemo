using System;
using System.Collections.Generic;

namespace BlazorDemo.Shared.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class WeatherData
    {
        public WeatherDataWind WeatherDataWind { get; set; }

        public WeatherDataTide WeatherDataTide { get; set; }

        public List<DetailItem> WeatherDataWave { get; set; }

        public WeatherDataAir WeatherDataAir { get; set; }
    }

    public class WeatherDataWind
    {
        public int WindSpeed { get; set; }

        public int WindGust { get; set; }

        public char WindDirection { get; set; }
    }

    public class WeatherDataTide
    {
        public string TideStatus { get; set; }
        
        public string TideNextHigh { get; set; }

        public string TideNextHighETA { get; set; }

        public string TideNextLow { get; set; }

        public string TideNextLowETA { get; set; }
    }

    public class WeatherDataAir
    {
        public double Temperature { get; set; }

        public double HumidityPercentage { get; set; }

        public int AirPressure { get; set; }
    }
}
