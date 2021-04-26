using Conexia.SR.ExternalServices.ViewModels.WeatherApi;
using System.Threading.Tasks;

namespace Conexia.SR.ExternalServices.Interfaces
{
    public interface IWeatherApiService
    {
        Task<WeatherApiViewModel> GetCurrentTemperature(string hometown);
    }
}
