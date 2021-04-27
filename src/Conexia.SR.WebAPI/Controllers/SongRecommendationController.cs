using Conexia.SR.Application.Interfaces;
using Conexia.SR.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Conexia.SR.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SongRecommendationController : ControllerBase
    {
        private readonly ISongRecommendationAppService _recommendationAppService;
        private readonly UserManager<ApplicationUser> _userManager;
        public SongRecommendationController(ISongRecommendationAppService recommendationAppService, UserManager<ApplicationUser> userManager)
        {
            _recommendationAppService = recommendationAppService;
            _userManager = userManager;
        }

        /// <summary>
        /// Get playlists recommendation based on user's hometown temperature
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRecommendations()
        {
            var user = await _userManager.GetUserAsync(User);
            var recommendation = await _recommendationAppService.GetRecommendations(user.Hometown);

            return Ok(recommendation);
        }
    }
}
