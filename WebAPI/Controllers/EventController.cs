using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEvents()
        {
            var events = await _eventService.GetEventsAsync();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> GetEvent(Guid eventId)
        {
            var eventItem = await _eventService.GetEventByIdAsync(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event eventItem)
        {
            await _eventService.CreateEventAsync(eventItem);
            return CreatedAtAction(nameof(GetEvent), new { eventId = eventItem.Id }, eventItem);
        }

        [HttpPut("{eventId}")]
        public async Task<ActionResult> UpdateEvent(Event eventItem)
        {
            var eventExist = await _eventService.GetEventByIdAsync(eventItem.Id);
            if (eventExist == null)
            {
                return NotFound();
            }

            await _eventService.UpdateEventAsync(eventItem);

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            var eventItem = await _eventService.GetEventByIdAsync(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEventAsync(eventId);

            return NoContent();
        }
    }
}
