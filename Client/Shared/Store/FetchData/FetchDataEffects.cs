using BlazorDemo.Shared;
using Fluxor;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorDemo.Client.Shared.Store.FetchData;

namespace BlazorDemo.Client.Shared.Store.Counter
{
    public class FetchDataEffects
    {
        private readonly HttpClient _httpClient;

        public FetchDataEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Effects are used to handle side effects in your application. 
        /// A side effect can be anything from a long-running task to an HTTP call to a service. 
        /// In these cases, state changes are not instantaneous. 
        /// Effects perform tasks, which are synchronous/asynchronous, and dispatch different actions based on the outcome.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dispatcher"></param>
        /// <returns></returns>
        [EffectMethod]
        public async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
        {
            try
            {
                var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
                dispatcher.Dispatch(new FetchDataSuccessAction(forecasts));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new FetchDataErrorAction(ex.Message));
            }
        }
    }
}
