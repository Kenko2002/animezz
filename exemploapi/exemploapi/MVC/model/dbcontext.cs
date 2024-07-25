using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using animezz.MVC.model;

namespace example_db.Data
{
    
    public class MyProjectDbContext: DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Episodio> Episodios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Franquia> Franquias { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        private string localConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=example_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        //comandos de terminal uteis:
        //Add-Migration 
        //Update-Database

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) : base(options)
        {

        }
        public MyProjectDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (optionsBuilder.IsConfigured)
                //return;
            optionsBuilder.UseSqlServer(localConnectionString);
            Console.WriteLine("SQL Server inicializado com sucesso!");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



        }
        

    }
}





