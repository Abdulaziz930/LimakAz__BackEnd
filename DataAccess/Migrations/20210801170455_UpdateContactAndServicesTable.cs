using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateContactAndServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Languages_LanguageId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Languages_LanguageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_LanguageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_LanguageId",
                table: "Services",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Languages_LanguageId",
                table: "Contacts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Languages_LanguageId",
                table: "Services",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
