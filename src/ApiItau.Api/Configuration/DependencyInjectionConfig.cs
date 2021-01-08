using System;
using Microsoft.Extensions.DependencyInjection;
using ApiItau.Infra;

namespace ApiItau.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            DependencyInjector.RegisterServices(services);
        }
    }
}