using Newtonsoft.Json;

namespace Conexia.SR.ExternalServices.ViewModels.SpotifyApi
{
    public class UrlsViewModel
    {
        [JsonProperty("spotify")]
        public string Link { get; set; }
    }
}
