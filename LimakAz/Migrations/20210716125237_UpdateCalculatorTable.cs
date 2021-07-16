using Microsoft.EntityFrameworkCore.Migrations;

namespace LimakAz.Migrations
{
    public partial class UpdateCalculatorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calculators_LanguageId",
                table: "Calculators");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_LanguageId",
                table: "Calculators",
                column: "LanguageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calculators_LanguageId",
                table: "Calculators");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_LanguageId",
                table: "Calculators",
                column: "LanguageId");
        }
    }
}
