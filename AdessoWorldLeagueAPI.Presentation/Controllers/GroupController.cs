using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using AdessoWorldLeagueAPI.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace AdessoWorldLeagueAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet("GetAllGroups")]
        public async Task<ActionResult<IEnumerable<AdessoGroup>>> GetAll()
        {
            var groups = await _groupRepository.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("/GetGroupById/{id}")]
        public async Task<ActionResult<AdessoGroup>> GetById(int id)
        {
            var AdessoGroup = await _groupRepository.GetByIdAsync(id);
            if (AdessoGroup == null) return NotFound();
            return Ok(AdessoGroup);
        }

        [HttpPost("AddGroup")]
        public async Task<ActionResult> AddGroup([FromBody] GroupDTO AdessoGroupDto)
        {
            var group = new AdessoGroup
            {
                GroupName = AdessoGroupDto.GroupName,
            };

            await _groupRepository.AddAsync(group);
            return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
        }

        [HttpDelete("/DeleteGroup/{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            await _groupRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
