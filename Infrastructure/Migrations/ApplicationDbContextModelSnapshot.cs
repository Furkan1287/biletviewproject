﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3addf918-37e5-4b06-9ffc-17af03ec7878"),
                            CategoryName = "Tiyatro",
                            CreatedDate = new DateTime(2023, 12, 3, 8, 26, 48, 142, DateTimeKind.Utc).AddTicks(9809)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSeatedEvent")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrganiserId")
                        .HasColumnType("uuid");

                    b.Property<long>("PopularityCount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TicketCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrganiserId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.EventImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventImages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("495400ec-7296-415d-8614-9e2aaf955b4f"),
                            CreatedDate = new DateTime(2023, 12, 3, 8, 26, 48, 143, DateTimeKind.Utc).AddTicks(1282),
                            EventId = new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"),
                            ImageUrl = "/images/495400ec7296415d86149e2aaf955b4f.jpg"
                        },
                        new
                        {
                            Id = new Guid("afcddc37-e2cc-4700-881c-189a9df99545"),
                            CreatedDate = new DateTime(2023, 12, 3, 8, 26, 48, 143, DateTimeKind.Utc).AddTicks(1299),
                            EventId = new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"),
                            ImageUrl = "/images/afcddc37e2cc4700881c189a9df99545.jpg"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Organiser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrganiserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organisers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe796e28-329c-4d71-bcfe-97c70e913b4e"),
                            CreatedDate = new DateTime(2023, 12, 3, 8, 26, 48, 143, DateTimeKind.Utc).AddTicks(402),
                            OrganiserName = "Fırat Tanış"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GoogleMapsSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Venues", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2449f9f5-31b8-4cc4-a80d-815923e121ca"),
                            Address = "Kuştepe, Kuştepe Trump Alışveriş Merkezi, Mecidiyeköy Yolu Cd. No:12, 34387",
                            CreatedDate = new DateTime(2023, 12, 3, 8, 26, 48, 143, DateTimeKind.Utc).AddTicks(767),
                            District = "Şişli",
                            GoogleMapsSrc = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3007.9481497843817!2d28.99002567656014!3d41.070126015613425!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab6fbf4fb50f5%3A0x2c60541c9e93c923!2sTrump%20K%C3%BClt%C3%BCr%20Ve%20G%C3%B6steri%20Merkezi!5e0!3m2!1str!2str!4v1701547065585!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                            Province = "İstanbul",
                            VenueName = "Trump Sahne"
                        });
                });

            modelBuilder.Entity("Domain.Entities.SeatedEvent", b =>
                {
                    b.HasBaseType("Domain.Entities.Event");

                    b.Property<IEnumerable<Seat>>("Seats")
                        .HasColumnType("jsonb");

                    b.ToTable("SeatedEvents", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"),
                            CategoryId = new Guid("3addf918-37e5-4b06-9ffc-17af03ec7878"),
                            CreatedDate = new DateTime(2023, 12, 3, 8, 26, 48, 144, DateTimeKind.Utc).AddTicks(9031),
                            Description = "Semih Çelenk’in yazdığı ve yönettiği “Gelin Tanış Olalım”da Fırat Tanış’ bir Abdal hikayesi ile sahneye çıkıyor.",
                            EndDate = new DateTime(2023, 12, 3, 8, 26, 48, 144, DateTimeKind.Utc).AddTicks(9035),
                            IsFree = true,
                            IsSeatedEvent = true,
                            Name = "Fırat Tanış ile Gelin Tanış Olalım Oyunu",
                            OrganiserId = new Guid("fe796e28-329c-4d71-bcfe-97c70e913b4e"),
                            PopularityCount = 0L,
                            StartDate = new DateTime(2023, 12, 3, 8, 26, 48, 144, DateTimeKind.Utc).AddTicks(9034),
                            TicketCount = 500,
                            VenueId = new Guid("2449f9f5-31b8-4cc4-a80d-815923e121ca")
                        });
                });

            modelBuilder.Entity("Domain.Entities.StandingEvent", b =>
                {
                    b.HasBaseType("Domain.Entities.Event");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.ToTable("StandingEvents", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Organiser", "Organiser")
                        .WithMany("Events")
                        .HasForeignKey("OrganiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Organiser");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Entities.EventImage", b =>
                {
                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Entities.SeatedEvent", b =>
                {
                    b.HasOne("Domain.Entities.Event", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.SeatedEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.StandingEvent", b =>
                {
                    b.HasOne("Domain.Entities.Event", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.StandingEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Domain.Entities.Organiser", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Domain.Entities.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
