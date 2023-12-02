using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class EventImageEntityTypeConfiguration
        :  IEntityTypeConfiguration<EventImage>
    {
        public void Configure(EntityTypeBuilder<EventImage> builder)
        {
            builder.ToTable("EventImages");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ImageUrl)
                .HasMaxLength(int.MaxValue);

            var eventImage = new List<EventImage>
            {
                new() { Id = Guid.Parse("495400ec-7296-415d-8614-9e2aaf955b4f"), CreatedDate = DateTime.UtcNow, EventId = Guid.Parse("aa28c74d-c83b-47d0-936d-7d57072d6cd8"), ImageUrl = "/images/495400ec7296415d86149e2aaf955b4f.jpg" },
                new() { Id = Guid.Parse("afcddc37-e2cc-4700-881c-189a9df99545"), CreatedDate = DateTime.UtcNow, EventId = Guid.Parse("aa28c74d-c83b-47d0-936d-7d57072d6cd8"), ImageUrl = "/images/afcddc37e2cc4700881c189a9df99545.jpg" }
            };

            builder.HasData(eventImage);
        }
    }
}
