using System;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Egde.ApiPollerClient
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRefitClients(this IServiceCollection services)
        {
            services.AddRefitClient<IAdviceSlipApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.adviceslip.com"));
            return services;
        }
    }
}