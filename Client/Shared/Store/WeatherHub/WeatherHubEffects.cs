using BlazorDemo.Shared;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Shared.Store.WeatherHub
{
    public class WeatherHubEffects
    {
        private readonly HubConnection _hubConnection;

        public WeatherHubEffects(NavigationManager navigationManager)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/weather"))
                .WithAutomaticReconnect()
                .Build();
        }

        [EffectMethod(typeof(WeatherHubStartAction))]
        public async Task Start(IDispatcher dispatcher)
        {
            try
            {
                await _hubConnection.StartAsync();

                _hubConnection.Reconnecting += (ex) =>
                {
                    dispatcher.Dispatch(new WeatherHubSetConnectedAction(false));
                    return Task.CompletedTask;
                };

                _hubConnection.Reconnected += (connectionId) =>
                {
                    dispatcher.Dispatch(new WeatherHubSetConnectedAction(true));
                    return Task.CompletedTask;
                };

                _hubConnection.On<WeatherForecast>("WeatherUpdate", model => dispatcher.Dispatch(new WeatherHubReceiveAction(model)));

                dispatcher.Dispatch(new WeatherHubSetConnectedAction(true));

            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new WeatherHubReceiveFailedAction(ex.Message));
            }
        }
    }
}

