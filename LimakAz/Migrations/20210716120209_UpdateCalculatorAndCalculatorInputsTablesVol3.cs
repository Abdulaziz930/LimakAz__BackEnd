using Microsoft.EntityFrameworkCore.Migrations;

namespace LimakAz.Migrations
{
    public partial class UpdateCalculatorAndCalculatorInputsTablesVol3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WidthInputs_LanguageId",
                table: "WidthInputs");

            migrationBuilder.DropIndex(
                name: "IX_WeightInputs_LanguageId",
                table: "WeightInputs");

            migrationBuilder.DropIndex(
                name: "IX_LengthInputs_LanguageId",
                table: "LengthInputs");

            migrationBuilder.DropIndex(
                name: "IX_HeightInputs_LanguageId",
                table: "HeightInputs");

            migrationBuilder.CreateIndex(
                name: "IX_WidthInputs_LanguageId",
                table: "WidthInputs",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeightInputs_LanguageId",
                table: "WeightInputs",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LengthInputs_LanguageId",
                table: "LengthInputs",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeightInputs_LanguageId",
                table: "HeightInputs",
                column: "LanguageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WidthInputs_LanguageId",
                table: "WidthInputs");

            migrationBuilder.DropIndex(
                name: "IX_WeightInputs_LanguageId",
                table: "WeightInputs");

            migrationBuilder.DropIndex(
                name: "IX_LengthInputs_LanguageId",
                table: "LengthInputs");

            migrationBuilder.DropIndex(
                name: "IX_HeightInputs_LanguageId",
                table: "HeightInputs");

            migrationBuilder.CreateIndex(
                name: "IX_WidthInputs_LanguageId",
                table: "WidthInputs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightInputs_LanguageId",
                table: "WeightInputs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LengthInputs_LanguageId",
                table: "LengthInputs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HeightInputs_LanguageId",
                table: "HeightInputs",
                column: "LanguageId");
        }
    }
}
