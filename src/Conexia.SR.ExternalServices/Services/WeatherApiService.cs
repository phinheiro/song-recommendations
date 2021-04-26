using Conexia.SR.ExternalServices.Interfaces;
using Conexia.SR.ExternalServices.Settings;
using Conexia.SR.ExternalServices.ViewModels.WeatherApi;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Conexia.SR.ExternalServices.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5";
        public async Task<WeatherApiViewModel> GetCurrentTemperature(string hometown)
        {
            var action = $"{_baseUrl}/weather?q={hometown}&appid={WeatherApiSettings.ApiKey}&units=metric";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(action);
                var json = await response.Content.ReadAsStringAsync();

                var deserializedObject = JsonConvert.DeserializeObject<WeatherApiViewModel>(json);
                return deserializedObject;
            }   
        }
    }
}
