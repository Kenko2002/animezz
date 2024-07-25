using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemploapi.Migrations
{
    /// <inheritdoc />
    public partial class match4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_requirinte_e_alvo_id",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "user_requirido_id",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_requirinte_id",
                table: "Matches",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_requirido_id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "user_requirinte_id",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "user_requirinte_e_alvo_id",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
