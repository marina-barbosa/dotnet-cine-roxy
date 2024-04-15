
using AutoMapper;
using cine_roxy.Domain;
using cine_roxy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cine_roxy.Controllers;

[ApiController]
[Route("v1/genre")]

public class GenreController : ControllerBase
{
  private readonly MySqlDbContext _dbContext;
  private readonly IMapper _mapper;

  public GenreController(MySqlDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Genre>> GetGenre(int id)
  {
    var genre = await _dbContext.Genres.FindAsync(id);

    if (genre == null)
    {
      return NotFound();
    }

    return genre;
  }

  [HttpPost("register")]
  public async Task<ActionResult<GenreDto>> RegisterGenre([FromBody] GenreDto genreDto)
  {
    var newGenre = _mapper.Map<Genre>(genreDto);

    try
    {
      _dbContext.Genres.Add(newGenre);
      await _dbContext.SaveChangesAsync();

      var genreResponseDto = _mapper.Map<GenreDto>(newGenre);

      return CreatedAtAction("GetGenre", new { id = newGenre.Id }, genreResponseDto);
    }
    catch (DbUpdateException ex)
    {
      return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
    }
  }
}