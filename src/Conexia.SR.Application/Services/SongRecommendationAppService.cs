using Conexia.SR.Application.Interfaces;
using Conexia.SR.ExternalServices.Interfaces;
using Conexia.SR.ExternalServices.ViewModels.SpotifyApi;
using System;
using System.Threading.Tasks;

namespace Conexia.SR.Application.Services
{
    public class SongRecommendationAppService : ISongRecommendationAppService
    {
        private readonly ISpotifyApiService _spotifyApiService;
        private readonly IWeatherApiService _weatherApiService;

        public SongRecommendationAppService(ISpotifyApiService spotifyApiService, IWeatherApiService weatherApiService)
        {
            _spotifyApiService = spotifyApiService;
            _weatherApiService = weatherApiService;
        }

        public async Task<PlaylistsRootViewModel> GetRecommendations(string hometown)
        {
            var weatherInfo = await _weatherApiService.GetCurrentTemperature(hometown);
            var auth = await _spotifyApiService.GetAuthToken();

            var hometownTemperature = (int)Math.Round(weatherInfo.Main.Temp);
            var category = SelectCategory(hometownTemperature);

            return await _spotifyApiService.GetPlaylists(category, auth.AccessToken);
        }

        private string SelectCategory(int temperature)
        {
            if (temperature > 30) return "party";
            else if (temperature >= 15) return "pop";
            else if (temperature >= 10) return "rock";
            else return "classical";
        }
    }
}
