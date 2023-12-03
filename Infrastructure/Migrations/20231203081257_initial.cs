using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganiserName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VenueName = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    GoogleMapsSrc = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TicketCount = table.Column<int>(type: "integer", nullable: false),
                    IsFree = table.Column<bool>(type: "boolean", nullable: false),
                    PopularityCount = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganiserId = table.Column<Guid>(type: "uuid", nullable: false),
                    VenueId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Organisers_OrganiserId",
                        column: x => x.OrganiserId,
                        principalTable: "Organisers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventImages_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatedEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Seats = table.Column<IEnumerable<Seat>>(type: "jsonb", nullable: true),
                    IsSeatedEvent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatedEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatedEvents_Events_Id",
                        column: x => x.Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandingEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    IsSeatedEvent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandingEvents_Events_Id",
                        column: x => x.Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate" },
                values: new object[] { new Guid("3addf918-37e5-4b06-9ffc-17af03ec7878"), "Tiyatro", new DateTime(2023, 12, 3, 8, 12, 57, 893, DateTimeKind.Utc).AddTicks(7671) });

            migrationBuilder.InsertData(
                table: "Organisers",
                columns: new[] { "Id", "CreatedDate", "OrganiserName" },
                values: new object[] { new Guid("fe796e28-329c-4d71-bcfe-97c70e913b4e"), new DateTime(2023, 12, 3, 8, 12, 57, 893, DateTimeKind.Utc).AddTicks(8163), "Fırat Tanış" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "CreatedDate", "District", "GoogleMapsSrc", "Province", "VenueName" },
                values: new object[] { new Guid("2449f9f5-31b8-4cc4-a80d-815923e121ca"), "Kuştepe, Kuştepe Trump Alışveriş Merkezi, Mecidiyeköy Yolu Cd. No:12, 34387", new DateTime(2023, 12, 3, 8, 12, 57, 893, DateTimeKind.Utc).AddTicks(8531), "Şişli", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3007.9481497843817!2d28.99002567656014!3d41.070126015613425!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab6fbf4fb50f5%3A0x2c60541c9e93c923!2sTrump%20K%C3%BClt%C3%BCr%20Ve%20G%C3%B6steri%20Merkezi!5e0!3m2!1str!2str!4v1701547065585!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "İstanbul", "Trump Sahne" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "EndDate", "IsFree", "Name", "OrganiserId", "PopularityCount", "StartDate", "TicketCount", "VenueId" },
                values: new object[] { new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"), new Guid("3addf918-37e5-4b06-9ffc-17af03ec7878"), new DateTime(2023, 12, 3, 8, 12, 57, 895, DateTimeKind.Utc).AddTicks(7014), "Semih Çelenk’in yazdığı ve yönettiği “Gelin Tanış Olalım”da Fırat Tanış’ bir Abdal hikayesi ile sahneye çıkıyor.", new DateTime(2023, 12, 3, 8, 12, 57, 895, DateTimeKind.Utc).AddTicks(7016), true, "Fırat Tanış ile Gelin Tanış Olalım Oyunu", new Guid("fe796e28-329c-4d71-bcfe-97c70e913b4e"), 0L, new DateTime(2023, 12, 3, 8, 12, 57, 895, DateTimeKind.Utc).AddTicks(7015), 500, new Guid("2449f9f5-31b8-4cc4-a80d-815923e121ca") });

            migrationBuilder.InsertData(
                table: "EventImages",
                columns: new[] { "Id", "CreatedDate", "EventId", "ImageUrl" },
                values: new object[,]
                {
                    { new Guid("495400ec-7296-415d-8614-9e2aaf955b4f"), new DateTime(2023, 12, 3, 8, 12, 57, 893, DateTimeKind.Utc).AddTicks(9023), new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"), "/images/495400ec7296415d86149e2aaf955b4f.jpg" },
                    { new Guid("afcddc37-e2cc-4700-881c-189a9df99545"), new DateTime(2023, 12, 3, 8, 12, 57, 893, DateTimeKind.Utc).AddTicks(9027), new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"), "/images/afcddc37e2cc4700881c189a9df99545.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SeatedEvents",
                columns: new[] { "Id", "IsSeatedEvent", "Seats" },
                values: new object[] { new Guid("aa28c74d-c83b-47d0-936d-7d57072d6cd8"), true, null });

            migrationBuilder.CreateIndex(
                name: "IX_EventImages_EventId",
                table: "EventImages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganiserId",
                table: "Events",
                column: "OrganiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventImages");

            migrationBuilder.DropTable(
                name: "SeatedEvents");

            migrationBuilder.DropTable(
                name: "StandingEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Organisers");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
