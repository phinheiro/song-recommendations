using Newtonsoft.Json;

namespace Conexia.SR.ExternalServices.ViewModels.SpotifyApi
{
    public class PlaylistViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("external_urls")]
        public UrlsViewModel ExternalUrls { get; set; }
        public OwnerViewModel Owner { get; set; }
    }
}
