using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class OrganizerEntityTypeConfiguration
        : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.ToTable("Organizers");
            builder.HasKey(o => o.Id);

            var organizer = new Organizer
            {
                Id = Guid.Parse("fe796e28-329c-4d71-bcfe-97c70e913b4e"),
                CreatedDate = DateTime.UtcNow,
                OrganizerName = "Fırat Tanış"
            };

            builder.HasData(organizer);
        }
    }
}
