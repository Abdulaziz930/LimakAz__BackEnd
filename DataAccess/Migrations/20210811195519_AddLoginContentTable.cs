using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddLoginContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMeLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForgotPasswordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginContents_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginContents_LanguageId",
                table: "LoginContents",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginContents");
        }
    }
}
