using Microsoft.AspNetCore.Builder;

namespace EcommerceStoreAPI.Config
{
    public static class ApplicationRegistration
    {
        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v0.0.1/swagger.json", "Ecommerce Store API REST V0.0.1"));

            return app;
        }
    }
}