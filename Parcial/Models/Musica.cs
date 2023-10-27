using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Musica
    {
        [Key]
        public int IdMusica { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int NumeroReproducciones { get; set; }
        
       
        //public Universidad Universidad { get; set; }
    }
}
