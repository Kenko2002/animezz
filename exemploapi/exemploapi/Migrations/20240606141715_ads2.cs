using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemploapi.Migrations
{
    /// <inheritdoc />
    public partial class ads2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodios_Anime_animeId",
                table: "Episodios");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Franquia_franquiaId",
                table: "Filmes");

            migrationBuilder.DropForeignKey(
                name: "FK_FranquiaGenero_Franquia_franquiasId",
                table: "FranquiaGenero");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Franquia");

            migrationBuilder.CreateTable(
                name: "Franquias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franquias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eh_dublado = table.Column<bool>(type: "bit", nullable: true),
                    eh_legendado = table.Column<bool>(type: "bit", nullable: true),
                    franquiaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_Franquias_franquiaId",
                        column: x => x.franquiaId,
                        principalTable: "Franquias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_franquiaId",
                table: "Animes",
                column: "franquiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodios_Animes_animeId",
                table: "Episodios",
                column: "animeId",
                principalTable: "Animes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Franquias_franquiaId",
                table: "Filmes",
                column: "franquiaId",
                principalTable: "Franquias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FranquiaGenero_Franquias_franquiasId",
                table: "FranquiaGenero",
                column: "franquiasId",
                principalTable: "Franquias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodios_Animes_animeId",
                table: "Episodios");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Franquias_franquiaId",
                table: "Filmes");

            migrationBuilder.DropForeignKey(
                name: "FK_FranquiaGenero_Franquias_franquiasId",
                table: "FranquiaGenero");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Franquias");

            migrationBuilder.CreateTable(
                name: "Franquia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franquia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    franquiaId = table.Column<int>(type: "int", nullable: true),
                    eh_dublado = table.Column<bool>(type: "bit", nullable: true),
                    eh_legendado = table.Column<bool>(type: "bit", nullable: true),
                    link_capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anime_Franquia_franquiaId",
                        column: x => x.franquiaId,
                        principalTable: "Franquia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_franquiaId",
                table: "Anime",
                column: "franquiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodios_Anime_animeId",
                table: "Episodios",
                column: "animeId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Franquia_franquiaId",
                table: "Filmes",
                column: "franquiaId",
                principalTable: "Franquia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FranquiaGenero_Franquia_franquiasId",
                table: "FranquiaGenero",
                column: "franquiasId",
                principalTable: "Franquia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
