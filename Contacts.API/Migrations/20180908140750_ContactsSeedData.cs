using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class ContactsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "DateOfBirth", "Name", "Surname" },
                values: new object[] { 1, "8106 Linda Ave., Schenectady, NY 12302", new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu", "Reeves" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "DateOfBirth", "Name", "Surname" },
                values: new object[] { 2, "7201 N. Roehampton Ave., Easton, PA 18042", new DateTime(1971, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elon", "Musk" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "DateOfBirth", "Name", "Surname" },
                values: new object[] { 3, "Erlenweg 57, 3027 Bern, Switzerland", new DateTime(1981, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roger", "Federer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3);
        }
    }
}
