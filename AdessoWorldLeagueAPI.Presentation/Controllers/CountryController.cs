using AdessoWorldLeagueAPI.DataAccess.Context;
using AdessoWorldLeagueAPI.DataAccess.Repositories;
using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using AdessoWorldLeagueAPI.Presentation.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoWorldLeagueAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("GetAllCountries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("/GetById/{id}")]
        public async Task<ActionResult<Country>> GetById(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult> AddCountry([FromBody] CountryDTO countryDto)
        {
            var country = new Country
            {
                Name = countryDto.CountryName,
            };
            await _countryRepository.AddAsync(country);
            return CreatedAtAction(nameof(GetById), new { id = country.Id }, country);
        }

        [HttpDelete("/DeleteCountry/{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            await _countryRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
