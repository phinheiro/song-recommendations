using Conexia.SR.CrossCutting.Identity;
using Conexia.SR.Data;
using Conexia.SR.ExternalServices.Settings;
using Conexia.SR.WebAPI.Configurations;
using Conexia.SR.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Conexia.SR.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            WeatherApiSettings.ApiKey = Configuration["WeatherApiKey"];
            SpotifyApiSettings.ClientId = Configuration["SpotifySettings:ClientId"];
            SpotifyApiSettings.SecretId = Configuration["SpotifySettings:ClientSecret"];
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDatabaseSetup(Configuration);

            services.AddIdentitySetup(Configuration);

            services.AddAutoMapperSetup();

            services.AddSwaggerSetup();

            services.RegisterServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IdentityContext identity, SRContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<LogMiddleware>();

            app.UseSwaggerSetup();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ApplyIdentityMigrations(identity);
            ApplyMigrations(context);
        }
        public void ApplyIdentityMigrations(IdentityContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public void ApplyMigrations(SRContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        
    }
}
