using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using AdessoWorldLeagueAPI.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AdessoWorldLeagueAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ICountryRepository _countryRepository;

        public TeamsController(ITeamRepository teamRepository, ICountryRepository countryRepository)
        {
            _teamRepository = teamRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet("GetAllTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetAll()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("/GetTeamById/{id}")]
        public async Task<ActionResult<Team>> GetById(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost("AddTeam")]
        public async Task<ActionResult> AddTeam([FromBody] TeamDTO teamDto)
        {
            var country = await _countryRepository.GetByIdAsync(teamDto.countryId);
            if (country == null) return NotFound();

            var team = new Team
            {
                Name = teamDto.name,
                Country = country,
            };
            await _teamRepository.AddAsync(team);
            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        [HttpDelete("/DeleteTeam/{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await _teamRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
