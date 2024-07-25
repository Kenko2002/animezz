using animezz.MVC.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace animezz.MVC.model
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? texto { get; set; }

        public Usuario? usuario { get; set; }
        public Episodio? episodio { get; set; }


        public void transferirInformacao_DTO(ComentarioDTO dto)
        {
            //os dados de episodio devem ser pegos manualmente.
            texto = dto.texto;
        }

    }




}
