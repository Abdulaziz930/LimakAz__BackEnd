using Microsoft.EntityFrameworkCore.Migrations;

namespace LimakAz.Migrations
{
    public partial class UpdateAuthenticationsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Authentications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Authentications");
        }
    }
}
