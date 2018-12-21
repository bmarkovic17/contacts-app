using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class ContactDataIdCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactDataID",
                table: "ContactData",
                newName: "ContactDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactDataId",
                table: "ContactData",
                newName: "ContactDataID");
        }
    }
}
