using Microsoft.EntityFrameworkCore;

namespace cine_roxy.Domain;

  public class MySqlDbContext : DbContext
  {
      public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
          : base(options)
      {
      }
  }
