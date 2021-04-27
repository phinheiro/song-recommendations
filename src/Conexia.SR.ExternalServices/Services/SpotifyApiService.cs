using Conexia.SR.ExternalServices.Interfaces;
using Conexia.SR.ExternalServices.Settings;
using Conexia.SR.ExternalServices.ViewModels.SpotifyApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conexia.SR.ExternalServices.Services
{
    public class SpotifyApiService : ISpotifyApiService
    {
        private readonly string _authBaseUrl = "https://accounts.spotify.com/api";
        private readonly string _baseUrl = "https://api.spotify.com/v1";
        public async Task<SpotifyAuthResponse> GetAuthToken()
        {
            var action = $"{_authBaseUrl}/token";

            using (var httpClient = new HttpClient())
            {
                var credentialsBytes = Encoding.UTF8.GetBytes($"{SpotifyApiSettings.ClientId}:{SpotifyApiSettings.SecretId}");
                var encodedCredentials = Convert.ToBase64String(credentialsBytes);

                httpClient.DefaultRequestHeaders.Add("Authorization", $" Basic {encodedCredentials}");

                var formData = new List<KeyValuePair<string, string>>();
                var body = new KeyValuePair<string, string>("grant_type", "client_credentials");

                formData.Add(body);


                var data = new FormUrlEncodedContent(formData);

                var response = await httpClient.PostAsync(action, data);

                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SpotifyAuthResponse>(responseBody);
            }
        }

        public async Task<PlaylistsRootViewModel> GetPlaylists(string category, string accessToken)
        {
            var action = $"{_baseUrl}/browse/categories/{category}/playlists";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                var response = await httpClient.GetAsync(action);

                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PlaylistsRootViewModel>(responseBody);
            }
        }
    }
}
