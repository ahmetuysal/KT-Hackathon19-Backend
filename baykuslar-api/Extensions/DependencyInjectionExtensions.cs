using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace baykuslar_api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositoriesLayer(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddHelpersLayer(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddServicesLayer(this IServiceCollection services)
        {
            return services;
        }
        
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(configuration["Swagger:AppVersion"], new Info()
                {
                    Title = configuration["Swagger:AppName"],
                    Description = configuration["Swagger:AppDescription"]
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            var configuration = app.ApplicationServices.GetService<IConfiguration>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json",
                    $"{configuration["Swagger:AppName"]} {configuration["Swagger:AppVersion"]}");
            });
            return app;
        }
    }
}