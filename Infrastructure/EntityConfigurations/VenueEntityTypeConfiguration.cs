using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class VenueEntityTypeConfiguration
        : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable("Venues");
            builder.HasKey(v => v.Id);

            var venue = new Venue
            {
                Id = Guid.Parse("2449f9f5-31b8-4cc4-a80d-815923e121ca"),
                CreatedDate = DateTime.UtcNow,
                VenueName = "Trump Sahne",
                Province = "İstanbul",
                District = "Şişli",
                Address = "Kuştepe, Kuştepe Trump Alışveriş Merkezi, Mecidiyeköy Yolu Cd. No:12, 34387",
                GoogleMapsSrc = @"<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3007.9481497843817!2d28.99002567656014!3d41.070126015613425!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab6fbf4fb50f5%3A0x2c60541c9e93c923!2sTrump%20K%C3%BClt%C3%BCr%20Ve%20G%C3%B6steri%20Merkezi!5e0!3m2!1str!2str!4v1701547065585!5m2!1str!2str"" width=""600"" height=""450"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>"
            };

            builder.HasData(venue);
        }
    }
}
