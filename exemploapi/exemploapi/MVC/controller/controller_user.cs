using example_db.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using animezz.MVC.model;
using animezz.MVC.application;

namespace animezz.MVC.controller
{

    static class UserController
    {

        public static void AdicionarControllersUsuario(this WebApplication app)
        {
            app.MapPut("/user/Update", FuncionalidadesDeUsuario.UpdateMyUser);
            app.MapPost("/user/CreateVisualizacao", FuncionalidadesDeUsuario.VisualizacaoCreate);
            app.MapPost("/user/CreateComentario", FuncionalidadesDeUsuario.ComentarioCreate);
            app.MapGet("/user/UltimasVisualizacoes", FuncionalidadesDeUsuario.UltimasVisualizacoesMinhas);
        }

    }
}
