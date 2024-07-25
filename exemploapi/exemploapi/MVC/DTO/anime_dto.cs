using animezz.MVC.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace animezz.MVC.DTO
{
    
    public class AnimeDTO
    {

        public string? nome { get; set; }
        public string? sinopse { get; set; }
        public string? link_capa { get; set; }
        public bool? eh_dublado { get; set; }
        public bool? eh_legendado { get; set; }
        public string? franquia_nome { get; set; }





    }
}