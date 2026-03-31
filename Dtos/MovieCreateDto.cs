using System.ComponentModel.DataAnnotations;

namespace MoviesAppFinal.Dtos
{
    public class MovieCreateDto
    {
        [Required]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter.")]
        public string Title { get; set; }

        [Range(1900, 2025, ErrorMessage = "Release Year must be between 1900 and 2025.")]
        public int ReleaseYear { get; set; }

        [Required]
        [RegularExpression(@"^(Action|Comedy|Drama|Horror|SciFi)$", ErrorMessage = "Genre must be one of: Action, Comedy, Drama, Horror, SciFi.")]
        public string Genre { get; set; }

        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }
    }
}