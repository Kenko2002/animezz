using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemploapi.Migrations
{
    /// <inheritdoc />
    public partial class bu3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genero_Franquia_FranquiaId",
                table: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Genero_FranquiaId",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "FranquiaId",
                table: "Genero");

            migrationBuilder.CreateTable(
                name: "FranquiaGenero",
                columns: table => new
                {
                    franquiasId = table.Column<int>(type: "int", nullable: false),
                    generosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranquiaGenero", x => new { x.franquiasId, x.generosId });
                    table.ForeignKey(
                        name: "FK_FranquiaGenero_Franquia_franquiasId",
                        column: x => x.franquiasId,
                        principalTable: "Franquia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FranquiaGenero_Genero_generosId",
                        column: x => x.generosId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FranquiaGenero_generosId",
                table: "FranquiaGenero",
                column: "generosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FranquiaGenero");

            migrationBuilder.AddColumn<int>(
                name: "FranquiaId",
                table: "Genero",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genero_FranquiaId",
                table: "Genero",
                column: "FranquiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genero_Franquia_FranquiaId",
                table: "Genero",
                column: "FranquiaId",
                principalTable: "Franquia",
                principalColumn: "Id");
        }
    }
}
