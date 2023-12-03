using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class OrganiserEntityTypeConfiguration
        : IEntityTypeConfiguration<Organiser>
    {
        public void Configure(EntityTypeBuilder<Organiser> builder)
        {
            builder.ToTable("Organisers");
            builder.HasKey(o => o.Id);

            var organiser = new Organiser
            {
                Id = Guid.Parse("fe796e28-329c-4d71-bcfe-97c70e913b4e"),
                CreatedDate = DateTime.UtcNow,
                OrganiserName = "Fırat Tanış"
            };

            builder.HasData(organiser);
        }
    }
}
