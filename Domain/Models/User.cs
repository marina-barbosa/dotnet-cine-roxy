using System.ComponentModel.DataAnnotations;

namespace cine_roxy.Domain.Models;

public class User 
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [StringLength(50)]
    public string FullName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
}