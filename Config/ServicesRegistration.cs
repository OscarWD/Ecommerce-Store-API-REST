using EcommerceStoreAPI.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EcommerceStoreAPI.Config
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddSwaggerGen(configuration => configuration.SwaggerDoc("v0.0.1", new OpenApiInfo{Title= "Ecommerce Store API REST", Version = "v0.0.1"}));

            return services;
        }
    }
}