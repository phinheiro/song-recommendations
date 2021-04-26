using Newtonsoft.Json;

namespace Conexia.SR.ExternalServices.ViewModels.SpotifyApi
{
    public class SpotifyAuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
