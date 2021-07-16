using Microsoft.EntityFrameworkCore.Migrations;

namespace LimakAz.Migrations
{
    public partial class UpdateCalculatorAndCalculatorInputsTablesVol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoxCountInputs_LanguageId",
                table: "BoxCountInputs");

            migrationBuilder.CreateIndex(
                name: "IX_BoxCountInputs_LanguageId",
                table: "BoxCountInputs",
                column: "LanguageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoxCountInputs_LanguageId",
                table: "BoxCountInputs");

            migrationBuilder.CreateIndex(
                name: "IX_BoxCountInputs_LanguageId",
                table: "BoxCountInputs",
                column: "LanguageId");
        }
    }
}
