using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateTariffAndCountryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryProductTypes");

            migrationBuilder.AddColumn<int>(
                name: "ConutryId",
                table: "Tariffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Tariffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Countries_CountryId",
                table: "Tariffs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Countries_CountryId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "ConutryId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Tariffs");

            migrationBuilder.CreateTable(
                name: "CountryProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryProductTypes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryProductTypes_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryProductTypes_CountryId",
                table: "CountryProductTypes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryProductTypes_ProductTypeId",
                table: "CountryProductTypes",
                column: "ProductTypeId");
        }
    }
}
