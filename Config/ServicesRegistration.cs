using EcommerceStoreAPI.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceStoreAPI.Config
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            
            return services;
        }
    }
}