using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IdealFinantial.Startups
{
    public static class CancellationTokenServiceStartup
    {
        public static void AddCancellationToken(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(CancellationToken), serviceProvider =>
            {
                var accessor = serviceProvider.GetService<IHttpContextAccessor>();
                return accessor.HttpContext.RequestAborted;
            });
        }
    }
}