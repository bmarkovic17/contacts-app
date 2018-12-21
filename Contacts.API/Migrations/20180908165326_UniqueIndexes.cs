using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class UniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                newName: "AddressIdIDX");

            migrationBuilder.CreateIndex(
                name: "ContactIdIDX",
                table: "ContactTag",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "ContactTagIdIDX",
                table: "ContactTag",
                column: "ContactTagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ContactIdIDX",
                table: "Contacts",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ContactDataIdIDX",
                table: "ContactData",
                column: "ContactDataID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ContactIdIDX",
                table: "ContactData",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "AddressIdIDX",
                table: "Address",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ContactIdIDX",
                table: "ContactTag");

            migrationBuilder.DropIndex(
                name: "ContactTagIdIDX",
                table: "ContactTag");

            migrationBuilder.DropIndex(
                name: "ContactIdIDX",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "ContactDataIdIDX",
                table: "ContactData");

            migrationBuilder.DropIndex(
                name: "ContactIdIDX",
                table: "ContactData");

            migrationBuilder.DropIndex(
                name: "AddressIdIDX",
                table: "Address");

            migrationBuilder.RenameIndex(
                name: "AddressIdIDX",
                table: "Contacts",
                newName: "IX_Contacts_AddressId");
        }
    }
}
