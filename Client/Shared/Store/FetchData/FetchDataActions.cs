using BlazorDemo.Shared;

namespace BlazorDemo.Client.Shared.Store.FetchData
{
    public record FetchDataAction();
    public record FetchDataSuccessAction(WeatherForecast[] Forecast);
    public record FetchDataErrorAction(string ErrorMessage);
}
