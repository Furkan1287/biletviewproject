using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDetailDto>>> GetAll()
        {
            var result = await _eventService.GetEvents();
            return Ok(result);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDetailDto>> GetById(Guid eventId)
        {
            var result = await _eventService.GetEventById(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("pastevents")]
        public async Task<ActionResult<List<EventDetailDto>>> GetPastEvents()
        {
            var result = await _eventService.GetPastEvents();
            return Ok(result);
        }
    }
}
