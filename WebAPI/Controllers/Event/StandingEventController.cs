using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingEventController : ControllerBase
    {
        private readonly IStandingEventService _standingEventService;

        public StandingEventController(IStandingEventService standingEventService)
        {
            _standingEventService = standingEventService;
        }

        #region # Standing Events
        [HttpPost]
        public async Task<IActionResult> CreateStandingEvent(StandingEventCreateDto eventItem)
        {
            var result = await _standingEventService.CreateEventAsync(eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateStandingEvent(StandingEvent eventItem)
        {
            var result = await _standingEventService.UpdateEventAsync(eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteStandingEvent(Guid eventId)
        {
            var result = await _standingEventService.DeleteEventAsync(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
