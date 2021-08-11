using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateLoginContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordLabel",
                table: "LoginContents");

            migrationBuilder.DropColumn(
                name: "UserNameLabel",
                table: "LoginContents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordLabel",
                table: "LoginContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNameLabel",
                table: "LoginContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
