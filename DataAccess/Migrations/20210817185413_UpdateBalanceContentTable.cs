using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateBalanceContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncreaseBalanceDescription",
                table: "BalanceContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncreaseBalanceHeader",
                table: "BalanceContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncreaseBalanceDescription",
                table: "BalanceContents");

            migrationBuilder.DropColumn(
                name: "IncreaseBalanceHeader",
                table: "BalanceContents");
        }
    }
}
