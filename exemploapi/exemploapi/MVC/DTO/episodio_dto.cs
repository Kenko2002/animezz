using animezz.MVC.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace animezz.MVC.DTO
{
    
    public class EpisodioDTO
    {

        public string? nome { get; set; }
        public string? sinopse { get; set; }
        public string? link_src { get; set; }
        public int? n_episodio { get; set; }
        public int? views { get; set; }
        public DateTime? data_insercao { get; set; }
        public string? link_capa { get; set; }
        public string? anime_nome { get; set; }



    }
}