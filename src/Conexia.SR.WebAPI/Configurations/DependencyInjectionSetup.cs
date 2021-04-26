using Conexia.SR.Application.Interfaces;
using Conexia.SR.Application.Services;
using Conexia.SR.Data;
using Conexia.SR.Data.Repositories.PersonalNotes;
using Conexia.SR.Domain.PersonalNoteRoot.Interfaces;
using Conexia.SR.ExternalServices.Interfaces;
using Conexia.SR.ExternalServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Conexia.SR.WebAPI.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Context
            services.AddScoped<SRContext>();

            // Repositories
            services.AddScoped<IPersonalNoteRepository, PersonalNoteRepository>();

            // AppServices
            services.AddScoped<IPersonalNoteAppService, PersonalNoteAppService>();
            services.AddScoped<ISongRecommendationAppService, SongRecommendationAppService>();

            // External Services
            services.AddScoped<IWeatherApiService, WeatherApiService>();
            services.AddScoped<ISpotifyApiService, SpotifyApiService>();
        }
    }
}
