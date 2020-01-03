using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Orleans;
using OrleansBlazor.Grains;
using OrleansBlazor.Grains.Models;

namespace OrleansBlazor.Silo.Services
{
    public class WeatherForecastService
    {
        private readonly IClusterClient client;

        public WeatherForecastService(IClusterClient client)
        {
            this.client = client;
        }

        public Task<ImmutableArray<WeatherInfo>> GetForecastAsync() =>

            client.GetGrain<IWeatherGrain>(Guid.Empty)
                .GetForecastAsync();
    }
}