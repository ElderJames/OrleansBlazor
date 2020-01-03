using Orleans;
using OrleansBlazor.Grains.Models;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace OrleansBlazor.Grains
{
    public interface IWeatherGrain : IGrainWithGuidKey
    {
        Task<ImmutableArray<WeatherInfo>> GetForecastAsync();
    }
}