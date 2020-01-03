using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;
using OrleansBlazor.Grains;

namespace OrleansBlazor.Silo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseOrleans(builder =>
                {
                    builder.ConfigureApplicationParts(manager =>
                    {
                        manager.AddApplicationPart(typeof(WeatherGrain).Assembly).WithReferences();
                    })
                    .UseLocalhostClustering()
                    .AddMemoryGrainStorageAsDefault()
                    .AddSimpleMessageStreamProvider("SMS")
                    .AddMemoryGrainStorage("PubSubStore")
                    .UseDashboard();
                });
    }
}