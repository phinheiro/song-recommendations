using Newtonsoft.Json;

namespace Conexia.SR.ExternalServices.ViewModels.SpotifyApi
{
    public class OwnerViewModel
    {
        [JsonProperty("display_name")]
        public string OwnerName { get; set; }
    }
}
