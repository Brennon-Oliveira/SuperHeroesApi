using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using SuperHeroes.Infra.Data;
using SuperHeroes.Domain;
using SuperHeroes.Application;
using SuperHeroes.Infra.CrossCutting.ServiceLocator;

namespace SuperHeroes.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            ApplicationsNativeInjector.RegisterServices(services);
            DomainNativeInjector.RegisterServices(services);
            InfraDataNativeInjector.RegisterServices(services);

            ServiceLocator.ServiceLocator.SetProvider(services.BuildServiceProvider());
        }
    }
}