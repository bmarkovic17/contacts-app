using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class AddressModelCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Address_Street_AddressNumber_postcode_City_Country",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "postcode",
                table: "Address",
                newName: "Postcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postcode",
                table: "Address",
                newName: "postcode");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Address_Street_AddressNumber_postcode_City_Country",
                table: "Address",
                columns: new[] { "Street", "AddressNumber", "postcode", "City", "Country" });
        }
    }
}
