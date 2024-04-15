using System.ComponentModel.DataAnnotations;

namespace cine_roxy.Domain.Models;


public class GenreDto
{
    [Required(ErrorMessage = "Categoria não informada.")]
    [StringLength(50)]
    [MinLength(3, ErrorMessage = "Categoria deve ter pelo menos 3 caracteres.")]
    public string? Name { get; set; }

}

