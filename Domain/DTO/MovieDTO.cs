using System.ComponentModel.DataAnnotations;

namespace cine_roxy.Domain.Models;


public class MovieDto
{
    [Required(ErrorMessage = "Título não informado.")]
    [StringLength(50)]
    public string? Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public int GenreId { get; set; }

}

