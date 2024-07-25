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

    public class FuncionalidadesDeAdmin
    {
        public static IResult UserGetAll(HttpContext httpContext)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                using (var dbContext = new MyProjectDbContext())
                {
                    var users = dbContext.Usuarios
                                            .Include(u => u.visualizacoes)
                                            .Include(u => u.comentarios)
                                            .ToList();
                    if (users.Count == 0)
                    {
                        return Results.NotFound("Nenhum usuário encontrado.");
                    }

                    //escondendo dados sensíveis usando um DTO.
                    var response = new List<UsuarioDTO>();
                    users.ForEach(u =>
                    {
                        var userdto = new UsuarioDTO();
                        userdto.login = u.login;
                        userdto.senha = u.senha;
                        userdto.link_foto_perfil = u.link_foto_perfil;
                        response.Add(userdto);
                    });

                    return Results.Ok(response);
                }
                
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }

        }

        






        public static IResult DeleteAllData(HttpContext httpContext)
        {
            using (var dbContext = new MyProjectDbContext())
            {
                if (httpContext.Session.GetString("Eh_Admin")=="True" ){
                    var usuarios = dbContext.Usuarios.ToList();
                    var animes = dbContext.Animes.ToList();
                    var comentarios = dbContext.Comentarios.ToList();
                    var franquias = dbContext.Franquias.ToList();
                    var episodios = dbContext.Episodios.ToList();
                    var filmes = dbContext.Filmes.ToList();
                    var generos = dbContext.Generos.ToList();



                    dbContext.Usuarios.RemoveRange(usuarios);
                    dbContext.Animes.RemoveRange(animes);
                    dbContext.Comentarios.RemoveRange(comentarios);
                    dbContext.Franquias.RemoveRange(franquias);
                    dbContext.Episodios.RemoveRange(episodios);
                    dbContext.Filmes.RemoveRange(filmes);
                    dbContext.Generos.RemoveRange(generos);

                    dbContext.SaveChanges();
                    return Results.Ok("Todos os dados foram deletados.");
                }
                else
                {
                    return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
                }
                
            }

        }

        //INSERÇÃO DE DADOS

        public static IResult GeneroCreate(HttpContext httpContext, [FromBody] GeneroDTO post_content)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Genero post = new Genero();
                post.transferirInformacao_DTO(post_content);

                using (var dbContext = new MyProjectDbContext())
                {
                    //conferindo se o genero já existe na base de dados
                    var generos = dbContext.Generos.Where(u => u.nome == post.nome).ToList();
                    if (generos.Count != 0)
                    {
                        return Results.Ok("Esse genero já está cadastrado!");
                    }

                    dbContext.Generos.Add(post);
                    dbContext.SaveChanges();

                    return Results.Ok(post);
                }
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }

            
        }


        public static IResult AnimeCreate(HttpContext httpContext, [FromBody] AnimeDTO post_content)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Anime post = new Anime();
                post.transferirInformacao_DTO(post_content);


                //lembrar de pegar o nome da franquia, procurar a franquia correspondente, e associar a post.
                var franquia_nome = post_content.franquia_nome;
                Franquia franquia;


                using (var dbContext = new MyProjectDbContext())
                {
                    franquia = dbContext.Franquias
                       .Include(g => g.animes)
                       .FirstOrDefault(f => f.nome == franquia_nome);


                    //conferindo se o genero já existe na base de dados
                    var animes = dbContext.Animes.Where(u => u.nome == post.nome).ToList();
                    if (animes.Count != 0)
                    {
                        return Results.Ok("Esse Anime já está cadastrado!");
                    }


                    if (!franquia.animes.Contains(post))
                    {
                        franquia.animes.Add(post);
                        dbContext.SaveChanges();
                        return Results.Ok(franquia);
                    }
                    else
                    {
                        return Results.Ok("Esse Anime já existe");
                    }

                }
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }


        }





        /*
        public static IResult EpisodioCreate(HttpContext httpContext, [FromBody] EpisodioDTO post_content)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Episodio post = new Episodio();
                post.transferirInformacao_DTO(post_content);


                //lembrar de pegar o nome do anime, procurar o anime correspondente, e associar a post.
                var anime_nome = post_content.anime_nome;
                Anime anime;


                using (var dbContext = new MyProjectDbContext())
                {
                    anime = dbContext.Animes
                       .Include(g => g.episodios)
                       .FirstOrDefault(f => f.nome == anime_nome);
                    
                    if (anime == null)
                    {
                        return Results.Ok("Anime não encontrado!");
                    }


                    //conferindo se o episodio já existe na base de dados
                    var animes = dbContext.Episodios.Where(u => u.nome == post.nome).ToList();
                    if (animes.Count != 0)
                    {
                        return Results.Ok("Esse Episódio já está cadastrado!");
                    }


                    if (!anime.episodios.Contains(post))
                    {
                        anime.episodios.Add(post);
                        dbContext.SaveChanges();
                        return Results.Ok(anime);
                    }
                    else
                    {
                        return Results.Ok("Esse Episódio já existe");
                    }

                }
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }


        }
        */
        public static IResult EpisodioCreate(HttpContext httpContext, [FromBody] EpisodioDTO post_content)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Episodio post = new Episodio();
                post.transferirInformacao_DTO(post_content);

                // Obter o nome do anime e procurar o anime correspondente
                var anime_nome = post_content.anime_nome;
                Anime anime;

                using (var dbContext = new MyProjectDbContext())
                {
                    anime = dbContext.Animes
                        .Include(g => g.episodios)
                        .FirstOrDefault(f => f.nome == anime_nome);

                    if (anime == null)
                    {
                        return Results.Ok("Anime não encontrado!");
                    }

                    // Encontrar o episódio de maior número (n_episodio) associado ao anime
                    int maxNepisodio = anime.episodios.Max(e => e.n_episodio) ?? 0;

                    // Definir o n_episodio do novo episódio como o próximo número após o máximo encontrado
                    post.n_episodio = maxNepisodio + 1;

                    // Conferir se o episódio já existe na base de dados
                    var episodios = dbContext.Episodios.Where(u => u.nome == post.nome).ToList();
                    if (episodios.Count != 0)
                    {
                        return Results.Ok("Esse Episódio já está cadastrado!");
                    }

                    if (!anime.episodios.Contains(post))
                    {
                        anime.episodios.Add(post);
                        dbContext.SaveChanges();
                        return Results.Ok(anime);
                    }
                    else
                    {
                        return Results.Ok("Esse Episódio já existe");
                    }
                }
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }
        }





        public static IResult FilmeCreate(HttpContext httpContext, [FromBody] FilmeDTO post_content)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Filme post = new Filme();
                post.transferirInformacao_DTO(post_content);


                //lembrar de pegar o nome da franquia, procurar a franquia correspondente, e associar a post.
                var franquia_nome = post_content.franquia_nome;
                Franquia franquia;


                using (var dbContext = new MyProjectDbContext())
                {
                    franquia = dbContext.Franquias
                       .Include(g => g.filmes)
                       .FirstOrDefault(f => f.nome == franquia_nome);


                    //conferindo se o genero já existe na base de dados
                    var filmes = dbContext.Filmes.Where(u => u.nome == post.nome).ToList();
                    if (filmes.Count != 0)
                    {
                        return Results.Ok("Esse Filme já está cadastrado!");
                    }



                    //dbContext.Filmes.Add(post);
                    //dbContext.SaveChanges();

                    if (!franquia.filmes.Contains(post))
                    {
                        franquia.filmes.Add(post);
                        dbContext.SaveChanges();
                        return Results.Ok(franquia);
                    }
                    else
                    {
                        return Results.Ok("Essa relação já existe");
                    }

                }
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }


        }






        public static IResult FranquiaCreate(HttpContext httpContext, [FromBody] FranquiaDTO post_content)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Franquia post = new Franquia();
                post.transferirInformacao_DTO(post_content);

                using (var dbContext = new MyProjectDbContext())
                {
                    var franquias = dbContext.Franquias.Where(u => u.nome == post.nome).ToList();
                    if (franquias.Count != 0)
                    {
                        return Results.Ok("Essa franquia já está cadastrada!");
                    }

                    dbContext.Franquias.Add(post);
                    dbContext.SaveChanges();

                    return Results.Ok(post);
                }
            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }

        }



        public static IResult AssociarFranquiaGenero(HttpContext httpContext, string franquia_nome, string genero_nome)
        {
            if (utilityFunctions.conferir_login_admin(httpContext))
            {
                Franquia franquia = new Franquia(); 
                Genero   genero   = new Genero();

                using (var dbContext = new MyProjectDbContext())
                {
                    franquia = dbContext.Franquias
                        .Include(g => g.generos)
                        .FirstOrDefault(f => f.nome == franquia_nome);
                    genero = dbContext.Generos.FirstOrDefault(g => g.nome == genero_nome);

                    if (franquia == null)
                    {
                        return Results.Ok("A Franquia não foi encontrada");
                    }

                    if (genero == null)
                    {
                        return Results.Ok("O Genero não foi encontrado");
                    }



                    // Verifica se a relação já existe
                    if (!franquia.generos.Contains(genero))
                    {
                        franquia.generos.Add(genero);
                        //genero.franquias.Add(franquia);
                        dbContext.SaveChanges();
                        return Results.Ok(franquia);
                    }
                    else
                    {
                        return Results.Ok("Essa relação já existe");
                    }

                }

            }
            else
            {
                return Results.Ok("Você não possui privilégios de Admin ou não está logado.");
            }


        }







    }

}