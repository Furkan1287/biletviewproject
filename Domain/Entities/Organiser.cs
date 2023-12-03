using Shared.Entities;

namespace Domain.Entities
{
    public class Organiser : BaseEntity
    {
        public string OrganiserName { get; set; }
        public IEnumerable<Event>? Events { get; set; }
    }
}
