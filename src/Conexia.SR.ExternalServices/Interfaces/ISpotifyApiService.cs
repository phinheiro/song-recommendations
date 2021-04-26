using Conexia.SR.ExternalServices.ViewModels.SpotifyApi;
using System.Threading.Tasks;

namespace Conexia.SR.ExternalServices.Interfaces
{
    public interface ISpotifyApiService
    {
        Task<PlaylistsRootViewModel> GetPlaylists(string category, string accessToken);
        Task<SpotifyAuthResponse> GetAuthToken();
    }
}
