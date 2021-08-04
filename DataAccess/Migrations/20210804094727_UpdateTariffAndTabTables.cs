using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateTariffAndTabTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Languages_LanguageId",
                table: "Tabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Languages_LanguageId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_LanguageId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_LanguageId",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "LangaugeId",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tabs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Tariffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LangaugeId",
                table: "Tabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Tabs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_LanguageId",
                table: "Tariffs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_LanguageId",
                table: "Tabs",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Languages_LanguageId",
                table: "Tabs",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Languages_LanguageId",
                table: "Tariffs",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
