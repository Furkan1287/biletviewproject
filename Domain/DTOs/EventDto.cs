using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class EventRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketCount { get; set; }
        public bool IsFree { get; set; }
        public IEnumerable<byte[]>? Images { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OrganizerId { get; set; }
        public Guid VenueId { get; set; }
    }
    
    public class SeatedEventRequestDto : EventRequestDto
    {
        public IEnumerable<Seat>? Seats { get; set; }
        public bool IsSeatedEvent { get => true; }
    }

    public class StandingEventRequestDto : EventRequestDto
    {
        public decimal? Price { get; set; }
        public bool IsSeatedEvent { get => false; }
    }
}
