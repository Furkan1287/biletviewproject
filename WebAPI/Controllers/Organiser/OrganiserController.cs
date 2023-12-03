using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Organiser
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "organiser")]
    [ApiController]
    public class OrganiserController : ControllerBase
    {
        readonly IOrganiserService _organiserService;

        public OrganiserController(IOrganiserService organiserService)
        {
            _organiserService = organiserService;
        }

        #region Organisers

        [HttpGet]
        public async Task<ActionResult<List<OrganiserDetailDto>>> GetOrginazers()
        {
            var organisers = await _organiserService.GetOrganisersAsync();
            return Ok(organisers);
        }

        [HttpGet("{organiserId}")]
        public async Task<ActionResult<OrganiserDetailDto>> GetOrganiserById(Guid organiserId)
        {
            var result = await _organiserService.GetOrganiserByIdAsync(organiserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganiser(OrganiserCreateDto organiserCreateDto)
        {
            var result = await _organiserService.CreateOrganiserAsync(organiserCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{organiserId}")]
        public async Task<IActionResult> UpdateOrganiser(Domain.Entities.Organiser organiser)
        {
            var result = await _organiserService.UpdateOrganiserAsync(organiser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{organiserId}")]
        public async Task<IActionResult> DeleteOrganiser(Guid organiserId)
        {
            var result = await _organiserService.DeleteOrganiserAsync(organiserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
