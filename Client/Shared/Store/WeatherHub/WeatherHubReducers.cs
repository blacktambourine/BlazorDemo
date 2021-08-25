using Fluxor;

namespace BlazorDemo.Client.Shared.Store.WeatherHub
{
    public class WeatherHubReducers
    {
        [ReducerMethod]
        public static WeatherHubState ReduceWeatherHubAction(WeatherHubState state, WeatherHubSetConnectedAction action) => state with
        {
            IsConnected = action.Connected
        };

        [ReducerMethod]
        public static WeatherHubState ReduceWeatherHubAction(WeatherHubState state, WeatherHubStartAction action) => state with
        {
            IsLoading = true,
            Error = null,
            Forecast = null
        };

        [ReducerMethod]
        public static WeatherHubState ReduceWeatherHubSuccessAction(WeatherHubState state, WeatherHubReceiveAction action) => state with
        {
            IsLoading = false,
            Forecast = action.Forecast,
            Error = null
        };

        [ReducerMethod]
        public static WeatherHubState ReduceWeatherHubErrorAction(WeatherHubState state, WeatherHubReceiveFailedAction action) => state with
        {
            IsLoading = false,
            Forecast = null,
            Error = action.Message
        };
    }
}
