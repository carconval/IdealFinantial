using Microsoft.Extensions.DependencyInjection;

namespace Borrower.Services
{
    public static class Startup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}