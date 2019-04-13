using baykuslar_api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace baykuslar_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMappersLayer()
                .AddHelpersLayer()
                .AddRepositoriesLayer()
                .AddServicesLayer()
                .AddCustomIdentity()
                .AddCustomSwagger()
                .AddJwtConfiguration()
                //.AddSendGridEmailSender()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app
                .UseCustomSwagger()
                .UseAuthentication()
                .UseCors(builder =>
                    builder.WithOrigins("http://localhost:4200", "https://localhost:4200", "https://kt-baykuslar.github.io")
                        .WithHeaders("content-type", "authorization"))
                .UseMvc();
        }
    }
}
