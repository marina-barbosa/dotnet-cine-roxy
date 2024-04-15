
using AutoMapper;
using cine_roxy.Domain.Models;

namespace cine_roxy.Domain.Profiles;

public class MovieProfiles : Profile
{
  public MovieProfiles()
  {
    CreateMap<MovieDto, Movie>();
    CreateMap<Movie, MovieDto>();
  }
}