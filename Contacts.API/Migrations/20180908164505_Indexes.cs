using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactTag_ContactId",
                table: "ContactTag");

            migrationBuilder.DropIndex(
                name: "IX_ContactData_ContactId",
                table: "ContactData");

            migrationBuilder.AlterColumn<string>(
                name: "ContactTagName",
                table: "ContactTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ContactTag_ContactId_ContactTagName",
                table: "ContactTag",
                columns: new[] { "ContactId", "ContactTagName" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ContactData_ContactId_ContactDataType_ContactDataValue",
                table: "ContactData",
                columns: new[] { "ContactId", "ContactDataType", "ContactDataValue" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Address_Street_AddressNumber_postcode_City_Country",
                table: "Address",
                columns: new[] { "Street", "AddressNumber", "postcode", "City", "Country" });

            migrationBuilder.CreateIndex(
                name: "ContactTagNameIDX",
                table: "ContactTag",
                column: "ContactTagName");

            migrationBuilder.CreateIndex(
                name: "ContactNameIDX",
                table: "Contacts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "ContactSurnameIDX",
                table: "Contacts",
                column: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ContactTag_ContactId_ContactTagName",
                table: "ContactTag");

            migrationBuilder.DropIndex(
                name: "ContactTagNameIDX",
                table: "ContactTag");

            migrationBuilder.DropIndex(
                name: "ContactNameIDX",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "ContactSurnameIDX",
                table: "Contacts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ContactData_ContactId_ContactDataType_ContactDataValue",
                table: "ContactData");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Address_Street_AddressNumber_postcode_City_Country",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "ContactTagName",
                table: "ContactTag",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ContactTag_ContactId",
                table: "ContactTag",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactData_ContactId",
                table: "ContactData",
                column: "ContactId");
        }
    }
}
