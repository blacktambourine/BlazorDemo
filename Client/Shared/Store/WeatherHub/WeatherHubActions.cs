
using BlazorDemo.Shared;

namespace BlazorDemo.Client.Shared.Store.WeatherHub
{
    public record WeatherHubSetConnectedAction(bool Connected);
    public record WeatherHubStartAction();
    public record WeatherHubReceiveAction(WeatherForecast Forecast);
    public record WeatherHubReceiveFailedAction(string Message);    
}
