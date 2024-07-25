using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemploapi.Migrations
{
    /// <inheritdoc />
    public partial class match3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_requirinte_e_alvo_id",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_UserId",
                table: "Matches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "Matches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_UserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "user_requirinte_e_alvo_id",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "MatchUser",
                columns: table => new
                {
                    matchesId = table.Column<int>(type: "int", nullable: false),
                    user_requirinte_e_alvoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchUser", x => new { x.matchesId, x.user_requirinte_e_alvoId });
                    table.ForeignKey(
                        name: "FK_MatchUser_Matches_matchesId",
                        column: x => x.matchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchUser_Users_user_requirinte_e_alvoId",
                        column: x => x.user_requirinte_e_alvoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchUser_user_requirinte_e_alvoId",
                table: "MatchUser",
                column: "user_requirinte_e_alvoId");
        }
    }
}
