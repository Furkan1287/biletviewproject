using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Infrastructure.EntityConfigurations
{
    public class EventEntityTypeConfiguration
        : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Events);

            builder.HasOne(e => e.Organiser)
                .WithMany(e => e.Events);

            builder.HasOne(e => e.Venue)
                .WithMany(e => e.Events);

            builder.HasMany(e => e.Images)
                .WithOne(e => e.Event);
        }
    }

    public class SeatedEventEntityTypeConfiguration
        : IEntityTypeConfiguration<SeatedEvent>
    {
        public void Configure(EntityTypeBuilder<SeatedEvent> builder)
        {
            builder.ToTable("SeatedEvents")
                .HasBaseType<Event>();

            var seatedEvent = new SeatedEvent
            {
                Id = Guid.Parse("aa28c74d-c83b-47d0-936d-7d57072d6cd8"),
                CreatedDate = DateTime.UtcNow,
                Name = "Fırat Tanış ile Gelin Tanış Olalım Oyunu",
                Description = "Semih Çelenk’in yazdığı ve yönettiği “Gelin Tanış Olalım”da Fırat Tanış’ bir Abdal hikayesi ile sahneye çıkıyor.",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                TicketCount = 500,
                IsFree = true,
                IsSeatedEvent = true,
                CategoryId = Guid.Parse("3addf918-37e5-4b06-9ffc-17af03ec7878"),
                OrganiserId = Guid.Parse("fe796e28-329c-4d71-bcfe-97c70e913b4e"),
                VenueId = Guid.Parse("2449f9f5-31b8-4cc4-a80d-815923e121ca")
            };

            builder.HasData(seatedEvent);
        }
    }

    public class StandingEventEntityTypeConfiguration
        : IEntityTypeConfiguration<StandingEvent>
    {
        public void Configure(EntityTypeBuilder<StandingEvent> builder)
        {
            builder.ToTable("StandingEvents")
                .HasBaseType<Event>();

        }
    }
}
