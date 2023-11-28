using Domain.Entities;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventImage> EventImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VenueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SeatedEventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StandingEventEntityTypeConfiguration());

            var venueData = new Venue
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                District = "TEST_District",
                VenueName = "TEST_Venue",
                Province = "TEST_Province",
                GoogleMapsSrc = "TEST_GoogleMapsSrc"
            };

            var organizerData = new Organizer
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                OrganizerName = "TEST_Organizer"
            };

            var categoryData = new Category
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                CategoryName = "TEST_Category",
            };

            modelBuilder.Entity<Venue>().HasData(venueData);
            modelBuilder.Entity<Organizer>().HasData(organizerData);
            modelBuilder.Entity<Category>().HasData(categoryData);
        }
    }
}
