using Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public Event() => PopularityCount = 0;

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketCount { get; set; }
        public bool IsFree { get; set; }
        public long PopularityCount { get; set; }
        public IEnumerable<EventImage>? Images { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OrganiserId { get; set; }
        public Guid VenueId { get; set; }
        public Category? Category { get; set; }
        public Organiser? Organiser { get; set; }
        public Venue? Venue { get; set; }
    }

    public class SeatedEvent : Event
    {
        public SeatedEvent() => IsSeatedEvent = true;

        [Column(TypeName = "jsonb")]
        public IEnumerable<Seat>? Seats { get; set; }
        public bool IsSeatedEvent { get; set; }
    }

    public class StandingEvent : Event
    {
        public StandingEvent() => IsSeatedEvent = false;

        public decimal? Price { get; set; }
        public bool IsSeatedEvent { get; set; }
    }
}
