using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "event")]
    [ApiController]
    public class SeatedEventController : ControllerBase
    {
        private readonly ISeatedEventService _seatedEventService;

        public SeatedEventController(ISeatedEventService seatedEventService)
        {
            _seatedEventService = seatedEventService;
        }

        #region # Seated Events
        [HttpPost]
        public async Task<IActionResult> CreateSeatedEvent(SeatedEventCreateDto eventItem)
        {
            
            var result = await _seatedEventService.CreateEventAsync(eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateSeatedEvent(SeatedEvent eventItem)
        {
            var result = await _seatedEventService.UpdateEventAsync(eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteSeatedEvent(Guid eventId)
        {
            var result = await _seatedEventService.DeleteEventAsync(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
