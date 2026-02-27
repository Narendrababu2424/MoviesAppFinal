using System.ComponentModel.DataAnnotations;

namespace MoviesAppFinal.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Year")]
        [Range(1900, 2025)]
        public int ReleaseYear { get; set; }

        [Required]
        [RegularExpression("Action|Comedy|Drama|Horror|SciFi",
            ErrorMessage = "Genre must be Action, Comedy, Drama, Horror, or SciFi")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; } = string.Empty;
    }
}