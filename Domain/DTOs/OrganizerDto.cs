namespace Domain.DTOs
{
    public class OrganizerDetailDto
    {
        public Guid Id { get; set; }
        public string OrganizerName { get; set; }
    }

    public class OrganizerCreateDto
    {
        public string OrganizerName { get; set; }
    }
}
