using example_db.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using animezz.MVC.model;
using animezz.MVC.application;
using Microsoft.EntityFrameworkCore;
using utility_functions;


namespace animezz.MVC.controller
{

    static class UserSemLoginController
    {

        public static void AdicionarControllersUsuarioSemLogin(this WebApplication app)
        {
            app.MapPost("/naologado/Login", FuncionalidadesDeUsuarioSemLogin.Logar);
            app.MapPost("/naologado/Registrar", FuncionalidadesDeUsuarioSemLogin.UserCreate);
            app.MapGet("/naologado/GetAllFranquias" ,FuncionalidadesDeUsuarioSemLogin.FranquiasGetAll);
            app.MapGet("/naologado/GetAllGeneros", FuncionalidadesDeUsuarioSemLogin.GenerosGetAll);
            app.MapGet("/naologado/GetByNameFranquia", FuncionalidadesDeUsuarioSemLogin.FranquiaGetByName);
            app.MapGet("/naologado/GetByGeneroFranquia", FuncionalidadesDeUsuarioSemLogin.FranquiaGetByGenero);
            app.MapGet("/naologado/GetByNameEpisodio", FuncionalidadesDeUsuarioSemLogin.GetEpisodioByName);
            app.MapGet("/naologado/GetByNameFilme", FuncionalidadesDeUsuarioSemLogin.GetFilmeByName);
            app.MapGet("/naologado/GetAllFranquiasMaisVistas", FuncionalidadesDeUsuarioSemLogin.FranquiasGetAllMaisVistos);
            //app.MapGet("/naologado/GetAllFranquiasMaisVistasDoMes", FuncionalidadesDeUsuarioSemLogin.FranquiasGetAllMaisVistosDoMes);
            app.MapGet("/naologado/GetAnimesUltimosLancamentos", FuncionalidadesDeUsuarioSemLogin.AnimesGetMaisRecentes);
            app.MapGet("/naologado/GetEpisodiosUltimosLancamentos", FuncionalidadesDeUsuarioSemLogin.EpisodiosGetMaisRecentes);
            app.MapGet("/naologado/GetEpisodiosByAnimeName", FuncionalidadesDeUsuarioSemLogin.GetEpisodiosByAnimeName);
            app.MapGet("/naologado/GetAnimeByFranquiaName", FuncionalidadesDeUsuarioSemLogin.GetAnimeByFranquiaName);
            app.MapGet("/naologado/GetNextAnimeEpisode", FuncionalidadesDeUsuarioSemLogin.GetNextAnimeEpisode);
            app.MapGet("/naologado/GetPreviousAnimeEpisode", FuncionalidadesDeUsuarioSemLogin.GetPreviousAnimeEpisode);
            app.MapGet("/naologado/GetEpisodioViews", FuncionalidadesDeUsuarioSemLogin.GetEpisodioViews);
            app.MapGet("/naologado/GetAllViewsPorAnime", FuncionalidadesDeUsuarioSemLogin.SomarViewsPorAnime); 
            app.MapGet("/naologado/SomarViewsPorFranquia", FuncionalidadesDeUsuarioSemLogin.SomarViewsPorFranquia);





        }
        





    }

}
