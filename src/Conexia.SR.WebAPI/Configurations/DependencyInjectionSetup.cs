using Conexia.SR.Application.Interfaces;
using Conexia.SR.Application.Services;
using Conexia.SR.Data;
using Conexia.SR.Data.Repositories.PersonalNotes;
using Conexia.SR.Domain.PersonalNoteRoot.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Conexia.SR.WebAPI.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IPersonalNoteRepository, PersonalNoteRepository>();

            // AppServices
            services.AddScoped<IPersonalNoteAppService, PersonalNoteAppService>();
            services.AddScoped<SRContext>();
        }
    }
}
