using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateForgotPasswordContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuccessMessageDescription",
                table: "ForgotPasswordContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessageFirstSide",
                table: "ForgotPasswordContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessageSecondSide",
                table: "ForgotPasswordContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuccessMessageDescription",
                table: "ForgotPasswordContents");

            migrationBuilder.DropColumn(
                name: "SuccessMessageFirstSide",
                table: "ForgotPasswordContents");

            migrationBuilder.DropColumn(
                name: "SuccessMessageSecondSide",
                table: "ForgotPasswordContents");
        }
    }
}
