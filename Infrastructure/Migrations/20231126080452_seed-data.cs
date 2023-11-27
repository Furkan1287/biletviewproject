using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cdbf23c9-2cc4-4306-ad0f-9fb6700b4d47"));

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: new Guid("685b2b74-8792-40e4-8f91-d44f19f0bfbf"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("a5b83076-ac2b-4495-acf9-fb3b2202f01e"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate" },
                values: new object[] { new Guid("cdbf23c9-2cc4-4306-ad0f-9fb6700b4d47"), "TEST_Category", new DateTime(2023, 11, 26, 11, 3, 58, 198, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "CreatedDate", "OrganizerName" },
                values: new object[] { new Guid("685b2b74-8792-40e4-8f91-d44f19f0bfbf"), new DateTime(2023, 11, 26, 11, 3, 58, 198, DateTimeKind.Local).AddTicks(7421), "TEST_Organizer" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "CreatedDate", "District", "GoogleMapsSrc", "Province", "VenueName" },
                values: new object[] { new Guid("a5b83076-ac2b-4495-acf9-fb3b2202f01e"), new DateTime(2023, 11, 26, 11, 3, 58, 198, DateTimeKind.Local).AddTicks(7397), "TEST_District", "TEST_GoogleMapsSrc", "TEST_Province", "TEST_Venue" });
        }
    }
}
