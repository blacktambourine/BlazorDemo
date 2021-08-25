using BlazorDemo.Shared;
using Fluxor;

namespace BlazorDemo.Client.Shared.Store.FetchData
{
    public record FetchDataState(bool IsLoading, WeatherForecast[] Forecasts, string Error);
    public class FetchDataFeature : Feature<FetchDataState>
    {
        public override string GetName() => "FetchData";
        protected override FetchDataState GetInitialState() => new(false, null, null);
    }    
}
