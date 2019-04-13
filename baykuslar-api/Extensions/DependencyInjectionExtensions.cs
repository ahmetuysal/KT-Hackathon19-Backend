using System;
using System.Text;
using baykuslar_api.Data;
using baykuslar_api.Data.Entities;
using baykuslar_api.Mappers;
using baykuslar_api.Mappers.Implementations;
using baykuslar_api.Services;
using baykuslar_api.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace baykuslar_api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<UserEntity>(options => { options.SignIn.RequireConfirmedEmail = false; })
                .AddEntityFrameworkStores<BaykuslarDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
                options.User.RequireUniqueEmail = true;
            });
            return services;
        }

        public static IServiceCollection AddRepositoriesLayer(this IServiceCollection services)
        {

            
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddDbContext<BaykuslarDbContext>(options =>
            {
                options.UseNpgsql(configuration["DbConnectionString"]);
            });

            
            return services;
        }

        public static IServiceCollection AddHelpersLayer(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddServicesLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
        
        public static IServiceCollection AddMappersLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserMapper, UserMapper>();
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
        
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                    };
                });
            return services;
        }
    }
}