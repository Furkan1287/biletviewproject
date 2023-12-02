namespace Domain.DTOs
{
    public class CategoryDetailDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class CategoryCreateDto
    {
        public string CategoryName { get; set; }
    }
}
