using Microsoft.Extensions.DependencyInjection;
using SuperHeroes.Domain.Actions;
using SuperHeroes.Domain.Interfaces.Actions;

namespace SuperHeroes.Domain
{
    public static class DomainNativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISuperHeroesActions, SuperHeroesActions>();
            services.AddScoped<ISuperPowersActions, SuperPowersActions>();
        }
    }
}