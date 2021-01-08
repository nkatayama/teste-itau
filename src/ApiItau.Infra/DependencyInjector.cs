using ApiItau.Business.Interfaces;
using ApiItau.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiItau.Infra
{
    public static class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Business
            services.AddScoped<IPasswordService, PasswordService>();
        }
    }
}