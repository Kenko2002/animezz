using animezz.MVC.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace animezz.MVC.model
{
    public class Genero
    {
        public int Id { get; set; }
        public string? nome { get; set; }

        public List<Franquia>? franquias { get; set; } = new List<Franquia>();



        public void transferirInformacao_DTO(GeneroDTO dto)
        {
            nome = dto.nome;
        }



    }

}
