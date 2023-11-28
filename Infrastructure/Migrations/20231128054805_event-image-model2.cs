using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class eventimagemodel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("a810e92a-6b48-4365-b32d-93bd6e039336"), "TEST_Category", new DateTime(2023, 11, 28, 5, 48, 5, 534, DateTimeKind.Utc).AddTicks(6894) });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "CreatedDate", "OrganizerName" },
                values: new object[] { new Guid("b44c0bad-3aba-4d51-8d51-dade04a83fde"), new DateTime(2023, 11, 28, 5, 48, 5, 534, DateTimeKind.Utc).AddTicks(6891), "TEST_Organizer" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "CreatedDate", "District", "GoogleMapsSrc", "Province", "VenueName" },
                values: new object[] { new Guid("36983bfe-0713-49e0-9452-2fb96de72796"), new DateTime(2023, 11, 28, 5, 48, 5, 534, DateTimeKind.Utc).AddTicks(6875), "TEST_District", "TEST_GoogleMapsSrc", "TEST_Province", "TEST_Venue" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a810e92a-6b48-4365-b32d-93bd6e039336"));

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: new Guid("b44c0bad-3aba-4d51-8d51-dade04a83fde"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("36983bfe-0713-49e0-9452-2fb96de72796"));

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
        }
    }
}
