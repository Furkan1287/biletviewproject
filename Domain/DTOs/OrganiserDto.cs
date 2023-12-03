namespace Domain.DTOs
{
    public class OrganiserDetailDto
    {
        public Guid Id { get; set; }
        public string OrganiserName { get; set; }
    }

    public class OrganiserCreateDto
    {
        public string OrganiserName { get; set; }
    }
}
