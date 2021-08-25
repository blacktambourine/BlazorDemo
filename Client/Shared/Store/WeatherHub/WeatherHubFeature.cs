using BlazorDemo.Shared;
using Fluxor;

namespace BlazorDemo.Client.Shared.Store.WeatherHub
{
    public record WeatherHubState(bool IsConnected, bool IsLoading, WeatherForecast Forecast, string Error);

    public class WeatherHubFeature : Feature<WeatherHubState>
    {
        public override string GetName() => "WeatherHub";

        protected override WeatherHubState GetInitialState() => new(false, false, null, null);
    }
}
