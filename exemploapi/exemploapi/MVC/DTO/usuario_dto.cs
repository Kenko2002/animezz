using animezz.MVC.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace animezz.MVC.DTO
{
    public class UsuarioDTO
    {
        public string? login { get; set; }
        public string? senha { get; set; }
        public string? link_foto_perfil { get; set; }


    }
}