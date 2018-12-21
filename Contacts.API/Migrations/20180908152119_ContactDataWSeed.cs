using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.API.Migrations
{
    public partial class ContactDataWSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Contacts",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "ContactData",
                columns: table => new
                {
                    ContactDataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: false),
                    ContactDataType = table.Column<string>(nullable: false),
                    ContactDataValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactData", x => x.ContactDataID);
                    table.ForeignKey(
                        name: "FK_ContactData_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactData",
                columns: new[] { "ContactDataID", "ContactDataType", "ContactDataValue", "ContactId" },
                values: new object[,]
                {
                    { 1, "PHONE", "090/0000-000", 1 },
                    { 2, "PHONE", "090/0000-001", 1 },
                    { 3, "MAIL", "keanu.reeves@mail.com", 1 },
                    { 4, "PHONE", "090/0000-100", 2 },
                    { 5, "MAIL", "elon.musk@mail.com", 2 },
                    { 6, "MAIL", "elon.musk@anothermail.com", 2 },
                    { 7, "PHONE", "090/0000-200", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactData_ContactId",
                table: "ContactData",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactData");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
