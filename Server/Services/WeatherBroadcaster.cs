using BlazorDemo.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorDemo.Server.Helpers;

namespace BlazorDemo.Server.Services
{
    public sealed class WeatherBroadcaster : IHostedService, IDisposable
    {
        private readonly IHubContext<WeatherHub> _hubContext;
        private IDisposable _subscription;

        public WeatherBroadcaster(IHubContext<WeatherHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Dispose()
        {
            _subscription?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var random = new Random();  
            _subscription = Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ => 
                    _hubContext.Clients.All.SendAsync("WeatherUpdate", MockWeatherGenerator.GenerateWeather(), cancellationToken));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscription?.Dispose();
            return Task.CompletedTask;
        }
    }
}
