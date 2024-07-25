using animezz.MVC.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace animezz.MVC.model
{
    public class Filme
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public Franquia?  franquia { get; set; }
        public string? sinopse { get; set; }

        public string? link_capa { get; set; }
        public string? link_src { get; set; }

        public void transferirInformacao_DTO(FilmeDTO dto)
        {
            //os dados da franquia devem ser tirados manualmente
            nome = dto.nome;
            sinopse = dto.sinopse;
            link_capa = dto.link_capa;
            link_src = dto.link_src;
        }
    }


}
