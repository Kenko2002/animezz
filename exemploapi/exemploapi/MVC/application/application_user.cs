using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using example_db.Data;
using animezz.MVC.DTO;
using animezz.MVC.model;
using Azure;
using utility_functions;

namespace animezz.MVC.application
{

    public class FuncionalidadesDeUsuario
    {

        public static IResult ComentarioCreate(HttpContext httpContext, [FromBody] ComentarioDTO post_content)
        {

            Comentario post = new Comentario();
            post.transferirInformacao_DTO(post_content);


            var username = httpContext.Session.GetString("Username");
            var nome_episodio = post_content.episodio_nome;

            using (var dbContext = new MyProjectDbContext())
            {
                var user = dbContext.Usuarios
                             .FirstOrDefault(u => u.login == username);
                var episodio= dbContext.Episodios
                            .FirstOrDefault(u=>u.nome== nome_episodio);


                if (episodio == null)
                {
                    return Results.Ok("Episódio não encontrado");
                }
                if( username == null)
                {
                    return Results.Ok("Usuário não encontrado");
                }

                post.episodio = episodio;
                post.usuario = user;
                
                user.comentarios.Add(post);
                dbContext.SaveChanges();
                return Results.Ok(post);
            }
        }





        public static IResult VisualizacaoCreate(HttpContext httpContext, [FromBody] EpisodioDTO post_content)
        {

            Episodio post = new Episodio();
            post.transferirInformacao_DTO(post_content);


            var username = httpContext.Session.GetString("Username");

            using (var dbContext = new MyProjectDbContext())
            {
                //conferindo se a visualizacao já existe na base de dados ASSOCIADA AO MEU USUÁRIO.
                var users = dbContext.Usuarios
                    .Where(u => u.login==username && u.visualizacoes.Any(f=> f.nome==post_content.nome)  )
                    .ToList();
                if (users.Count != 0)
                {
                    //buscando as views desse episodio DE TODOS OS USUARIOS. 
                    var visualizacoes_desse_ep = dbContext.Usuarios.Where(u => u.visualizacoes.Any(n =>n.nome==post_content.nome)).ToList();
                    return Results.Ok(visualizacoes_desse_ep);
                }

                var user=dbContext.Usuarios
                             .FirstOrDefault(u => u.login == username);
                var episodio = dbContext.Episodios
                             .FirstOrDefault(u => u.nome == post_content.nome);


                episodio.visualizadores.Add(user);
                episodio.views += 1;
                user.visualizacoes.Add(post);
                
                dbContext.SaveChanges();
                return Results.Ok("Visualização Criada!");
            }
        }

        public static IResult UpdateMyUser(HttpContext httpContext, [FromBody] UsuarioDTO post_content)
        {
            Usuario post = new Usuario();
            post.transferirInformacao_DTO(post_content);

            using (var dbContext = new MyProjectDbContext())
            {
                if (httpContext.Session.GetInt32("User_Id") != null)
                {
                    post.Id = httpContext.Session.GetInt32("User_Id").Value;
                }
                else
                {
                    return Results.Ok("Você não está logado");
                }

                //conferindo se o id já existe na base de dados
                var user = dbContext.Usuarios.FirstOrDefault(u => u.Id == post.Id);

                //impedindo o usuario de atualizar suas permissões de Admin e seu Login
                post.eh_admin = user.eh_admin;
                post.login = user.login;


                dbContext.Entry(user).CurrentValues.SetValues(post);
                dbContext.SaveChanges();
                return Results.Ok(post);
            }
        }


        public static IResult UltimasVisualizacoesMinhas(HttpContext httpContext)
        {
            // Obtenha o ID do usuário da sessão
            var userId = httpContext.Session.GetInt32("User_Id");
            if (userId == null)
            {
                return Results.Ok("Usuário não está logado.");
            }

            using (var dbContext = new MyProjectDbContext())
            {
                // Busque o usuário e inclua as visualizações
                var user = dbContext.Usuarios
                    .Include(u => u.visualizacoes)
                        .ThenInclude(e => e.anime) // Inclui o objeto Anime relacionado aos episódios
                    .FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return Results.Ok("Usuário não encontrado.");
                }



                // Projete os episódios visualizados com os dados necessários

                var recentViews = user.visualizacoes
                .Where(e => e.anime != null)
                .GroupBy(e => e.anime != null ? e.anime.nome : null) // Agrupa pelo nome do anime
                .Select(group => group.OrderByDescending(e => e.data_insercao).FirstOrDefault()) // Seleciona o episódio mais recente de cada grupo
                .OrderByDescending(e => e.data_insercao) // Ordena os episódios pela data de inserção em ordem decrescente
                .Select(e => new
                {
                    e.Id,
                    e.nome,
                    e.sinopse,
                    e.link_src,
                    e.n_episodio,
                    e.views,
                    e.data_insercao,
                    e.link_capa,
                    AnimeNome = e.anime != null ? e.anime.nome : null // Nome do anime ou null se não existir
                })
                .ToList();

                return Results.Ok(recentViews);
            }


        }
        





    }

}