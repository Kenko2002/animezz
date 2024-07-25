using animezz.MVC.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace animezz.MVC.model
{
    public class Episodio
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? sinopse { get; set; }
        public string? link_src { get; set; }
        public int? n_episodio { get; set; }
        public int? views { get; set; } = 0;
        public DateTime? data_insercao { get; set; } = DateTime.Now;
        public string? link_capa { get; set; }
        public Anime? anime { get; set; }



        public List<Comentario>? comentarios { get; set; } = new List<Comentario>();
        public List<Usuario>? visualizadores { get; set; } = new List<Usuario>();

        public void transferirInformacao_DTO(EpisodioDTO dto)
        {
            //os dados de Anime devem ser tirados manualmente
            nome = dto.nome;
            sinopse = dto.sinopse;
            link_src = dto.link_src;
            n_episodio = dto.n_episodio;
            views = dto.views;
            link_capa= dto.link_capa;
        }
    }


}
