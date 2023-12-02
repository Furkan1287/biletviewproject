using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);

            var category = new Category
            {
                Id = Guid.Parse("3addf918-37e5-4b06-9ffc-17af03ec7878"),
                CategoryName = "Tiyatro",
                CreatedDate = DateTime.UtcNow,
            };

            builder.HasData(category);
        }
    }
}
