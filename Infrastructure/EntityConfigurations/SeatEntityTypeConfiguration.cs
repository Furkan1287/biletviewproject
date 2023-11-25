using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityConfigurations
{
    public class SeatEntityTypeConfiguration
        : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(s => s.SeatNumber);
            builder.Property(s => s.SeatType)
                .HasConversion(new EnumToStringConverter<SeatType>());
        }
    }
}
