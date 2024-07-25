using example_db.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using animezz.MVC.model;
using animezz.MVC.application;


namespace animezz.MVC.controller
{

    static class Admin
    {

        public static void AdicionarControllersAdmin(this WebApplication app)
        {
            app.MapDelete("/admin/DeleteAllData", FuncionalidadesDeAdmin.DeleteAllData);
            app.MapGet("/admin/GetAllUsers", FuncionalidadesDeAdmin.UserGetAll);
            app.MapPost("/admin/CreateGenero", FuncionalidadesDeAdmin.GeneroCreate); 
            app.MapPost("/admin/CreateFranquia", FuncionalidadesDeAdmin.FranquiaCreate);
            app.MapPost("/admin/AssociarFranquiaGenero", FuncionalidadesDeAdmin.AssociarFranquiaGenero);
            app.MapPost("/admin/CreateFilme", FuncionalidadesDeAdmin.FilmeCreate); 
            app.MapPost("/admin/CreateAnime", FuncionalidadesDeAdmin.AnimeCreate); 
            app.MapPost("/admin/CreateEpisodio", FuncionalidadesDeAdmin.EpisodioCreate);
        }
        

    }
}
