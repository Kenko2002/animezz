﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using example_db.Data;

#nullable disable

namespace exemploapi.Migrations
{
    [DbContext(typeof(MyProjectDbContext))]
    [Migration("20240606141715_ads2")]
    partial class ads2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EpisodioUsuario", b =>
                {
                    b.Property<int>("visualizacoesId")
                        .HasColumnType("int");

                    b.Property<int>("visualizadoresId")
                        .HasColumnType("int");

                    b.HasKey("visualizacoesId", "visualizadoresId");

                    b.HasIndex("visualizadoresId");

                    b.ToTable("EpisodioUsuario");
                });

            modelBuilder.Entity("FranquiaGenero", b =>
                {
                    b.Property<int>("franquiasId")
                        .HasColumnType("int");

                    b.Property<int>("generosId")
                        .HasColumnType("int");

                    b.HasKey("franquiasId", "generosId");

                    b.HasIndex("generosId");

                    b.ToTable("FranquiaGenero");
                });

            modelBuilder.Entity("animezz.MVC.model.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("eh_dublado")
                        .HasColumnType("bit");

                    b.Property<bool?>("eh_legendado")
                        .HasColumnType("bit");

                    b.Property<int?>("franquiaId")
                        .HasColumnType("int");

                    b.Property<string>("link_capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("franquiaId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("animezz.MVC.model.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("episodioId")
                        .HasColumnType("int");

                    b.Property<string>("texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("episodioId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("animezz.MVC.model.Episodio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("animeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("data_insercao")
                        .HasColumnType("datetime2");

                    b.Property<string>("link_capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link_src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("n_episodio")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("animeId");

                    b.ToTable("Episodios");
                });

            modelBuilder.Entity("animezz.MVC.model.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("franquiaId")
                        .HasColumnType("int");

                    b.Property<string>("link_capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link_src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("franquiaId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("animezz.MVC.model.Franquia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Franquias");
                });

            modelBuilder.Entity("animezz.MVC.model.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("animezz.MVC.model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("eh_admin")
                        .HasColumnType("bit");

                    b.Property<string>("link_foto_perfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("EpisodioUsuario", b =>
                {
                    b.HasOne("animezz.MVC.model.Episodio", null)
                        .WithMany()
                        .HasForeignKey("visualizacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("animezz.MVC.model.Usuario", null)
                        .WithMany()
                        .HasForeignKey("visualizadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FranquiaGenero", b =>
                {
                    b.HasOne("animezz.MVC.model.Franquia", null)
                        .WithMany()
                        .HasForeignKey("franquiasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("animezz.MVC.model.Genero", null)
                        .WithMany()
                        .HasForeignKey("generosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("animezz.MVC.model.Anime", b =>
                {
                    b.HasOne("animezz.MVC.model.Franquia", "franquia")
                        .WithMany("animes")
                        .HasForeignKey("franquiaId");

                    b.Navigation("franquia");
                });

            modelBuilder.Entity("animezz.MVC.model.Comentario", b =>
                {
                    b.HasOne("animezz.MVC.model.Episodio", "episodio")
                        .WithMany("comentarios")
                        .HasForeignKey("episodioId");

                    b.HasOne("animezz.MVC.model.Usuario", "usuario")
                        .WithMany("comentarios")
                        .HasForeignKey("usuarioId");

                    b.Navigation("episodio");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("animezz.MVC.model.Episodio", b =>
                {
                    b.HasOne("animezz.MVC.model.Anime", "anime")
                        .WithMany("episodios")
                        .HasForeignKey("animeId");

                    b.Navigation("anime");
                });

            modelBuilder.Entity("animezz.MVC.model.Filme", b =>
                {
                    b.HasOne("animezz.MVC.model.Franquia", "franquia")
                        .WithMany("filmes")
                        .HasForeignKey("franquiaId");

                    b.Navigation("franquia");
                });

            modelBuilder.Entity("animezz.MVC.model.Anime", b =>
                {
                    b.Navigation("episodios");
                });

            modelBuilder.Entity("animezz.MVC.model.Episodio", b =>
                {
                    b.Navigation("comentarios");
                });

            modelBuilder.Entity("animezz.MVC.model.Franquia", b =>
                {
                    b.Navigation("animes");

                    b.Navigation("filmes");
                });

            modelBuilder.Entity("animezz.MVC.model.Usuario", b =>
                {
                    b.Navigation("comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
