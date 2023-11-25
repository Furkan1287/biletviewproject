using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public async Task<ActionResult<List<StandingEvent>>> GetStandingEvents()
        {
            var events = await _standingEventService.GetEventsAsync();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<StandingEvent>> GetStandingEvent(Guid eventId)
        {
            var eventItem = await _standingEventService.GetEventByIdAsync(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<ActionResult<StandingEvent>> CreateStandingEvent(StandingEvent eventItem)
        {
            await _standingEventService.CreateEventAsync(eventItem);
            return CreatedAtAction(nameof(GetStandingEvent), new { eventId = eventItem.Id }, eventItem);
        }

        [HttpPut("{eventId}")]
        public async Task<ActionResult> UpdateStandingEvent(StandingEvent eventItem)
        {
            var eventExist = await _standingEventService.GetEventByIdAsync(eventItem.Id);
            if (eventExist == null)
            {
                return NotFound();
            }

            await _standingEventService.UpdateEventAsync(eventItem);

            return Ok();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteStandingEvent(Guid eventId)
        {
            var eventItem = await _standingEventService.GetEventByIdAsync(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            await _standingEventService.DeleteEventAsync(eventId);

            return Ok();
        }
        #endregion
    }
}
