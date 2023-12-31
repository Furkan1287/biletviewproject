﻿using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "event")]
    [ApiController]
    public class EventImageController : ControllerBase
    {
        readonly IEventImageService _eventImageService;

        public EventImageController(IEventImageService eventImageService)
        {
            _eventImageService = eventImageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadEventImage([FromForm] EventImageUploadDto? eventImageUploadDto)
        {
            var result = await _eventImageService.UploadImage(eventImageUploadDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeleteEventImage(Guid imageId)
        {
            var result = await _eventImageService.DeleteImage(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
