using animezz.MVC.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace animezz.MVC.model
{
    public class Franquia
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public List<Anime>?  animes { get; set; } = new List<Anime>();
        public string? sinopse { get; set; }

        public List<Filme>? filmes { get; set; } = new List<Filme>();
        public List<Genero>? generos { get; set; } = new List<Genero>();



        public void transferirInformacao_DTO(FranquiaDTO dto)
        {
            nome = dto.nome;
            sinopse = dto.sinopse;
        }

    }


}
