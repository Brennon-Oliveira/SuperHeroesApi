using Microsoft.Extensions.DependencyInjection;
using SuperHeroes.Domain.Interfaces.Repositories;
using SuperHeroes.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Infra.Data
{
    public static class InfraDataNativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISuperHeroesRepository, SuperHeroesRepository>();
            services.AddScoped<ISuperPowersRepository, SuperPowersRepository>();
        }
    }
}
