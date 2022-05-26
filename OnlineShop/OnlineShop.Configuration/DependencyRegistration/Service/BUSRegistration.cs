using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Service.Authentication;

namespace OnlineShop.Configuration.DependencyRegistration.Service
{
    public static class BUSRegistration
    {
        public static IServiceCollection AddBUS(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IRoleManager, RoleManager>();

            return services;
        }
    }
}
