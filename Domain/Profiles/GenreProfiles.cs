
using AutoMapper;
using cine_roxy.Domain.Models;

namespace cine_roxy.Domain.Profiles;

public class GenreProfiles : Profile
{
  public GenreProfiles()
  {
    CreateMap<GenreDto, Genre>();
    CreateMap<Genre, GenreDto>();
  }
}