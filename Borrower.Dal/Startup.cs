using Microsoft.Extensions.DependencyInjection;

namespace Borrower.Dal
{
    public static class Startup
    {
        public static void AddDal(this IServiceCollection services)
        {
            services.AddScoped<BorrowerContext, BorrowerContext>();
        }
    }
}