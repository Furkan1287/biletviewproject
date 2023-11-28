using Microsoft.AspNetCore.Http;

namespace Domain.DTOs
{
    public class EventImageUploadDto
    {
        public Guid EventId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
