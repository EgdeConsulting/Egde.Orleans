using System;
using System.Threading;
using System.Threading.Tasks;
using Egde.PlaygroundGrainInterfaces;
using Egde.PlaygroundGrains;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace Egde.SiloHost
{
    class Program
    {
        public static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                var host = await StartSilo();
                Console.WriteLine("\n\n Press Enter to terminate...\n\n");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            // define the cluster configuration
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansBasics";
                })
                .ConfigureApplicationParts(parts =>
                    parts.AddApplicationPart(typeof(TempReaderGrain).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole());

            builder.AddStartupTask(
                async (IServiceProvider services, CancellationToken cancellation) =>
                {
                    // Use the service provider to get the grain factory.
                    var grainFactory = services.GetRequiredService<IGrainFactory>();

                    // Get a reference to a grain and call a method on it.
                    var grain = grainFactory.GetGrain<IApiPullerGrain>(0);
                    await grain.Init();
                });
            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}