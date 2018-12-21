using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class AddressEntityAndModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDataValue",
                table: "ContactData",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactDataType",
                table: "ContactData",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ContactDataStatus",
                table: "ContactData",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(maxLength: 200, nullable: false),
                    AddressNumber = table.Column<string>(maxLength: 10, nullable: false),
                    postcode = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ContactTag",
                columns: table => new
                {
                    ContactTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: false),
                    ContactTagName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTag", x => x.ContactTagId);
                    table.ForeignKey(
                        name: "FK_ContactTag_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AddressNumber", "City", "Country", "Street", "postcode" },
                values: new object[,]
                {
                    { 1, "8106", "Schenectady", "New York, US", "Linda Ave.", "12302" },
                    { 2, "7201", "Easton", "Pennsylvania, US", "N. Roehampton Ave.", "18042" },
                    { 3, "57", "Bern", "Switzerland", "Erlenweg", "3027" }
                });

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 1,
                column: "ContactDataStatus",
                value: "M");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 2,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 3,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 4,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 5,
                column: "ContactDataStatus",
                value: "M");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 6,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "ContactData",
                keyColumn: "ContactDataID",
                keyValue: 7,
                column: "ContactDataStatus",
                value: "Y");

            migrationBuilder.InsertData(
                table: "ContactTag",
                columns: new[] { "ContactTagId", "ContactId", "ContactTagName" },
                values: new object[,]
                {
                    { 1, 1, "friend" },
                    { 2, 2, "roleModel" },
                    { 3, 2, "colleague" },
                    { 4, 3, "family" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "AddressId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "AddressId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "AddressId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTag_ContactId",
                table: "ContactTag",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Address_AddressId",
                table: "Contacts",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Address_AddressId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ContactTag");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactDataStatus",
                table: "ContactData");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDataValue",
                table: "ContactData",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDataType",
                table: "ContactData",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Address",
                value: "8106 Linda Ave., Schenectady, NY 12302");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Address",
                value: "7201 N. Roehampton Ave., Easton, PA 18042");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Address",
                value: "Erlenweg 57, 3027 Bern, Switzerland");
        }
    }
}
