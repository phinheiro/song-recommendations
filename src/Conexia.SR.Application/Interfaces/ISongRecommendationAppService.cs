using Conexia.SR.ExternalServices.ViewModels.SpotifyApi;
using System.Threading.Tasks;

namespace Conexia.SR.Application.Interfaces
{
    public interface ISongRecommendationAppService
    {
        Task<PlaylistsRootViewModel> GetRecommendations(string hometown);
    }
}
