using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using animezz.MVC.DTO;

namespace animezz.MVC.model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? login { get; set; }
        public string? senha { get; set; }
        public bool? eh_admin { get; set; }
        public string? link_foto_perfil { get; set; }

        public List<Comentario>? comentarios { get; set; } = new List<Comentario>();
        public List<Episodio>? visualizacoes { get; set; } = new List<Episodio>();



        public void transferirInformacao_DTO(UsuarioDTO dto)
        {
            login = dto.login;
            senha = dto.senha;
            link_foto_perfil = dto.link_foto_perfil;
        }

    }


}
