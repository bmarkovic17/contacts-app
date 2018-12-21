using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AddressNumber", "City", "Country", "Street", "postcode" },
                values: new object[,]
                {
                    { 4, "110", "Greenville", "South Carolina, US", "Pooh Bear Lane", "29607" },
                    { 5, "3357", "Schenectady", "New York, US", "Golden Ridge Road", "12303" },
                    { 6, "2948", "Southfield", "Michigan, US", "Tuna Street", "48075" },
                    { 7, "4597", "Fort Lauderdale", "Florida, US", "Pointe Lane", "33308" },
                    { 8, "2382", "Baton Rouge", "Louisiana, US", "Eva Pearl Street", "70814" }
                });

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 1,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 5,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "AddressId", "DateOfBirth", "Name", "Surname" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(1971, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Wahlberg" },
                    { 5, 5, null, null, "Superman" },
                    { 6, 6, new DateTime(1980, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venus", "Williams" },
                    { 7, 7, new DateTime(1981, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serena", "Williams" },
                    { 8, 7, new DateTime(1955, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Gates" }
                });

            migrationBuilder.InsertData(
                table: "ContactData",
                columns: new[] { "ContactDataID", "ContactDataStatus", "ContactDataType", "ContactDataValue", "ContactId" },
                values: new object[,]
                {
                    { 8, "Y", "MAIL", "mark.wahlberg@mail.com", 4 },
                    { 9, "Y", "MAIL", "superman@mail.com", 5 },
                    { 10, "Y", "PHONE", "090/0000-002", 5 },
                    { 11, "Y", "PHONE", "090/0000-333", 6 },
                    { 12, "Y", "MAIL", "venus.williams@anothermail.com", 6 },
                    { 13, "Y", "MAIL", "serena.williams@anothermail.com", 7 },
                    { 14, "Y", "PHONE", "090/1000-100", 8 },
                    { 15, "Y", "MAIL", "bill.gates@mail.com", 8 }
                });

            migrationBuilder.InsertData(
                table: "ContactTag",
                columns: new[] { "ContactTagId", "ContactId", "ContactTagName" },
                values: new object[,]
                {
                    { 5, 4, "friend" },
                    { 6, 5, "friend" },
                    { 7, 8, "friend" },
                    { 8, 8, "business" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ContactTag",
                keyColumn: "ContactTagId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContactTag",
                keyColumn: "ContactTagId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContactTag",
                keyColumn: "ContactTagId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContactTag",
                keyColumn: "ContactTagId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 1,
                column: "ContactDataStatus",
                value: "M");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 5,
                column: "ContactDataStatus",
                value: "M");
        }
    }
}
