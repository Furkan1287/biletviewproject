using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatedEventController : ControllerBase
    {
        private readonly ISeatedEventService _seatedEventService;

        public SeatedEventController(ISeatedEventService seatedEventService)
        {
            _seatedEventService = seatedEventService;
        }

        #region # Seated Events
        [HttpGet]
        public async Task<ActionResult<List<SeatedEvent>>> GetSeatedEvents()
        {
            var events = await _seatedEventService.GetEventsAsync();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<SeatedEvent>> GetSeatedEvent(Guid eventId)
        {
            var eventItem = await _seatedEventService.GetEventByIdAsync(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<ActionResult<SeatedEvent>> CreateSeatedEvent(SeatedEventRequestDto eventItem)
        {
            
            var result = await _seatedEventService.CreateEventAsync(eventItem);
            return CreatedAtAction("Created", eventItem);
        }

        [HttpPut("{eventId}")]
        public async Task<ActionResult> UpdateSeatedEvent(SeatedEvent eventItem)
        {
            var eventExist = await _seatedEventService.GetEventByIdAsync(eventItem.Id);
            if (eventExist == null)
            {
                return NotFound();
            }

            await _seatedEventService.UpdateEventAsync(eventItem);

            return Ok();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteSeatedEvent(Guid eventId)
        {
            var eventItem = await _seatedEventService.GetEventByIdAsync(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            await _seatedEventService.DeleteEventAsync(eventId);

            return Ok();
        }
        #endregion
    }
}
