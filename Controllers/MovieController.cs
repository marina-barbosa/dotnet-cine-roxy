
using AutoMapper;
using cine_roxy.Domain;
using cine_roxy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace cine_roxy.Controllers;

[ApiController]
[Route("v1/movie")]

public class MovieController : ControllerBase
{
  private readonly MySqlDbContext _dbContext;
  private readonly IMapper _mapper;

  public MovieController(MySqlDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Movie>> GetMovie(int id)
  {
    var movie = await _dbContext.Movies.FindAsync(id);

    if (movie == null)
    {
      return NotFound();
    }

    return movie;
  }

  [HttpPost("register")]
  public async Task<ActionResult<MovieDto>> RegisterMovie([FromBody] MovieDto movieDto)
  {
    var newMovie = _mapper.Map<Movie>(movieDto);

    try
    {
      _dbContext.Movies.Add(newMovie);
      await _dbContext.SaveChangesAsync();

      var movieResponseDto = _mapper.Map<MovieDto>(newMovie);

      return CreatedAtAction("GetMovie", new { id = newMovie.Id }, movieResponseDto);
    }
    catch (DbUpdateException ex)
    {
      if (ex.InnerException is MySqlException mysqlException && mysqlException.Number == 1452)
      {
        return BadRequest("O gênero especificado não existe.");
      }
      else
      {
        return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
      }
    }
  }
}