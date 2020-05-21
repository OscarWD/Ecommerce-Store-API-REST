using EcommerceStoreAPI.Data;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EcommerceStoreAPI.Config
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ISubCategorieRepository, SubCategorieRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddSwaggerGen(configuration => configuration.SwaggerDoc("v0.0.1", new OpenApiInfo { Title = "Ecommerce Store API REST", Version = "v0.0.1" }));

            return services;
        }
    }
}