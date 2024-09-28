using AdessoWorldLeagueAPI.Business.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using AdessoWorldLeagueAPI.Presentation.DTO;
using Azure.Core;
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

        [HttpPost("GenerateGroups")]
        public async Task<ActionResult<List<AdessoGroup>>> GenerateGroupAsync([FromBody] DrawDTO drawDTO)
        {
            if (string.IsNullOrWhiteSpace(drawDTO.DrawerName) || string.IsNullOrWhiteSpace(drawDTO.DrawerSurname))
            {
                return BadRequest("DrawnBy cannot be empty.");
            }

            if (drawDTO.GroupCount != 4 && drawDTO.GroupCount != 8)
            {
                return BadRequest("Group count must be 4 or 8.");
            }

            var groups = await _leagueService.GenerateGroupAsync(drawDTO.GroupCount, drawDTO.DrawerName, drawDTO.DrawerSurname);
            return Ok(groups);
        }

    }
}
