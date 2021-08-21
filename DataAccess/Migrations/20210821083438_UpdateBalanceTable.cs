using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateBalanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TableActionHeader",
                table: "BalanceContents",
                newName: "TableDetailHeader");

            migrationBuilder.AddColumn<string>(
                name: "TableButtonName",
                table: "BalanceContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableButtonName",
                table: "BalanceContents");

            migrationBuilder.RenameColumn(
                name: "TableDetailHeader",
                table: "BalanceContents",
                newName: "TableActionHeader");
        }
    }
}
