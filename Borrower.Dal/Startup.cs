using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Borrower.Dal
{
    public static class Startup
    {
        public static void AddDal(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("BorrowerDbSettings");
            services.Configure<BorrowerDbSettings>(options =>
            {
                options.ConnectionString = section["ConnectionString"];
                options.Database = section["Database"];
            });
            services.AddScoped<BorrowerContext, BorrowerContext>();
        }
    }
}