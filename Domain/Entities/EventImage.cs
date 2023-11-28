using Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class EventImage : BaseEntity
    {
        [Column(TypeName ="bytea")]
        public byte[] Image { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }

    }
}
