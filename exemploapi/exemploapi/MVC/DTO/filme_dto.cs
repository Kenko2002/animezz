using animezz.MVC.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace animezz.MVC.DTO
{
    
    public class FilmeDTO
    {
        public string? nome { get; set; }
        public string? franquia_nome { get; set; }
        public string? sinopse { get; set; }

        public string? link_capa { get; set; }
        public string? link_src { get; set; }


        

    }
}