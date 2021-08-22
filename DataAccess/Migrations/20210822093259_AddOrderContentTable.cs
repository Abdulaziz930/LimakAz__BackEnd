using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddOrderContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderContents_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderContents_LanguageId",
                table: "OrderContents",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderContents");
        }
    }
}
