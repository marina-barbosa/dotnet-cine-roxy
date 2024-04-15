using System.ComponentModel.DataAnnotations;

namespace cine_roxy.Domain.Models;

public class Genre
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
    
    public List<Movie>? Movies { get; set; }
}