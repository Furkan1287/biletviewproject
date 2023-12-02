using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Venue
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "venue")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        #region Venues
        [HttpGet]
        public async Task<ActionResult<List<VenueDetailDto>>> GetVenues()
        {
            var result = await _venueService.GetVenuesAsync();
            return Ok(result);
        }

        [HttpGet("{venueId}")]
        public async Task<ActionResult<VenueDetailDto>> GetVenueById(Guid venueId)
        {
            var result = await _venueService.GetVenueByIdAsync(venueId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenue(VenueCreateDto venueCreateDto)
        {
            var result = await _venueService.CreateVenueAsync(venueCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{venueId}")]
        public async Task<IActionResult> UpdateVenue(Domain.Entities.Venue venue)
        {
            var result = await _venueService.UpdateVenueAsync(venue);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{venueId}")]
        public async Task<IActionResult> DeleteVenue(Guid venueId)
        {
            var result = await _venueService.DeleteVenueAsync(venueId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
