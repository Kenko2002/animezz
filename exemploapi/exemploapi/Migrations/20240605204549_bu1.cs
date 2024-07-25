using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemploapi.Migrations
{
    /// <inheritdoc />
    public partial class bu1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Anime_animeId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Comentario_ComentarioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Usuarios_UsuarioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodio_Episodio_episodioId",
                table: "Episodio");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodio_Usuarios_usuarioId",
                table: "Episodio");

            migrationBuilder.DropTable(
                name: "Usuario_Episodio");

            migrationBuilder.DropIndex(
                name: "IX_Episodio_episodioId",
                table: "Episodio");

            migrationBuilder.DropIndex(
                name: "IX_Episodio_usuarioId",
                table: "Episodio");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_animeId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_ComentarioId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "ComentarioId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "animeId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "data_insercao",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "link_capa",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "link_src",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "n_episodio",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Episodio",
                newName: "views");

            migrationBuilder.RenameColumn(
                name: "episodioId",
                table: "Episodio",
                newName: "n_episodio");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Comentario",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "views",
                table: "Comentario",
                newName: "episodioId");

            migrationBuilder.RenameColumn(
                name: "sinopse",
                table: "Comentario",
                newName: "texto");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_UsuarioId",
                table: "Comentario",
                newName: "IX_Comentario_usuarioId");

            migrationBuilder.AddColumn<int>(
                name: "animeId",
                table: "Episodio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_insercao",
                table: "Episodio",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_capa",
                table: "Episodio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_src",
                table: "Episodio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Episodio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sinopse",
                table: "Episodio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "franquiaId",
                table: "Anime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EpisodioUsuario",
                columns: table => new
                {
                    visualizacoesId = table.Column<int>(type: "int", nullable: false),
                    visualizadoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodioUsuario", x => new { x.visualizacoesId, x.visualizadoresId });
                    table.ForeignKey(
                        name: "FK_EpisodioUsuario_Episodio_visualizacoesId",
                        column: x => x.visualizacoesId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodioUsuario_Usuarios_visualizadoresId",
                        column: x => x.visualizadoresId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    franquiaId = table.Column<int>(type: "int", nullable: true),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_src = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Franquia_franquiaId",
                        column: x => x.franquiaId,
                        principalTable: "Franquia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranquiaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genero_Franquia_FranquiaId",
                        column: x => x.FranquiaId,
                        principalTable: "Franquia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodio_animeId",
                table: "Episodio",
                column: "animeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_episodioId",
                table: "Comentario",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_franquiaId",
                table: "Anime",
                column: "franquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodioUsuario_visualizadoresId",
                table: "EpisodioUsuario",
                column: "visualizadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_franquiaId",
                table: "Filme",
                column: "franquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_FranquiaId",
                table: "Genero",
                column: "FranquiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Franquia_franquiaId",
                table: "Anime",
                column: "franquiaId",
                principalTable: "Franquia",
                principalColumn: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Franquia_franquiaId",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Episodio_episodioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Usuarios_usuarioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodio_Anime_animeId",
                table: "Episodio");

            migrationBuilder.DropTable(
                name: "EpisodioUsuario");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Franquia");

            migrationBuilder.DropIndex(
                name: "IX_Episodio_animeId",
                table: "Episodio");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_episodioId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Anime_franquiaId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "animeId",
                table: "Episodio");

            migrationBuilder.DropColumn(
                name: "data_insercao",
                table: "Episodio");

            migrationBuilder.DropColumn(
                name: "link_capa",
                table: "Episodio");

            migrationBuilder.DropColumn(
                name: "link_src",
                table: "Episodio");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Episodio");

            migrationBuilder.DropColumn(
                name: "sinopse",
                table: "Episodio");

            migrationBuilder.DropColumn(
                name: "franquiaId",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "views",
                table: "Episodio",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "n_episodio",
                table: "Episodio",
                newName: "episodioId");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Comentario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Comentario",
                newName: "sinopse");

            migrationBuilder.RenameColumn(
                name: "episodioId",
                table: "Comentario",
                newName: "views");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_usuarioId",
                table: "Comentario",
                newName: "IX_Comentario_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "ComentarioId",
                table: "Comentario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "animeId",
                table: "Comentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_insercao",
                table: "Comentario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_capa",
                table: "Comentario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_src",
                table: "Comentario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "n_episodio",
                table: "Comentario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Comentario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario_Episodio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    episodioId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    ComentarioId = table.Column<int>(type: "int", nullable: true),
                    texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Episodio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Episodio_Comentario_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "Comentario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Episodio_Episodio_episodioId",
                        column: x => x.episodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Episodio_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodio_episodioId",
                table: "Episodio",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodio_usuarioId",
                table: "Episodio",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_animeId",
                table: "Comentario",
                column: "animeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ComentarioId",
                table: "Comentario",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Episodio_ComentarioId",
                table: "Usuario_Episodio",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Episodio_episodioId",
                table: "Usuario_Episodio",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Episodio_usuarioId",
                table: "Usuario_Episodio",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Anime_animeId",
                table: "Comentario",
                column: "animeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Comentario_ComentarioId",
                table: "Comentario",
                column: "ComentarioId",
                principalTable: "Comentario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Usuarios_UsuarioId",
                table: "Comentario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodio_Episodio_episodioId",
                table: "Episodio",
                column: "episodioId",
                principalTable: "Episodio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodio_Usuarios_usuarioId",
                table: "Episodio",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
