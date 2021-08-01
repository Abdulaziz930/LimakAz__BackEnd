using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_CityId",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CityId",
                table: "Contacts",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_CityId",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CityId",
                table: "Contacts",
                column: "CityId",
                unique: true);
        }
    }
}
