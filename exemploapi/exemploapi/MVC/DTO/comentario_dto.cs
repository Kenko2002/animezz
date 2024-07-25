using animezz.MVC.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace animezz.MVC.DTO
{
    
    public class ComentarioDTO
    {
        public string? texto { get; set; }

        public string? episodio_nome { get; set; }

    }
}