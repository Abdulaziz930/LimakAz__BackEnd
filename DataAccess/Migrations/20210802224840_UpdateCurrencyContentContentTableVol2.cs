using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateCurrencyContentContentTableVol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyContents_Languages_LanguageId",
                table: "CurrencyContents");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyContents_LanguageId",
                table: "CurrencyContents");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CurrencyContents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CurrencyContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyContents_LanguageId",
                table: "CurrencyContents",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyContents_Languages_LanguageId",
                table: "CurrencyContents",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
