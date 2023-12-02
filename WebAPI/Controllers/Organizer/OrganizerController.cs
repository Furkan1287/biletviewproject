using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Organizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        readonly IOrganizerService _organizerService;

        public OrganizerController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        #region Organizers

        [HttpGet]
        public async Task<ActionResult<List<OrganizerDetailDto>>> GetOrginazers()
        {
            var organizers = await _organizerService.GetOrganizersAsync();
            return Ok(organizers);
        }

        [HttpGet("{organizerId}")]
        public async Task<ActionResult<OrganizerDetailDto>> GetOrganizerById(Guid organizerId)
        {
            var result = await _organizerService.GetOrganizerByIdAsync(organizerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganizer(OrganizerCreateDto organizerCreateDto)
        {
            var result = await _organizerService.CreateOrganizerAsync(organizerCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{organizerId}")]
        public async Task<IActionResult> UpdateOrganizer(Domain.Entities.Organizer organizer)
        {
            var result = await _organizerService.UpdateOrganizerAsync(organizer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{organizerId}")]
        public async Task<IActionResult> DeleteOrganizer(Guid organizerId)
        {
            var result = await _organizerService.DeleteOrganizerAsync(organizerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
