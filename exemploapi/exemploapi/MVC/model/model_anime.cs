using animezz.MVC.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace animezz.MVC.model
{
    public class Anime
    {
        public int Id { get; set; }

        public string? nome { get; set; }
        public string? sinopse { get; set; }
        public string? link_capa { get; set; }
        public bool? eh_dublado { get; set; }
        public bool? eh_legendado { get; set; }
        public Franquia? franquia { get; set; } = new Franquia();
        public List<Episodio>? episodios { get; set; } = new List<Episodio>();

        public void transferirInformacao_DTO(AnimeDTO dto)
        {
            //os dados da franquia devem ser tirados manualmente
            nome = dto.nome;
            sinopse = dto.sinopse;
            link_capa = dto.link_capa;
            eh_dublado = dto.eh_dublado;
            eh_legendado = dto.eh_legendado;
            
        }

    }


}
