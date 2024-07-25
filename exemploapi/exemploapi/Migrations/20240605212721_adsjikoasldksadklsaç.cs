using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemploapi.Migrations
{
    /// <inheritdoc />
    public partial class adsjikoasldksadklsaç : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Episodio_episodioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Usuarios_usuarioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodio_Anime_animeId",
                table: "Episodio");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodioUsuario_Episodio_visualizacoesId",
                table: "EpisodioUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Franquia_franquiaId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_FranquiaGenero_Genero_generosId",
                table: "FranquiaGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodio",
                table: "Episodio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.RenameTable(
                name: "Filme",
                newName: "Filmes");

            migrationBuilder.RenameTable(
                name: "Episodio",
                newName: "Episodios");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "Comentarios");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_franquiaId",
                table: "Filmes",
                newName: "IX_Filmes_franquiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodio_animeId",
                table: "Episodios",
                newName: "IX_Episodios_animeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_usuarioId",
                table: "Comentarios",
                newName: "IX_Comentarios_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_episodioId",
                table: "Comentarios",
                newName: "IX_Comentarios_episodioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodios",
                table: "Episodios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Episodios_episodioId",
                table: "Comentarios",
                column: "episodioId",
                principalTable: "Episodios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_usuarioId",
                table: "Comentarios",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodios_Anime_animeId",
                table: "Episodios",
                column: "animeId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodioUsuario_Episodios_visualizacoesId",
                table: "EpisodioUsuario",
                column: "visualizacoesId",
                principalTable: "Episodios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Franquia_franquiaId",
                table: "Filmes",
                column: "franquiaId",
                principalTable: "Franquia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FranquiaGenero_Generos_generosId",
                table: "FranquiaGenero",
                column: "generosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Episodios_episodioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_usuarioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodios_Anime_animeId",
                table: "Episodios");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodioUsuario_Episodios_visualizacoesId",
                table: "EpisodioUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Franquia_franquiaId",
                table: "Filmes");

            migrationBuilder.DropForeignKey(
                name: "FK_FranquiaGenero_Generos_generosId",
                table: "FranquiaGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodios",
                table: "Episodios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "Filme");

            migrationBuilder.RenameTable(
                name: "Episodios",
                newName: "Episodio");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Comentario");

            migrationBuilder.RenameIndex(
                name: "IX_Filmes_franquiaId",
                table: "Filme",
                newName: "IX_Filme_franquiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodios_animeId",
                table: "Episodio",
                newName: "IX_Episodio_animeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_usuarioId",
                table: "Comentario",
                newName: "IX_Comentario_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_episodioId",
                table: "Comentario",
                newName: "IX_Comentario_episodioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodio",
                table: "Episodio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Episodio_episodioId",
                table: "Comentario",
                column: "episodioId",
                principalTable: "Episodio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Usuarios_usuarioId",
                table: "Comentario",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodio_Anime_animeId",
                table: "Episodio",
                column: "animeId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodioUsuario_Episodio_visualizacoesId",
                table: "EpisodioUsuario",
                column: "visualizacoesId",
                principalTable: "Episodio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Franquia_franquiaId",
                table: "Filme",
                column: "franquiaId",
                principalTable: "Franquia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FranquiaGenero_Genero_generosId",
                table: "FranquiaGenero",
                column: "generosId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
