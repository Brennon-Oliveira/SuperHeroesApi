using Microsoft.Extensions.DependencyInjection;
using SuperHeroes.Application.Interfaces.Services;
using SuperHeroes.Application.Services;

namespace SuperHeroes.Application
{
    public static class ApplicationsNativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISuperHeroesService, SuperHeroesService>();
            services.AddScoped<ISuperPowersService, SuperPowersService>();
        }
    }
}