using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddCountryProductTypeTableVol4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tabs_CountryId",
                table: "Tabs");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_CountryId",
                table: "Tabs",
                column: "CountryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tabs_CountryId",
                table: "Tabs");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_CountryId",
                table: "Tabs",
                column: "CountryId");
        }
    }
}
