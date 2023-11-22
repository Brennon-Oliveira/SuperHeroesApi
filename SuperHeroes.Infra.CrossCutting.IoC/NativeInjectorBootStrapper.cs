using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace SuperHeroes.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {

        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            var accessor = new HttpContextAccessor();

            services.AddSingleton<HttpContextAccessor>(accessor);
        }
    }
}