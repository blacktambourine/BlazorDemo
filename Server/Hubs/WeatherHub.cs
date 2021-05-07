using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Hubs
{
    public class WeatherHub : Hub
    {
        public async Task SendMessage(WeatherForecast forecast)
        {
            await Clients.All.SendAsync("WeatherUpdate", forecast);
        }
    }
}
