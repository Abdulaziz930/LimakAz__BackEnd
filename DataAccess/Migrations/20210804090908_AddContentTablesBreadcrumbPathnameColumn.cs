using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddContentTablesBreadcrumbPathnameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "ShopContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "RuleContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "QuestionContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "Privacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "CountryContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "ContactContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "CalculatorContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreadcrumbPathname",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "ShopContents");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "RuleContents");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "QuestionContents");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "Privacies");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "CountryContents");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "ContactContents");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "CalculatorContents");

            migrationBuilder.DropColumn(
                name: "BreadcrumbPathname",
                table: "Abouts");
        }
    }
}
