using System.ComponentModel.DataAnnotations;

namespace cine_roxy.Domain.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
    public bool IsDeleted { get; set; } = false;

    [Required]
    public int GenreId { get; set; }
    public virtual Genre Genre { get; set; } = null!;

}