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

    public class FuncionalidadesDeUsuarioSemLogin
    {

        
        public static IResult UserCreate(HttpContext httpContext,[FromBody] UsuarioDTO post_content)
        {

            Usuario post = new Usuario();
            post.transferirInformacao_DTO(post_content);
            
            using (var dbContext = new MyProjectDbContext())
            {
                //conferindo se o usuário já existe na base de dados
                var users = dbContext.Usuarios.Where(u => u.login == post.login).ToList();
                if (users.Count != 0)
                {
                    return Results.Ok("Esse login já está cadastrado!");
                }

                if (post.login == "ADMIN")
                {
                    post.eh_admin = true;
                }

                dbContext.Usuarios.Add(post);
                dbContext.SaveChanges();

                //logando o usuario na conta que ele acabara de criar.
                httpContext.Session.SetInt32("User_Id", post.Id);
                httpContext.Session.SetString("Username", post.login);
                httpContext.Session.SetString("Password", post.senha);
                httpContext.Session.SetString("Eh_Admin", post.eh_admin.ToString());

                return Results.Ok(post);
            }
        }


        


        public static IResult Logar(HttpContext httpContext, string login, string senha)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var users = dbContext.Usuarios.Where(u => u.login == login && u.senha == senha).ToList();

                if (users.Count == 0 )
                {
                    return Results.Ok("Login Inválido!");
                }
                else
                {
                    var user = users.First();
                    httpContext.Session.SetInt32("User_Id", user.Id);
                    httpContext.Session.SetString("Username", user.login);
                    httpContext.Session.SetString("Password", user.senha);
                    httpContext.Session.SetString("Eh_Admin", user.eh_admin.ToString());

                    return Results.Ok(new
                    {
                        UserName = httpContext.Session.GetString("Username"),
                        Password = httpContext.Session.GetString("Password"),
                        User_Id = httpContext.Session.GetInt32("User_Id"),
                        Eh_Admin = httpContext.Session.GetString("Eh_Admin")
                    });
                }
            }

        }

        public static IResult FranquiasGetAll(HttpContext httpContext)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var franquias = dbContext.Franquias
                                        .Include(u => u.generos)
                                        .Include(u => u.filmes)
                                        .Include(u => u.animes).ThenInclude(a => a.episodios)
                                        .ToList();
                if (franquias.Count == 0)
                {
                    return Results.NotFound("Nenhuma franquia encontrado.");
                }

                return Results.Ok(franquias);
            }

        }

        public static IResult FranquiaGetByName(HttpContext httpContext,string franquia_nome)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var franquia = dbContext.Franquias
                                        .Include(u => u.generos)
                                        .Include(u => u.filmes)
                                        .Include(u => u.animes).ThenInclude(a => a.episodios)
                                                                .ThenInclude(e => e.visualizadores)

                                        .FirstOrDefault(f => f.nome == franquia_nome);
                if (franquia== null)
                {
                    
                    return Results.NotFound("Nenhuma franquia encontrado.");
                }
                else
                {
                    foreach (var anime in franquia.animes)
                    {
                        anime.episodios = anime.episodios
                            .GroupBy(e => e.nome)  // Agrupa pelos nomes dos episódios
                            .Select(g => g.OrderBy(e => e.n_episodio).First())  // Ordena e seleciona o primeiro de cada grupo
                            .ToList();
                    }
                }

                return Results.Ok(franquia);
            }

        }

        
        public static IResult FranquiaGetByGenero(HttpContext httpContext, string genero_nome)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var franquias = dbContext.Franquias
                                         .Include(f => f.generos)
                                         .Include(f => f.filmes)
                                         .Include(f => f.animes)
                                             .ThenInclude(a => a.episodios)
                                         .Where(f => f.generos.Any(g => g.nome == genero_nome))
                                         .ToList();

                if (franquias.Count==0)
                {
                    return Results.NotFound("Nenhuma franquia encontrado.");
                }

                return Results.Ok(franquias);
            }

        }

        public static IResult GetEpisodioByName(HttpContext httpContext, string episodio_nome)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var episodio = dbContext.Episodios
                                         .Include(f=>f.anime)
                                         .Include(f => f.comentarios).ThenInclude(c => c.usuario)
                                         .Include(f => f.visualizadores)
                                         .FirstOrDefault(f => f.nome == episodio_nome);

                if (episodio == null)
                {
                    return Results.NotFound("Nenhum episódio encontrado.");
                }

                return Results.Ok(episodio);
            }

        }

        public static IResult GetFilmeByName(HttpContext httpContext, string filme_nome)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var filme = dbContext.Filmes
                                         .Include(f => f.franquia)
                                         .FirstOrDefault(f => f.nome == filme_nome);

                if (filme == null)
                {
                    return Results.NotFound("Nenhum filme encontrado.");
                }

                return Results.Ok(filme);
            }

        }


        public static IResult GenerosGetAll(HttpContext httpContext)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var generos = dbContext.Generos
                                        .Include(u => u.franquias)
                                        .ToList();
                if (generos.Count == 0)
                {
                    return Results.NotFound("Nenhum Genero encontrado.");
                }

                return Results.Ok(generos);
            }

        }

        public static IResult FranquiasGetAllMaisVistos(HttpContext httpContext)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var franquias = dbContext.Franquias
                .Include(f => f.animes)
                .ThenInclude(a => a.episodios)
                .Select(f => new
                {
                    Franquia = f,
                    TotalViews = f.animes
                                  .SelectMany(a => a.episodios)
                                  .Sum(e => e.views),
                    Animes = f.animes
                              .Select(a => new
                              {
                                  anime = a,
                                  episodios = a.episodios.OrderBy(e => e.views).ToList(),
                                  TotalViews = a.episodios.Sum(e => e.views)
                              })
                              .OrderByDescending(a => a.TotalViews)
                              .ToList()
                })
                .OrderByDescending(f => f.TotalViews)
                .ToList();

                var franquiaList = franquias.Select(f => f.Franquia).ToList();



                //franquiaList.Reverse();

                return Results.Ok(franquiaList);
            }

        }

        public static IResult AnimesGetMaisRecentes(HttpContext httpContext)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var franquias = dbContext.Franquias
                    .Include(f => f.animes)
                    .ThenInclude(a => a.episodios)
                    .Select(f => new
                    {
                        Franquia = f,
                        Animes = f.animes
                                  .Select(a => new
                                  {
                                      anime = a,
                                      LastEpisodeDate = a.episodios.Max(e => e.data_insercao)
                                  })
                                  .ToList()
                    })
                    .ToList();

                var allAnimes = franquias.SelectMany(f => f.Animes)
                                         .OrderByDescending(a => a.LastEpisodeDate)
                                         .Select(a => a.anime)
                                         .ToList();

                return Results.Ok(allAnimes);
            }


        }

        public static IResult EpisodiosGetMaisRecentes(HttpContext httpContext)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var recentEpisodes = dbContext.Episodios
                        .Join(dbContext.Animes,
                              episodio => episodio.anime.Id, // Supondo que há uma propriedade AnimeId em Episodios
                              anime => anime.Id,
                              (episodio, anime) => new
                              {
                                  episodio.nome,
                                  episodio.sinopse,
                                  episodio.link_src,
                                  episodio.n_episodio,
                                  episodio.views,
                                  episodio.data_insercao,
                                  episodio.link_capa,
                                  AnimeNome = anime.nome 
                              })
                        .OrderByDescending(e => e.data_insercao)
                        .ToList();

                return Results.Ok(recentEpisodes);

            }


        }




        public static IResult GetEpisodiosByAnimeName(HttpContext httpContext, string anime_nome)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var episodios = dbContext.Episodios
                                 .Include(e => e.anime)
                                 .Where(e=>e.anime.nome.ToLower()==anime_nome.ToLower() )
                                 .AsEnumerable() // Move a execução da consulta para a memória
                                 .GroupBy(e => e.nome)
                                 .Select(g => g.OrderByDescending(e => e.data_insercao).First())
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
                                     AnimeNome = e.anime?.nome
                                 })
                                 .ToList();

                if (episodios.Count == 0)
                {
                    return Results.NotFound("Nenhum episódio encontrado.");
                }

                return Results.Ok(episodios);
            }
        }

        public static IResult GetAnimeByFranquiaName(HttpContext httpContext, string franquia_nome)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                var episodios = dbContext.Animes
                                    .Include(e=>e.episodios)
                                    .Include(e => e.franquia)
                                    .Where(e => e.franquia.nome.ToLower() == franquia_nome.ToLower())
                                    .AsEnumerable() // Move a execução da consulta para a memória
                                    .GroupBy(e => e.nome)
                                    .Select(g => g.FirstOrDefault()) // Seleciona o primeiro elemento de cada grupo
                                    .Select(e => new
                                    {
                                        e.nome,
                                        e.link_capa,
                                        e.sinopse,
                                        e.eh_dublado,
                                        e.eh_legendado,
                                        e.episodios
                                    })
                                    .ToList();

                if (episodios.Count == 0)
                {
                    return Results.NotFound("Nenhum episódio encontrado.");
                }

                return Results.Ok(episodios);
            }
        }




        public static IResult GetNextAnimeEpisode([FromQuery] string anime_nome, [FromQuery] int n_episodio)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                // Encontrar o anime com base no nome fornecido (ignorando maiúsculas/minúsculas)
                var anime = dbContext.Animes
                    .Include(a => a.episodios)
                    .FirstOrDefault(a => a.nome.ToLower() == anime_nome.ToLower());

                if (anime == null)
                {
                    return Results.NotFound("Anime não encontrado.");
                }

                // Encontrar o próximo episódio
                var proximoEpisodio = anime.episodios
                    .FirstOrDefault(ep => ep.n_episodio == n_episodio + 1);

                if (proximoEpisodio == null)
                {
                    return Results.NotFound("Próximo episódio não encontrado.");
                }

                // Retornar apenas o episódio e o nome da franquia
                var result = new
                {
                    NomeFranquia = proximoEpisodio.anime.nome,
                    Episodio = new
                    {
                        proximoEpisodio.n_episodio,
                        proximoEpisodio.nome,
                        proximoEpisodio.link_capa,
                        proximoEpisodio.link_src
                    }
                };

                return Results.Ok(result);
            }
        }


        public static IResult GetPreviousAnimeEpisode([FromQuery] string anime_nome, [FromQuery] int n_episodio)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                // Encontrar o anime com base no nome fornecido (ignorando maiúsculas/minúsculas)
                var anime = dbContext.Animes
                    .Include(a => a.episodios)
                    .FirstOrDefault(a => a.nome.ToLower() == anime_nome.ToLower());

                if (anime == null)
                {
                    return Results.NotFound("Anime não encontrado.");
                }

                // Encontrar o próximo episódio
                var proximoEpisodio = anime.episodios
                    .FirstOrDefault(ep => ep.n_episodio == n_episodio - 1);

                if (proximoEpisodio == null)
                {
                    return Results.NotFound("Episódio Anterior não encontrado.");
                }

                // Retornar apenas o episódio e o nome da franquia
                var result = new
                {
                    NomeFranquia = proximoEpisodio.anime.nome,
                    Episodio = new
                    {
                        proximoEpisodio.n_episodio,
                        proximoEpisodio.nome,
                        proximoEpisodio.link_capa,
                        proximoEpisodio.link_src
                    }
                };

                return Results.Ok(result);
            }
        }

        public static IResult GetEpisodioViews(string nomeEpisodio)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                // Encontrar o episódio com base no nome fornecido
                var episodio = dbContext.Episodios
                    .FirstOrDefault(e => e.nome == nomeEpisodio);

                // Verificar se o episódio foi encontrado
                if (episodio != null)
                {
                    // Retornar o valor de views do episódio
                    return Results.Ok(episodio.views ?? 0); // Se views for nulo, retorna 0
                }
                else
                {
                    return Results.Ok("Episódio não Encontrado");
                }
            }
        }

        public static IResult SomarViewsPorAnime(string nomeAnime)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                // Encontrar o anime com base no nome fornecido
                var anime = dbContext.Animes
                    .Include(a => a.episodios)
                    .FirstOrDefault(a => a.nome == nomeAnime);

                // Verificar se o anime foi encontrado
                if (anime != null)
                {
                    // Somar as visualizações de todos os episódios do anime
                    int totalViews = anime.episodios.Sum(e => e.views ?? 0); // Se views for nulo, considera como 0

                    // Retornar o total de visualizações
                    return Results.Ok(totalViews);
                }
                else
                {
                    return Results.Ok("Anime não Encontrado");
                }
            }
        }

        public static IResult SomarViewsPorFranquia(string nomeFranquia)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                // Buscar a franquia com o nome fornecido
                var franquia = dbContext.Animes
                    .Include(a=> a.franquia)
                    .Include(a => a.episodios)
                    .FirstOrDefault(a => a.franquia.nome == nomeFranquia);

                // Verificar se a franquia foi encontrada
                if (franquia != null)
                {
                    // Somar as visualizações de todos os episódios da franquia
                    int totalViewsFranquia = franquia.episodios.Sum(e => e.views ?? 0); // Se views for nulo, considera como 0

                    // Retornar o total de visualizações da franquia
                    return Results.Ok(totalViewsFranquia);
                }
                else
                {
                    // Se a franquia não for encontrada, retornar uma mensagem de erro
                    return Results.NotFound("Franquia não encontrada.");
                }
            }
        }



























    }

}