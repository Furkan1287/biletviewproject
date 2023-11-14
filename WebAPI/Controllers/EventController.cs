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
            var events = await _eventService.GetEvents();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> GetEvent(Guid eventId)
        {
            var eventItem = await _eventService.GetEventById(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }

            return eventItem;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event eventItem)
        {
            await _eventService.CreateEvent(eventItem);
            return CreatedAtAction(nameof(GetEvent), new { eventId = eventItem.Id }, eventItem);
        }

        [HttpPut("{eventId}")]
        public async Task<ActionResult> UpdateEvent(Event eventItem)
        {
            var eventExist = await _eventService.GetEventById(eventItem.Id);
            if (eventExist == null)
            {
                return NotFound();
            }

            await _eventService.UpdateEvent(eventItem);

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            var eventItem = await _eventService.GetEventById(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEvent(eventId);

            return NoContent();
        }
    }
}
