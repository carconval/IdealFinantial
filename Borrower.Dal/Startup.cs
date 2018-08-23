using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Borrower.Dal
{
    public static class Startup
    {
        public static void AddDal(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<BorrowerDbSettings>(config.GetSection(nameof(BorrowerDbSettings)));
            services.AddScoped<BorrowerContext, BorrowerContext>();
        }
    }
}