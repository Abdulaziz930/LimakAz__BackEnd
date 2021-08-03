using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateCurrencyContentContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CurrencyContents");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "CurrencyContents",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RateTitle",
                table: "CurrencyContents",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateTitle",
                table: "CurrencyContents");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "CurrencyContents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CurrencyContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
