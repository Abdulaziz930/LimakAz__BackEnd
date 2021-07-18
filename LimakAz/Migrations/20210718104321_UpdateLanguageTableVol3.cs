using Microsoft.EntityFrameworkCore.Migrations;

namespace LimakAz.Migrations
{
    public partial class UpdateLanguageTableVol3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders",
                column: "LanguageId",
                unique: true);
        }
    }
}
