using cine_roxy.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace cine_roxy.Domain;

  public class MySqlDbContext : DbContext
  {
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }      
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<User>()
        .HasIndex(x => x.Email)
        .IsUnique();
    }
  }
