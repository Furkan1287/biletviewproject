using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class eventimagemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a19a302e-7e34-4336-8693-f7ddeda86e3c"));

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: new Guid("eab991b2-ed5b-4117-8e2b-4789863928ef"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("29f54e61-2127-4baa-9564-9106e05b15ca"));

            migrationBuilder.CreateTable(
                name: "EventImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate" },
                values: new object[] { new Guid("2bc4f95a-a7a7-46e6-ad89-85ff47a99991"), "TEST_Category", new DateTime(2023, 11, 28, 5, 45, 16, 85, DateTimeKind.Utc).AddTicks(3013) });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "CreatedDate", "OrganizerName" },
                values: new object[] { new Guid("38afd218-4104-4f23-9241-a7ee890e3448"), new DateTime(2023, 11, 28, 5, 45, 16, 85, DateTimeKind.Utc).AddTicks(3011), "TEST_Organizer" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "CreatedDate", "District", "GoogleMapsSrc", "Province", "VenueName" },
                values: new object[] { new Guid("21cd2639-4d21-47b3-8bf6-c78e77122a0e"), new DateTime(2023, 11, 28, 5, 45, 16, 85, DateTimeKind.Utc).AddTicks(3004), "TEST_District", "TEST_GoogleMapsSrc", "TEST_Province", "TEST_Venue" });

            migrationBuilder.CreateIndex(
                name: "IX_EventImages_EventId",
                table: "EventImages",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventImages");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2bc4f95a-a7a7-46e6-ad89-85ff47a99991"));

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: new Guid("38afd218-4104-4f23-9241-a7ee890e3448"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("21cd2639-4d21-47b3-8bf6-c78e77122a0e"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate" },
                values: new object[] { new Guid("a19a302e-7e34-4336-8693-f7ddeda86e3c"), "TEST_Category", new DateTime(2023, 11, 26, 8, 4, 52, 827, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "CreatedDate", "OrganizerName" },
                values: new object[] { new Guid("eab991b2-ed5b-4117-8e2b-4789863928ef"), new DateTime(2023, 11, 26, 8, 4, 52, 827, DateTimeKind.Utc).AddTicks(76), "TEST_Organizer" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "CreatedDate", "District", "GoogleMapsSrc", "Province", "VenueName" },
                values: new object[] { new Guid("29f54e61-2127-4baa-9564-9106e05b15ca"), new DateTime(2023, 11, 26, 8, 4, 52, 827, DateTimeKind.Utc).AddTicks(73), "TEST_District", "TEST_GoogleMapsSrc", "TEST_Province", "TEST_Venue" });
        }
    }
}
