using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Database.Core;
using OnlineShop.Infrastructure;

namespace OnlineShop.Configuration.DependencyRegistration.Service
{
    public static class DALRegistration
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork<CoreDbContext>, UnitOfWork<CoreDbContext>>();
            services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CoreDbConnection")));
            return services;
        }
    }
}
