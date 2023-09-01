using System.ComponentModel.DataAnnotations;

namespace MovieCRUD_MVC.Models
{
    public class Movie
    {
        [Key] //to define this is PK col in DB
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genere { get; set; }
        [Required]
        public DateTime Release_Date { get; set; }
        [Required]
        public string StarCast { get; set; }

        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
