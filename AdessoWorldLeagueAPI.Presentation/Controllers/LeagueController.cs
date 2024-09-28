using AdessoWorldLeagueAPI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AdessoWorldLeagueAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {

        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet("generate")]
        public async Task<ActionResult<List<Group>>> GenerateGroupAsync(int numberOfGroups, int teamsPerGroup)
        { 
            var groups = await _leagueService.GenerateGroupAsync(numberOfGroups, teamsPerGroup);
            return Ok(groups);
        }

    }
}
