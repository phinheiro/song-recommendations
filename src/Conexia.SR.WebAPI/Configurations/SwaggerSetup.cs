using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Conexia.SR.WebAPI.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {

                        Title = "Song Recommendations",
                        Description = @"An API to register a user and recommend songs based
                                        on hometown current temperature",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Pedro Pinheiro",
                            Url = new Uri("https://www.linkedin.com/in/phinheiro/")
                        }
                    });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
